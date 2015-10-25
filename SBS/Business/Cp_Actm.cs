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
    public class Cp_Actm
    {
        Entity.Actm actm;
        Decimal newBal;
        public Entity.Actm actmP 
        { 
            get
            {
                return actm;
            }
        }
        //private Decimal changeAmount;
        String[] actmParts;
        //actm = new Entity.Actm();
        public Cp_Actm()
        { }
        public Cp_Actm(string connectionString, String acno, Data.Dber dberr)
        {
            // fetch all details for ac_no = acno.
            actm = Data.ActmD.Read(connectionString, acno, dberr);
        }
        public DataSet fetchAccountsFromCusNo(string connectionString, String cusno, Data.Dber dberr)
        {
            DataSet dbQuery = new DataSet();
            dbQuery = Data.ActmD.GetUserAccountBalance(connectionString, cusno, dberr);
            return dbQuery;
        }
        public Boolean getCreditAllowed()
        {
            if (this.actmP.ac_cr_flag.Equals("Y"))
                return true;
            else
                return false;
        }
        public Boolean getDebitAllowed()
        {
            if(this.actmP.ac_dr_flag.Equals("Y"))
                return true;
            else
                return false;
        }
        public void addBalance(Decimal changeAmount, Data.Dber dberr)
        {
            try
            {
                if (this.getCreditAllowed())
                {
                    this.newBal = this.actmP.ac_bal + changeAmount;
                    this.actmP.ac_bal = this.newBal;
                    // Check if newBal is at most as much as the maximum balance allowed for the account through ACPRM table.

                    // Update newBal in Actm.
                    Boolean dbCode = Data.ActmD.Update(this.actmP, dberr);
                }
                else
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_NO_CREDIT);
                }
            }
            catch(Exception e)
            {
                // do something, or remove later
            }
        }
        public void subtractBalance(Decimal changeAmount, Data.Dber dberr)
        {
            try
            {
                if (this.getDebitAllowed())
                {
                    this.newBal = this.actmP.ac_bal - changeAmount;
                    if (this.newBal < 0)
                    {
                        dberr.setError(Mnemonics.DbErrorCodes.TXERR_INSUFFICIENT_BALANCE);
                    }
                    else
                    {
                        this.actmP.ac_bal = this.newBal;
                        // need to implement minimum balance check through new account type parameter table ACPRM

                        // Update newBal in Actm.
                        Boolean dbCode = Data.ActmD.Update(this.actmP, dberr);
                    }
                }
                else 
                {
                    dberr.setError(Mnemonics.DbErrorCodes.TXERR_NO_DEBIT);
                }
            }
            catch (Exception e)
            {
                //do something, or remove later
            }
        }
        
        public void updateBalance(Decimal changeAmount, Data.Dber dberr)
        {
            if(changeAmount > 0)
            {
                addBalance(changeAmount, dberr);
            }
            else
            {
                if (changeAmount < 0)
                {
                    subtractBalance(changeAmount, dberr);
                }
            }
        }
    }
}
