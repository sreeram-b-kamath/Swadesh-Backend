using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace Helpers;

public static class ValidateEmail
{
    public static bool ValidateEmailAddress(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            string host = mailAddress.Host;
            return Dns.GetHostAddresses(host) != null;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}