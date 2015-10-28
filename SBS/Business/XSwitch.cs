using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Data;

namespace Business
{
    public class XSwitch
    {
        String result;
        DataSet _resultSet;
        public DataSet resultSet
        {
            get
            {
                return this._resultSet;
            }
            set
            {
                this._resultSet = value;
            }
        }
        public String resultGet
        {
            get 
            {
                return this.result;
            }
        }
        public String resultP 
        {
            get { return this.result; }
            set { this.result = value; }
        }
        public XSwitch()
        {
        }
        public XSwitch(string connectionString, String loginAccount, String inData)
        {
            // DECRYPT incoming Message String here
            char[] delimiters = { '|' };
            String[] dataPart = inData.Split(delimiters);
            String loginAc = loginAccount;
            
            
            // part[0] = transaction id
            // part[1] = account number 1
            // part[2] = account number 2
            // part[3] = amount
            //  ...
            try
            {
                switch (dataPart[0])
                {
                    case "001": // Login
                        //String tempResult = "";
                        Y_000 y000 = new Y_000(Mnemonics.TxnCodes.TX_LOGIN, connectionString, dataPart[1], dataPart[2]);
                        result = y000.resultP;
                        /*
                        Y_000 y000 = new Y_000(Mnemonics.TxnCodes.TX_LOGIN, connectionString, dataPart[1], dataPart[2]);
                        if (y000.errorGet)
                        {
                            resultSet = new DataSet(y000.getOutput().ToString());
                        }
                        else
                        {
                            resultSet = y000.resultSetGet;
                        }*/
                        // ENCRYPT result here
                        break;
                    case "008": // Fetch Pending transactions - Employee
                        Y_008 y008 = new Y_008(connectionString, Mnemonics.TxnCodes.TX_EMP_PENDING, Convert.ToInt16(dataPart[1]));//Mnemonics.TxnCodes.TX_BALINQ, connectionString, dataPart[1]);
                        resultSet = y008.resultSetP;
                        // ENCRYPT result here
                        break;
                    case "009": // Balance Inquiry
                        Y_010 y010 = new Y_010(connectionString, Mnemonics.TxnCodes.TX_BALINQ_BULK);//Mnemonics.TxnCodes.TX_BALINQ, connectionString, dataPart[1]);
                        if (!y010.errorBoolP)
                        {
                            y010.fetchMultipleAccounts(connectionString, dataPart[1]);
                        }
                        resultSet = y010.resultSetP;
                        // ENCRYPT result here
                        break;
                    case "010": // Balance Inquiry
                            Y_010 y010_1 = new Y_010(Mnemonics.TxnCodes.TX_BALINQ, connectionString, dataPart[1]);
                        result = y010_1.getOutput();
                        // ENCRYPT result here
                        break;
                    case "011": // Debit
                        Y_011 y011 = new Y_011(Mnemonics.TxnCodes.TX_DEBIT, connectionString, dataPart[1],
                            Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                        if (y011.pvgBypassedP)
                        {
                            if(!deletePendingTransaction(connectionString, dataPart[5]))
                            {
                                throw (new Exception("Pending transaction not removed"));
                            }
                        }
                        result = y011.resultP;
                        // ENCRYPT result here
                        break;
                    case "012": // Credit
                        Y_012 y012 = new Y_012(Mnemonics.TxnCodes.TX_CREDIT, connectionString, dataPart[1],
                            Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                        if (y012.pvgBypassedP)
                        {
                            if (!deletePendingTransaction(connectionString, dataPart[5]))
                            {
                                throw (new Exception("Pending transaction not removed"));
                            }
                        }
                        result = y012.getOutput();
                        // ENCRYPT result here
                        break;
                    case "013": // High Value Credit
                        Y_012 y012_1 = new Y_012(Mnemonics.TxnCodes.TX_HIGHVAL_CREDIT, connectionString,
                            dataPart[1], Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                        result = y012_1.getOutput();
                        // ENCRYPT result here
                        break;
                    case "014": // Internal Funds Transfer = TRANSFER_DEBIT + TRANSFER_CREDIT
                        Y_013 y013 = new Y_013(Mnemonics.TxnCodes.TX_INT_TRANSFER, connectionString, dataPart[1], dataPart[2],
                            Convert.ToDecimal(dataPart[3]), loginAc);
                        if (!y013.basicValidationError())
                        {
                            Y_011 y011_1 = new Y_011(Mnemonics.TxnCodes.TX_TRANSFER_DEBIT,
                                connectionString, dataPart[1], Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                            result = y011_1.getOutput();
                            if (!y011_1.basicValidationError())
                            {
                                Y_012 y012_2 = new Y_012(Mnemonics.TxnCodes.TX_TRANSFER_CREDIT,
                                connectionString, dataPart[2], Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                                if (!y012_2.txnErrorP)
                                {
                                    if (y012_2.pvgBypassedP)
                                    {
                                        if (!deletePendingTransaction(connectionString, dataPart[5]))
                                        {
                                            throw (new Exception("Pending transaction not removed"));
                                        }
                                    }
                                    resultP = "Successful!";
                                }
                                else
                                {
                                    resultP = y012_2.getOutput();
                                }
                            }
                        }
                        else
                        {
                            result = y013.getOutput();
                        }
                        // ENCRYPT result here
                        break;
                    case "015": // Internal High Value Funds Transfer = TRANSFER_DEBIT + HIGH VALUE TRANSFER_CREDIT
                        Y_013 y013_1 = new Y_013(Mnemonics.TxnCodes.TX_INT_TRANSFER, connectionString, dataPart[1], dataPart[2],
                            Convert.ToDecimal(dataPart[3]), loginAc);
                        if (!y013_1.basicValidationError())
                        {
                            Y_011 y011_1 = new Y_011(Mnemonics.TxnCodes.TX_TRANSFER_DEBIT,
                                connectionString, dataPart[1], Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                            result = y011_1.getOutput();
                            if (!y011_1.basicValidationError())
                            {
                                Y_012 y012_2 = new Y_012(Mnemonics.TxnCodes.TX_TRANSFER_CREDIT,
                                connectionString, dataPart[2], Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                                if (!y012_2.txnErrorP)
                                {
                                    if (y012_2.pvgBypassedP)
                                    {
                                        if (!deletePendingTransaction(connectionString, dataPart[5]))
                                        {
                                            throw (new Exception("Pending transaction not removed"));
                                        }
                                    }
                                    resultP = "Successful!";
                                }
                                else
                                {
                                    resultP = y012_2.getOutput();
                                }
                            }
                        }
                        else
                        {
                            result = y013_1.getOutput();
                        }
                        // ENCRYPT result here
                        break;
                    case "021": // External Funds Transfer = TRANSFER_DEBIT + TRANSFER_CREDIT
                        Y_013 y013_2 = new Y_013(Mnemonics.TxnCodes.TX_EXT_TRANSFER, connectionString, dataPart[1], dataPart[2],
                            Convert.ToDecimal(dataPart[3]), loginAc);
                        if (!y013_2.basicValidationError())
                        {
                            Y_011 y011_1 = new Y_011(Mnemonics.TxnCodes.TX_TRANSFER_DEBIT,
                                connectionString, dataPart[1], Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                            result = y011_1.getOutput();
                            if (!y011_1.basicValidationError())
                            {
                                Y_012 y012_2 = new Y_012(Mnemonics.TxnCodes.TX_TRANSFER_CREDIT,
                                connectionString, dataPart[2], Convert.ToDecimal(dataPart[3]), dataPart[4], dataPart[5], loginAc);
                                result = y012_2.getOutput();
                            }
                        }
                        else
                        {
                            result = y013_2.getOutput();
                        }
                        // ENCRYPT result here
                        break;
                    case Mnemonics.TxnCodes.TX_UPDATE_PROFILE: // Edit customer info
                        Y_014 y014 = new Y_014(Mnemonics.TxnCodes.TX_UPDATE_PROFILE, connectionString,
                            dataPart[1], dataPart[2], dataPart[3], dataPart[4], dataPart[5], dataPart[6],
                            dataPart[7], dataPart[8], dataPart[9], dataPart[10], dataPart[11], dataPart[12],
                            dataPart[13], dataPart[14], dataPart[15], dataPart[16], dataPart[17], dataPart[18],
                            dataPart[19], dataPart[20], dataPart[21], dataPart[22], dataPart[23]);
                        result = y014.getOutput();
                        // ENCRYPT result here
                        break;
                    case Mnemonics.TxnCodes.TX_REGISTER_CUSTOMER: // User Registration for Online Banking // input = dataPart[1] = customer number
                        //String loginAccc = dataPart[1];
                        Y_015 y015 = new Y_015(Mnemonics.TxnCodes.TX_UPDATE_PROFILE, connectionString,
                            dataPart[1], dataPart[2], dataPart[3], dataPart[4], dataPart[5], dataPart[6],
                            dataPart[7], dataPart[8], dataPart[9], dataPart[10], dataPart[11], dataPart[12],
                            dataPart[13], dataPart[14], dataPart[15], dataPart[16], dataPart[17], dataPart[18],
                            dataPart[19], dataPart[20], dataPart[21], dataPart[22], dataPart[23], loginAc);
                        result = y015.resultP;
                        // ENCRYPT result here
                        break;
                    case Mnemonics.TxnCodes.TX_FETCH_CUSTOMER: // Fetch Customer record
                        //String loginAccc = dataPart[1];
                        Y_019 y019 = new Y_019(Mnemonics.TxnCodes.TX_FETCH_CUSTOMER, connectionString, loginAc);
                        result = y019.resultP;
                        // ENCRYPT result here
                        break;
                    case Mnemonics.TxnCodes.TX_FORGET_PASSWORD:
                        Y_024 y024 = new Y_024(Mnemonics.TxnCodes.TX_FORGET_PASSWORD, connectionString, dataPart[1], dataPart[2]);
                        resultP = y024.resultP;
                        break;
                }
            }
            catch (Exception e)
            {
                this.result = e.ToString();
                this.resultSet = new DataSet(e.ToString());
            }
        }
        public DataSet getFinHistory(String connectionString, String cusno)
        {
            Data.Dber dberr = new Data.Dber();
            DataSet dSet = Data.FinhistD.GetAccountStatement(connectionString, cusno, dberr);
            if (!dberr.ifError())
            {
                return dSet;
            }
            else return null;
        }
        public DataSet getNonFinHistory(String connectionString, String cusno)
        {
            Data.Dber dberr = new Data.Dber();
            DataSet dSet = Data.NfinhistD.GetAccountStatement(connectionString, cusno, dberr);
            if (!dberr.ifError())
            {
                return dSet;
            }
            else return null;
        }

        public string geTranDataFromRefNumber(string connectionString, string ref_no)
        {
            var dberr = new Data.Dber();
            var data = Data.PendtxnD.GetTranDataFromRefNumber(connectionString, ref_no, dberr);
            if (!dberr.ifError())
            {
                return data;
            }
            else return null;
        }
        
        public Entity.Cstm getExternalUserDataFromUserName(string connectionString, string username)
        {
            var dberr = new Data.Dber();
            var data = Data.CstmD.GetCustomerObjectFromUserName(connectionString, username, dberr);
            if (!dberr.ifError())
            {
                return data;
            }
            else return null;
        }
        
        public DataSet getEmployeeAccessibleCustomerData(string connectionString, string employeeId)
        {
            var dberr = new Data.Dber();
            var ds = Data.CstmD.GetEmployeeAccessibleCustomerData(connectionString, employeeId, dberr);
            if (!dberr.ifError())
            {
                return ds;
            }
            else return null;
        }

        public bool deletePendingTransaction(string connectionString, string referenceNumber)
        {
            var dberr = new Data.Dber();
            return Data.PendtxnD.Delete(connectionString, referenceNumber);
        }
    }
}
