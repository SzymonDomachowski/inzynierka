using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    public interface IInstagramService
    {
        Task<Account> GetAccountAsync(string accessToken);
    }

    public class InstagramService : IInstagramService
    {
        private readonly IInstagramClient _instagramClient;

        public InstagramService(IInstagramClient instagramClient)
        {
            _instagramClient = instagramClient;
        }

        public async Task<Account> GetAccountAsync(string accessToken)
        {
            var result = await _instagramClient.GetAsync<dynamic>(accessToken, "users/self");

            if (result == null)
            {
                return new Account();
            }

            var account = new Account
            {
                Id = result.data.id,
                FanCount = result.data.counts.followed_by
            };

            return account;
        }
    }
}
