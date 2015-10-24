using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Authenticator;

namespace Security
{
    public static class OTPService
    {
        public static bool OTPSucceeded(string secret, string userInput)
        {
            var authenticator = new TwoFactorAuthenticator();
            return authenticator.ValidateTwoFactorPIN(secret, userInput);
        }

        //write function to send secret key via message;
        //write function to send secret key via mail;

    }
}
