using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Instagram
{
    public class Program
    {
        static void Main(string[] args)
        {
            var instagramClient = new InstagramClient();
            var facebookService = new InstagramService(instagramClient);
            int counter = 0;

            while (true)
            {
                var getAccountTask = facebookService.GetAccountAsync(InstagramSettings.AccessToken);
                Task.WaitAll(getAccountTask);
                var account = getAccountTask.Result;

                Task.WaitAll(getAccountTask);

                Console.WriteLine($"ID: {account.Id}");
                Console.WriteLine($"Instagram followers: {account.FanCount}");

                counter++;
                Console.WriteLine($"{counter}\n");

                Thread.Sleep(7200);

            }
        }
    }
}
