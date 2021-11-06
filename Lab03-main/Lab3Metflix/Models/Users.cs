using Amazon.DynamoDBv2.DataModel;


namespace Lab3Metflix.Models
{
    [DynamoDBTable("Users")]
    public class Users
    {
        [DynamoDBHashKey]
        public string Email { get; set; }
        [DynamoDBProperty]
        public string UserName { get; set; }
        [DynamoDBProperty]
        public string Password { get; set; }
    }
}
