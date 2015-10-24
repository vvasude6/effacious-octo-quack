using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UI
{
    public static class Global
    {
        public static string ConnectionString 
        {
            get 
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            }
        }
    }

    public static class Validate
    {
        public static Boolean generalValidate(String inputString, Boolean allowAlpha, Boolean allowNumeral, String allowChars = "")
        {
            return true;
        }

        public static Boolean isUserNameValid(String inputString)
        {
            return generalValidate(inputString, true, true, "-");
        }

        public static Boolean isZipCodeValid(String inputString)
        {
            return generalValidate(inputString, false, true, "-");
        }

        public static Boolean isCityValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isStateValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isPhoneNumberValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isEmailAddressValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isUserIDValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isBranchValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isSecurityQuestionValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isSecurityAnswerValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isDescriptionValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isAccountNumberValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }

        public static Boolean isAmountValid(String inputString)
        {
            return generalValidate(inputString,false, true, "-");
        }
    }
}