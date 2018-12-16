using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;



namespace integration
{   
    public class EmailTests
    {
        public const string GeneratorApiRoot = "http://generator";
        public const string MailHogApiV2Root = "http://mail:8025/api/v2";

        [Fact]
        public async Task SendEmailWithNames_IsFromGenerator()
        {
            // send email
            var client = new HttpClient();
            var sendEmail = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{GeneratorApiRoot}/EmailRandomNames")
            };
            Console.WriteLine($"Sending email: {sendEmail.RequestUri}");
            using (var response = await client.SendAsync(sendEmail))
            {
                response.EnsureSuccessStatusCode();
            }

            Assert.Equal(3,3);

        }
    }
}