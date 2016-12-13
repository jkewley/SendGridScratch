namespace SendGridScratch
{
    public class EmailAddress
    {
        public EmailAddress(string anEmail, string aName) {
            Email = anEmail;
            Name = aName;
        }

        public string Email { get; }

        public string Name { get; }
    }
}