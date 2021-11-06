using Lab3Metflix.Models;
using Amazon.DynamoDBv2;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DataModel;
using System.Threading.Tasks;

namespace Lab3Metflix.Controllers
{
    public class RegisterController : Controller
    {
        private IAmazonDynamoDB _dynamoDBClient;
        private IAmazonS3 _s3Client;

        public RegisterController(IAmazonDynamoDB _dynamoDBClient, IAmazonS3 _s3Client)
        {
            this._dynamoDBClient = _dynamoDBClient;
            this._s3Client = _s3Client;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(Users users)
        {
            if (ModelState.IsValid)
            {
                Users newUsers = RegisterUser(users).Result;
                if (newUsers != null)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View("index");
                }
            }
            else
            {
                return View(users);
            }
        }

        public async Task<Users> RegisterUser(Users Users)
        {
            DynamoDBContext Context = new DynamoDBContext(_dynamoDBClient);
            await Context.SaveAsync(Users);
            Users newUsers = await Context.LoadAsync<Users>(Users.Email);
            return Users;
        }
    }
}
