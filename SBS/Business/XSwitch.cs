using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class XSwitch
    {
        String result;
        public String resultP { get { return result; } }
        public XSwitch(string connectionString, String inData)
        {
            char[] delimiters = { '|' };
            String[] dataPart = inData.Split(delimiters);
            
            
            // part[0] = transaction id
            // part[1] = account number 1
            // part[2] = account number 2
            // part[3] = customer number
            //  ...
            try
            {
                switch (dataPart[0])
                {
                    case "010": // Balance Inquiry
                        Y_010 y010 = new Y_010(connectionString, dataPart[1]);
                        result = y010.getOutput();
                        break;
                    case "011": // Debit
                        Y_011 y011 = new Y_011(connectionString, dataPart[1]);
                        result = y011.getOutput();
                        break;
                    case "012": // Credit
                        Y_012 y012 = new Y_012(dataPart[1]);
                        result = y012.getOutput();
                        break;
                    case "013": // Funds Transfer
                        Y_013 y013 = new Y_013(connectionString, dataPart[1], dataPart[2]);
                        result = y013.getOutput();
                        break;
                }
            }
            catch (Exception e)
            {
                String error = e.ToString();
            }
        }
    }
}
