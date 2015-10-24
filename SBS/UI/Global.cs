using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
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
        static String ALPHA = "abcdefghijklmnopqrstuvwxyz";
        static String DIGIT = "0123456789";

        public static Boolean generalValidate(String inputString, Boolean allowAlpha, Boolean allowNumeral, String allowChars = "")
        {
            String lowerString = inputString.ToLower();

            foreach (char inputChar in lowerString)
            {
                if (allowAlpha)
                    if (ALPHA.IndexOf(inputChar) >= 0)
                        continue;
                if (allowNumeral)
                    if (DIGIT.IndexOf(inputChar) >= 0)
                        continue;
                if (allowChars.IndexOf(inputChar) >= 0)
                    continue;

                return false;
            }
            return true;
        }

        public static Boolean isUserNameValid(String inputString)
        {
            return generalValidate(inputString, true, true, "- ");
        }

        public static Boolean isZipCodeValid(String inputString)
        {
            if (inputString.Length > 10)
                return false;

            return generalValidate(inputString, false, true, "-");
        }

        public static Boolean isCityValid(String inputString)
        {
            return generalValidate(inputString, true, false, "- ");
        }

        public static Boolean isStateValid(String inputString)
        {
            if (inputString.Length > 2)
                return false;

            return generalValidate(inputString, true, false, " ");
        }

        public static Boolean isPhoneNumberValid(String inputString)
        {
            if (inputString.Length > 18)
                return false;
            return generalValidate(inputString, false, true, "-() +");
        }

        public static Boolean isEmailAddressValid(String inputString)
        {
            return generalValidate(inputString, true, true, "@.-_");
        }

        public static Boolean isUserIDValid(String inputString)
        {
            return generalValidate(inputString, false, true, "");
        }

        public static Boolean isBranchValid(String inputString)
        {
            return generalValidate(inputString, false, true, "");
        }

        public static Boolean isSecurityQuestionValid(String inputString)
        {
            return generalValidate(inputString, true, true, " '?.,-");
        }

        public static Boolean isSecurityAnswerValid(String inputString)
        {
            return generalValidate(inputString, true, true, " '-,.");
        }

        public static Boolean isDescriptionValid(String inputString)
        {
            return generalValidate(inputString, false, true, " -,.?;$&");
        }

        public static Boolean isAccountNumberValid(String inputString)
        {
            return generalValidate(inputString, false, true, "");
        }

        public static Boolean isAmountValid(String inputString)
        {
            if (inputString.Length > 10)
                return false;
            return generalValidate(inputString, false, true, ".");
        }
    }
}