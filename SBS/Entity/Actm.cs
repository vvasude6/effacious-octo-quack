using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Business
{
    public class Actm
    {
        char[] delimiter = { '|' };
        //String SPROC = Mnemonics.SP_ACTM_ALL;
        //static String errCode = "-DbErr";
        //------
        String ac_no;
        String cs_no1;
        String cs_no2;
        String ac_type;
        Decimal ac_bal;
        Decimal ac_hold;
        Int32 ac_pvg;
        String ac_dr_flag;
        String ac_cr_flag;
        String ac_open_dt;
        Dber dbr;
        //------
        private Decimal changeAmount;
        String[] actmParts;
        public Actm(String acno, Dber dbr)
        {
            // fetch all details for ac_no = acno.
            // call to specific stored procedure
            this.dbr = dbr;
            /*Db fetch = new Db(SPROC, dbr);
            if (dbr.ifError())
            {
                // store in ERRHIST
            }
            else
            {
                String db_data = fetch.getData();
                actmParts = db_data.Split(delimiter);
            }*/
        }
        public Boolean setChangeAmount(Decimal amt)
        {
            try
            {
                this.changeAmount = amt;
                return true;
            }
            catch(Exception e)
            {
                // should throw "System Error" at the end
                return false;
            }
        }
        public Int32 getPrivilegeLevel()
        {
            return this.ac_pvg;
        }
        public Decimal getBalance()
        {
            return this.ac_bal;
        }
        /*public Boolean addBalance()
        {
            try
            {
                if (this.getCreditAllowed())
                {
                    Decimal newBal = this.getBalance() + this.changeAmount;
                    String query = String.Format("update ACTM set AC_BAL={1} where ac_no={2}", newBal, this.ac_no);
                    int dbCode = Data.DbAccess.ExecuteNonQuery(CommandType.Text, query);
                    // Check if newBal is at most as much as the maximum balance allowed for the account.

                    // Update newBal in Actm.
                    if (dbCode != 0)
                    {
                        return true;
                    }
                    else throw (new Exception("ACTM update error"));
                }
                else return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }*/
        /*public Boolean subtractBalance()
        {
            try
            {
                if (this.getDebitAllowed())
                {
                    Decimal newBal = this.getBalance() - this.changeAmount;
                    String query = String.Format("update ACTM set AC_BAL={1} where ac_no={2}", newBal, this.ac_no);
                    //int dbCode = Data.DbAccess.ExecuteNonQuery(CommandType.Text, query);
                    // Check if newBal is at most as much as the maximum balance allowed for the account.

                    // Update newBal in Actm.
                    if (dbCode != 0)
                    {
                        return true;
                    }
                    else throw (new Exception("ACTM update error"));
                    // Check if newBal is at least as much as the minimum balance required for the account.

                    // Update newBal in Actm
                }
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }*/
        public Boolean getCreditAllowed()
        {
            if (ac_cr_flag.Equals("Y"))
                return true;
            else
                return false;
        }
        public Boolean getDebitAllowed()
        {
            if (ac_dr_flag.Equals("Y"))
                return true;
            else
                return false;
        }
        public Boolean updateBalance()
        {
           /* if (this.changeAmount > 0)
            {
                if (addBalance())
                {
                    //Db updateDb = new Db();
                    /*updateDb.executeSingleDML(Mnemonics.TBL_ACTM, Mnemonics.FLD_ACTM_BAL, Mnemonics.KEY_ACTM,
                        new ArrayList(new String[] { " ", " " }), new ArrayList(new Int32[] { Convert.ToInt32(this.ac_bal),
                            Convert.ToInt32(this.ac_no) }), this.dbr);
                    
                    return true;
                }
                else
                    return false;
            }
            else
            {
                if (this.changeAmount < 0)
                {
                    if (subtractBalance())
                    {
                        Db updateDb = new Db();
                        return true;
                    }
                    else
                        return false;
                }
                else return false;
            }*/
            return true;
        }
    }
}
