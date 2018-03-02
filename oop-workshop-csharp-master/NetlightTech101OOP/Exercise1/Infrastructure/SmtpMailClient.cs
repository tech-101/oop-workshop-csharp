using System;
using System.Collections.Generic;
using System.Collections;

namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise1.Infrastructure
{
    public class SmtpMailClient
    {
        private static SmtpMailClient instance;

        private Dictionary<String, ArrayList> sentMails = new Dictionary<String, ArrayList>();

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
                sentMails[email]= new ArrayList();
            }
            sentMails[email].Add(content);
        }

        public ArrayList getMails(String email)
        {
            return sentMails[email];
        }
    }
}
