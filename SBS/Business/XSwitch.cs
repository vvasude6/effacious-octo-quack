﻿using System;
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
        DataSet resultSet;
        public String resultGet
        {
            get 
            {
                return this.result;
            }
        }
        public String resultP { get { return result; } }
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
                    case "000": // Login
                        //String tempResult = "";
                        Y_000 y000 = new Y_000(Mnemonics.TxnCodes.TX_LOGIN, connectionString, dataPart[1], dataPart[2]);
                        if (y000.errorGet)
                        {
                            resultSet = new DataSet(y000.getOutput().ToString());
                        }
                        else
                        {
                            resultSet = y000.resultSetGet;
                        }
                        //String accounts = y000.getOutput();
                        //String[] account = accounts.Split(delimiters);
                        /*foreach(String s in account)
                        {
                            Y_010 y0 = new Y_010(Mnemonics.TxnCodes.TX_BALINQ, connectionString, s);
                            tempResult += y0.resultGet + "|";
                        }
                        result = tempResult;
                        */
                        // ENCRYPT result here
                        break;
                    case "010": // Balance Inquiry
                            Y_010 y010 = new Y_010(Mnemonics.TxnCodes.TX_BALINQ, connectionString, dataPart[1]);
                        result = y010.getOutput();
                        // ENCRYPT result here
                        break;
                    case "011": // Debit
                        Y_011 y011 = new Y_011(Mnemonics.TxnCodes.TX_DEBIT, connectionString, dataPart[1], 
                            Convert.ToDecimal(dataPart[3]), loginAc);
                        result = y011.getOutput();
                        // ENCRYPT result here
                        break;
                    case "012": // Credit
                        Y_012 y012 = new Y_012(Mnemonics.TxnCodes.TX_CREDIT, connectionString, dataPart[1], 
                            Convert.ToDecimal(dataPart[3]), loginAc);
                        result = y012.getOutput();
                        // ENCRYPT result here
                        break;
                    case "013": // High Value Credit
                        Y_012 y012_1 = new Y_012(Mnemonics.TxnCodes.TX_HIGHVAL_CREDIT, connectionString, 
                            dataPart[1], Convert.ToDecimal(dataPart[3]), loginAc);
                        result = y012_1.getOutput();
                        // ENCRYPT result here
                        break;
                    case "014": // Internal Funds Transfer = TRANSFER_DEBIT + TRANSFER_CREDIT
                        Y_013 y013 = new Y_013(Mnemonics.TxnCodes.TX_INT_TRANSFER, connectionString, dataPart[1], dataPart[2],
                            Convert.ToDecimal(dataPart[3]), loginAc);
                        if (!y013.basicValidationError())
                        {
                            Y_011 y011_1 = new Y_011(Mnemonics.TxnCodes.TX_TRANSFER_DEBIT,
                                connectionString, dataPart[1], Convert.ToDecimal(dataPart[3]), loginAc);
                            result = y011_1.getOutput();
                            if (!y011_1.basicValidationError())
                            {
                                Y_012 y012_2 = new Y_012(Mnemonics.TxnCodes.TX_TRANSFER_CREDIT,
                                connectionString, dataPart[2], Convert.ToDecimal(dataPart[3]), loginAc);
                                result = y012_2.getOutput();
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
                                connectionString, dataPart[1], Convert.ToDecimal(dataPart[3]), loginAc);
                            result = y011_1.getOutput();
                            if (!y011_1.basicValidationError())
                            {
                                Y_012 y012_2 = new Y_012(Mnemonics.TxnCodes.TX_TRANSFER_CREDIT,
                                connectionString, dataPart[2], Convert.ToDecimal(dataPart[3]), loginAc);
                                result = y012_2.getOutput();
                            }
                        }
                        else
                        {
                            result = y013_1.getOutput();
                        }
                        // ENCRYPT result here
                        break;
                    case "016": // External Funds Transfer = TRANSFER_DEBIT + TRANSFER_CREDIT
                        Y_013 y013_2 = new Y_013(Mnemonics.TxnCodes.TX_EXT_TRANSFER, connectionString, dataPart[1], dataPart[2],
                            Convert.ToDecimal(dataPart[3]), loginAc);
                        if (!y013_2.basicValidationError())
                        {
                            Y_011 y011_1 = new Y_011(Mnemonics.TxnCodes.TX_TRANSFER_DEBIT,
                                connectionString, dataPart[1], Convert.ToDecimal(dataPart[3]), loginAc);
                            result = y011_1.getOutput();
                            if (!y011_1.basicValidationError())
                            {
                                Y_012 y012_2 = new Y_012(Mnemonics.TxnCodes.TX_TRANSFER_CREDIT,
                                connectionString, dataPart[2], Convert.ToDecimal(dataPart[3]), loginAc);
                                result = y012_2.getOutput();
                            }
                        }
                        else
                        {
                            result = y013_2.getOutput();
                        }
                        // ENCRYPT result here
                        break;
                    case "017": // Edit customer info
                        Y_014 y014 = new Y_014(Mnemonics.TxnCodes.TX_UPDATE_PROFILE, connectionString,
                            dataPart[1], dataPart[2], dataPart[3], dataPart[4], dataPart[5], dataPart[6],
                            dataPart[7], dataPart[8], dataPart[9], dataPart[10], dataPart[11], dataPart[12],
                            dataPart[13], dataPart[14], dataPart[15], dataPart[16], dataPart[17], dataPart[18], dataPart[19], 
                            dataPart[20], dataPart[21], loginAc);
                        result = y014.getOutput();
                        // ENCRYPT result here
                        break;
                }
            }
            catch (Exception e)
            {
                String error = e.ToString();
                throw e;
            }
        }
    }
}
