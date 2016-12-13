using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace SendGridScratch
{
    public class SendGridMessage
    {
        private readonly List<EmailAddress> theRecipients = new List<EmailAddress>();

        public EmailAddress From { get; set; }

        public HtmlContent HtmlContent { get; set; }

        public TextContent PlainTextContent { get; set; }

        public MailPriority Priority { get; set; }

        public IEnumerable<EmailAddress> Recipients => theRecipients;

        public string Subject { get; set; }

        public List<EmailAddress> To { get; set; }

        public void AddAttachment(EmailAttachment anAttachment) {
            throw new NotImplementedException();
        }

        public void AddRecipient(EmailAddress anEmailAddress) {
            theRecipients.Add(anEmailAddress);
        }

        public void AddRecipients(IEnumerable<EmailAddress> someEmailAddresses) {
            theRecipients.AddRange(someEmailAddresses);
        }
    }

    public class HtmlContent
    {
        private string theContent;

        public HtmlContent(string aContent) {
            theContent = aContent;
        }
    }

    public class TextContent
    {
        private string theContent;

        public TextContent(string aContent) {
            theContent = aContent;
        }
    }
}