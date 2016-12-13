using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SendGridScratch
{
    internal class Program
    {
        private static async Task Main(string[] args) {
            SendGridMessage aMessage = new SendGridMessage {
                From = new EmailAddress("test@test.com", "James Brown"),

                //this is nice for property init, but it directly exposes the storage mechanism (List<EmailAddrress>) which some people would frown upon https://en.wikipedia.org/wiki/Law_of_Demeter
                To = {
                    new EmailAddress("somebody@somewhere.com", "Forgot Him"),
                    new EmailAddress("recipient@mail.net", "That Guy"),
                    new EmailAddress("someone@mail.net", "Other Gal")
                },
                Subject = "Free bird",
                PlainTextContent = new TextContent("I like eggs"),
                HtmlContent = new HtmlContent("I <string>really</string> like eggs"),
                Priority = MailPriority.High
            };

            //this protectts that internal list by restricting operations on it to a known method. Could also include RemoveRecipient
            aMessage.AddRecipient(new EmailAddress("somebody@somewhere.com", "Forgot Him"));
            aMessage.AddRecipient(new EmailAddress("recipient@mail.net", "That Guy"));
            aMessage.AddRecipient(new EmailAddress("someone@mail.net", "Other Gal"));

            //OR
            aMessage.AddRecipients(new List<EmailAddress> {
                                       new EmailAddress("somebody@somewhere.com", "Forgot Him"),
                                       new EmailAddress("recipient@mail.net", "That Guy"),
                                       new EmailAddress("someone@mail.net", "Other Gal")
                                   });

            // access to that internal list without the ability to modify it directly
            foreach(EmailAddress aMessageRecipient in aMessage.Recipients) Console.WriteLine($"Sending to {aMessageRecipient.Name} [{aMessageRecipient.Email}]");

            //maybe this
            EmailAttachment anAttachment = SomeAttachmentHelperThing.FromFile(Path.GetFullPath(@"C:\temp\image.jpg"));
            aMessage.AddAttachment(anAttachment);

            //finally, send
            SendGridClient aClient = new SendGridClient("API-KEY-MADNESS");
            SendResult aResult = await aClient.SendAsync(aMessage);

            Console.WriteLine($"Result : {aResult}");
        }
    }
}