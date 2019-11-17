using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WebApplication1
{
    public class TextMe
    {
        public static string TextMe()
        {
            CreateHostBuilder(args).Build().Run();
            const string accountSid = "AC4f54eb4222d9f49b3f4a6027dce174f0";
            const string authToken = "efde166ec6bb019dabd1d37c7346fc37";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "This is the ship that made the Kessel Run in fourteen parsecs?",
                from: new Twilio.Types.PhoneNumber("+16476274247"),
                to: new Twilio.Types.PhoneNumber("+16476274247")
            );

            Console.WriteLine(message.Sid);
            return message.Sid;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            const string accountSid = "AC4f54eb4222d9f49b3f4a6027dce174f0";
            const string authToken = "efde166ec6bb019dabd1d37c7346fc37";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "This is the ship that made the Kessel Run in fourteen parsecs?",
                from: new Twilio.Types.PhoneNumber("+16476274247"),
                to: new Twilio.Types.PhoneNumber("+16476274247")
            );

            Console.WriteLine(message.Sid);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
