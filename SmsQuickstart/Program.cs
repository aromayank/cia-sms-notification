using System;
using System.Collections.Generic;

using Azure;
using Azure.Communication;
using Azure.Communication.Sms;





namespace SmsQuickstart
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // string connectionString = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_CONNECTION_STRING");
            SmsClient smsClient = new SmsClient("endpoint=https://ficosmscomms.communication.azure.com/;accesskey=LdBVbzyD0FR1lFHwO8S3v8Wfvz5nbIfHd1NnHWXSJjmzFJUHCTLULvr43OflvLRHWQehVZ7lkhuLUpUGnsKwLQ==");

            SmsSendResult sendResult = smsClient.Send(
                from: "+18336581924",
                to: "+18569936519",
                message: "Hello Daniel! Please check your score changed from 819 to 820."
            );

            Response<IReadOnlyList<SmsSendResult>> response = smsClient.Send(
                from: "+18336581924",
                to: new string[] { "+18569936519", "+14692473413" },
                message: "Weekly Update - Credit Score Change! Your score changed from 800 to 810.",
                options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                {
                    Tag = "Credit Score", // custom tags
                });

            IEnumerable<SmsSendResult> results = response.Value;

                foreach (SmsSendResult result in results)
                {       
                    Console.WriteLine($"Sms id: {result.MessageId}");
                    Console.WriteLine($"Send Result Successful: {result.Successful}");
                }
        }

       
    }
}
