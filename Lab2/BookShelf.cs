using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    
        [DynamoDBTable("Bookshelf")]
        public class Bookshelf
        {
            [DynamoDBProperty("UserName")]
            public string User { get; set; }

            [DynamoDBProperty("Books")]
            public Dictionary<string, int> Books { get; set; }
        }
}
