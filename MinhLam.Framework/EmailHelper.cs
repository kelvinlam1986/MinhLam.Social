using System.Net.Mail;

namespace MinhLam.Framework
{
    public static class EmailHelper
    {
        public static void SendEmail(
            string from, 
            string to, 
            string cc, 
            string bcc, 
            string subject, 
            string message)
        {
            MailMessage mm = new MailMessage(from, to);
            if (!string.IsNullOrEmpty(cc))
                mm.CC.Add(cc);

            if (!string.IsNullOrEmpty(bcc))
                mm.Bcc.Add(bcc);

            mm.Subject = subject;
            mm.Body = message;
            mm.IsBodyHtml = true;

            Send(mm);
        }

        public static void SendEmail(string from, string[] to, string[] cc, string[] bcc, string subject, string message)
        {
            MailMessage mm = new MailMessage();
            foreach (string t in to)
            {
                mm.To.Add(t);
            }
            foreach (string c in cc)
            {
                mm.CC.Add(c);
            }
            foreach (string b in bcc)
            {
                mm.Bcc.Add(b);
            }
            mm.From = new MailAddress(from);
            mm.Subject = subject;
            mm.Body = message;
            mm.IsBodyHtml = true;

            Send(mm);
        }

        public static void SendIndividualEmailsPerRecipient(string from, string[] to, string subject, string message)
        {
            foreach (string t in to)
            {
                MailMessage mm = new MailMessage(from, t);
                mm.Subject = subject;
                mm.Body = message;
                mm.IsBodyHtml = true;

                Send(mm);
            }
        }

        private static void Send(MailMessage Message)
        {
            //During developement we will not be sending mails
#if !DEBUG
            SmtpClient smtp = new SmtpClient();
            smtp.Send(Message);
#endif
        }
    }
}
