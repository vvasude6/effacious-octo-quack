using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mnemonics
{
    public class DbErrorCodes
    {
        public static String DBERR_TXNM_NOFIND = "999";
        public static String DBERR_ERRM_NOFIND = "998";
        public static String DBERR_ACTM_NOFIND = "997";

        public static String TXERR_INIT_PVG = "500";
        public static String TXERR_NO_DEBIT = "499";
        public static String TXERR_NO_CREDIT = "498";
        public static String TXERR_NEGATIVE_TRANSFER = "497";
        public static String TXERR_NO_USER = "000";
    }
}
