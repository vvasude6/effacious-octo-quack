using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    static class Mnemonics
    {
        public static String ERR_PRIV = "010";

        public static String TX_BALINQ = "010";
        public static String TX_DEBIT = "011";
        public static String TX_CREDIT = "012";
        public static String TX_FUNDS_TRANSFER = "013";

        public static String SP_ERRM_ALL = "PS_000";
        public static String SP_TXNM_ALL = "PS_001";
        public static String SP_ACTM_ALL = "PS_002";

        public static String TBL_ACTM = "ACTM";
        public static String FLD_ACTM_BAL = "AC_BAL";
        public static String KEY_ACTM = "AC_NO";

        public static String CONN_STRING = "Server=(local);Initial Catalog=SBS; Integrated Security=True";

    }
}
