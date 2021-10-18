using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Amazon;
using Amazon.Runtime;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using Amazon.DynamoDBv2;
using System.Configuration;

namespace Lab2
{
    class DDBOperations
    {
        AmazonDynamoDBClient client;
        string tableName = "UserTable";
        Table userTable;
        Bookshelf bookshelf = new Bookshelf();

        public DDBOperations()
        {
            var accessKeyID = ConfigurationManager.AppSettings["accessId"];
            var secretKey = ConfigurationManager.AppSettings["secretKey"];

            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);
            client = new AmazonDynamoDBClient(credentials, Amazon.RegionEndpoint.USEast1);
        }

        public DDBOperations(string tableName)
        {
            var accessKeyID = ConfigurationManager.AppSettings["accessId"];
            var secretKey = ConfigurationManager.AppSettings["secretKey"];

            var credentials = new BasicAWSCredentials(accessKeyID, secretKey);
            client = new AmazonDynamoDBClient(credentials, Amazon.RegionEndpoint.USEast1);
            userTable = Table.LoadTable(client, tableName, DynamoDBEntryConversion.V2);
        }

        public async void CreateTable()
        {
            CreateTableRequest request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition
                    {
                        AttributeName = "UserName",
                        AttributeType = "S"
                    },
                    new AttributeDefinition
                    {
                        AttributeName = "Password",
                        AttributeType = "S"
                    }
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName = "UserName",
                        KeyType = "HASH"
                    },
                    new KeySchemaElement
                    {
                        AttributeName = "Password",
                        KeyType = "RANGE"
                    }
                },
                BillingMode = BillingMode.PROVISIONED,
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 10,
                    WriteCapacityUnits = 10
                }
            };
            var response = await client.CreateTableAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Table created successfully");
            }

        }

        public  void InsertItem(string username, string password)
        {
            PutItemRequest request = new PutItemRequest
            {
                TableName = tableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "UserName", new AttributeValue { S = username } },
                    { "Password", new AttributeValue { S = password } }
                }
            };
            var response =   client.PutItemAsync(request);
            if (response.Result.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Item added successfully");
            }

            }

        public bool ValidateUser(string username, string password)
        {
            GetItemRequest request = new GetItemRequest()
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserName", new AttributeValue { S = username } },
                    { "Password", new AttributeValue { S = password } }
                },
            };
           var response = client.GetItemAsync(request).Result;
                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK && response.Item.Count > 0)
                {
                    return true;
                }
            return false;

        }

        public void GetBookList(string username)
        {
            bookshelf.Books = new Dictionary<string, int>();
            bookshelf.User = username;
            GetItemRequest request = new GetItemRequest
            {
                TableName = userTable.TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserName", new AttributeValue { S = username } }
                },
            };
            try
            {
                var response = client.GetItemAsync(request);
                if (response.Result.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    var item = response.Result.Item;
                    var books = item.FirstOrDefault(v => v.Key == "Books").Value.L;
                    var list = books.Select(b => b.SS);
                    foreach (var val in list)
                    {
                        bookshelf.Books.Add(val[1], Convert.ToInt32(val[0]));
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public Bookshelf getUserBookshelf(string username)
        {
            GetBookList(username);
            return bookshelf;
        }

        public void updateLastReadPage(string username, string bookname, int pageNumber)
        {
            bookshelf.Books = new Dictionary<string, int>();
            GetItemRequest request = new GetItemRequest
            {
                TableName = userTable.TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserName", new AttributeValue { S = username } }
                },
            };
            try
            {
                Document doc = new Document();
                var response = client.GetItemAsync(request);
                if (response.Result.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    var item = response.Result.Item;
                    var books = item.FirstOrDefault(v => v.Key == "Books").Value.L;
                    var list = books.Select(b => b.SS);
                    foreach (var val in list)
                    {
                        if (!val[1].Equals(bookname))
                            bookshelf.Books.Add(val[1], Convert.ToInt32(val[0]));
                    }
                    List<AttributeValue> lst = new List<AttributeValue>();
                    foreach (var val in bookshelf.Books)
                    {
                        lst.Add(new AttributeValue() { SS = { val.Key, val.Value.ToString() } });
                    }
                    lst.Add(new AttributeValue()
                    {
                        SS = { pageNumber.ToString(), bookname }
                    });
                    var req = new UpdateItemRequest()
                    {
                        TableName = userTable.TableName,
                        Key = new Dictionary<string, AttributeValue>
                        {
                            { "UserName", new AttributeValue { S = username } }
                        },
                        ExpressionAttributeNames = new Dictionary<string, string>()
                        {
                            {"#b", "Books"}
                        },
                        ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                        {
                            {":newbook", new AttributeValue()
                            {
                                L = lst
                            } }
                        },
                        UpdateExpression = "SET #b = :newbook"
                    };

                    var result = client.UpdateItemAsync(req).Result;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}