using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Samuel_Gurara_COMP306_Lab1
{
   public class Config
    {
        public static BasicAWSCredentials config()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

            var accessKeyID = builder.Build().GetSection("AWSCredentials").GetSection("AccesskeyID").Value;
            var secretKey = builder.Build().GetSection("AWSCredentials").GetSection("Secretaccesskey").Value;

            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);
            return credentials;
        }
    }
}
