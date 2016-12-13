using System.Threading.Tasks;

namespace SendGridScratch
{
    public class SendGridClient
    {
        private readonly string theAPIKey;

        public SendGridClient(string anAPIKey) {
            theAPIKey = anAPIKey;
        }

        public async Task<SendResult> SendAsync(SendGridMessage aMessage) {
            return await Task.FromResult(SendResult.GreatSuccess);
        }
    }

    public enum SendResult
    {
        GreatSuccess,
        OhDear
    }
}