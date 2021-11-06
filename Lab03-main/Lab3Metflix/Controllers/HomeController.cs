using Microsoft.AspNetCore.Mvc;
using Lab3Metflix.Models;
using Amazon.DynamoDBv2;
using Amazon.S3;
using System.Threading.Tasks;
using System;
using Amazon.DynamoDBv2.DataModel;

namespace Lab3Metflix.Controllers
{
    public class HomeController : Controller
    {
        private IAmazonDynamoDB _dynamoDBClient;
        private IAmazonS3 _s3Client;

        public HomeController(IAmazonDynamoDB _dynamoDBClient, IAmazonS3 _s3Client)
        {
            this._dynamoDBClient = _dynamoDBClient;
            this._s3Client = _s3Client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string email, string password)
        {
           

            if (!ModelState.IsValid)
                return View();

            Users userFound = FindUserAsync(email, password).Result;

            if (userFound == null)
                return View();
            else
            {
                return RedirectToAction("MovieList", "Movie", new {email});
            }
        }

        private async Task<Users> FindUserAsync (string email, String passowrd)
        {
            DynamoDBContext Context = new DynamoDBContext(_dynamoDBClient);
            Users UsersDB = await Context.LoadAsync<Users>(email);
            if (UsersDB != null)
            {
                if (!(UsersDB.Password.Equals(passowrd)))
                {
                    UsersDB = null;
                }
            }
            return UsersDB;
        }
    }
}
