using System;
using System.Collections.Generic;
using System.Collections;

namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Infrastructure
{
    public class SmtpMailClient
    {
        private static SmtpMailClient instance;

        private Dictionary<String, List<String>> sentMails = new Dictionary<String, List<String>>();

        public static SmtpMailClient getInstance()
        {
            if (instance == null)
            {
                instance = new SmtpMailClient();
            }
            return instance;
        }

        public void sendEmail(String email, String content)
        {
            if (!sentMails.ContainsKey(email))
            {
                sentMails[email]= new List<String>();
            }
            sentMails[email].Add(content);
        }

        public List<String> getMails(String email)
        {
            return sentMails[email];
        }
    }
}
