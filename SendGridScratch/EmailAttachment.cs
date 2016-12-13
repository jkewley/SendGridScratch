using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace SendGridScratch
{
    public class EmailAttachment : Attachment //lazy
    {
        public EmailAttachment(string fileName) : base(fileName) {}

        public EmailAttachment(string fileName, string mediaType) : base(fileName, mediaType) {}

        public EmailAttachment(string fileName, ContentType contentType) : base(fileName, contentType) {}

        public EmailAttachment(Stream contentStream, string name) : base(contentStream, name) {}

        public EmailAttachment(Stream contentStream, string name, string mediaType) : base(contentStream, name, mediaType) {}

        public EmailAttachment(Stream contentStream, ContentType contentType) : base(contentStream, contentType) {}
    }
}