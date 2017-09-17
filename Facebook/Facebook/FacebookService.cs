using System.Threading.Tasks;

namespace Facebook
{
    public interface IFacebookService
    {
        Task<Account> GetAccountAsync(string accessToken);
        Task PostOnWallAsync(string accessToken, string message);
    }

    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task<Account> GetAccountAsync(string accessToken)
        {
            var result = await _facebookClient.GetAsync<dynamic>(accessToken, "me", "fields=id,fan_count,unread_notif_count,rating_count,unread_message_count");

            if (result == null)
            {
                return new Account();
            }

            var account = new Account
            {
                Id = result.id,
                FanCount = result.fan_count,
                UnreadNotifications = result.unread_notif_count,
                UnreadMessenges = result.unread_message_count,
                NumberOfRatings = result.rating_count
            };

            return account;
        }

        public async Task PostOnWallAsync(string accessToken, string message)
            => await _facebookClient.PostAsync(accessToken, "me/feed", new {message});
    }  
}