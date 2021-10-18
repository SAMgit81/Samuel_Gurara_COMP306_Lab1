using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samuel_Gurara_Lab2_AmazonDynamoDB
{
    
        [DynamoDBTable("Bookshelf")]
        public class Shelf
        {
            [DynamoDBProperty("UserName")]
            public string User { get; set; }

            [DynamoDBProperty("Books")]
            public Dictionary<string, int> Books { get; set; }
        }
}
