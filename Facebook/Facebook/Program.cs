using System;
using System.Threading;
using System.Threading.Tasks;

namespace Facebook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var facebookClient = new FacebookClient();
            var facebookService = new FacebookService(facebookClient);
            int counter=0;

            while (true)
            {
                var getAccountTask = facebookService.GetAccountAsync(FacebookSettings.AccessToken);
                Task.WaitAll(getAccountTask);
                var account = getAccountTask.Result;

                Task.WaitAll(getAccountTask);

                Console.WriteLine($"ID strony: {account.Id} \nLiczba Lajkow: {account.FanCount} \nLiczba Powiadomien:{account.UnreadNotifications}");
                Console.WriteLine($"Liczba wiadomosci: {account.UnreadMessenges} \nLiczba Ocen: {account.NumberOfRatings}");

                counter++;
                Console.WriteLine(counter);
                Console.WriteLine("\n");
                Thread.Sleep(1500);
                
            }
        }
    }    
}
