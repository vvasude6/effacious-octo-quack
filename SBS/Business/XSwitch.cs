using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class XSwitch
    {
        XSwitch(String inData)
        {
            char[] delimiters = { '|' };
            String[] dataPart = inData.Split(delimiters);
            // part[0] = transaction id
            // part[1] = account number
            // part[2] = customer number
            //  ...
            try
            {
                switch (dataPart[0])
                {
                    case "010":
                        Y_010 y010 = new Y_010(dataPart[1]);
                        String result = y010.getOutput();
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
