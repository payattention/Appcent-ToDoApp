using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.Domain.BaseModels;
using ToDoApp.Domain.UserToDoModels;

namespace ToDoApp.Repository
{
    public class UserCouchbaseRepository : IUserCouchbaseRepository
    {
        private readonly IBucket _bucket;
        private readonly IConfiguration _configuration;

        public UserCouchbaseRepository(IBucketProvider bucketProvider, IConfiguration configuration)
        {
            _bucket = bucketProvider.GetBucket("UserToDo"); // Confige atarsın sonra.
            _configuration = configuration;
        }

        public async Task<ResponseBase<RegisterToDoResEntityModel>> Register(RegisterToDoReqEntityModel request)
        {
            string username = request.UserName;
            var response = new ResponseBase<RegisterToDoResEntityModel>();

            if (UserExists(username))
            {
                throw new Exception($"Username '{username}' already exists");
            }
            else
            {
                var result = await CreateUser(username, request.Password, request.Email);

                var token = CreateToken(username, request.Email);

                if (result.Success)
                {
                    response.Data = new RegisterToDoResEntityModel()
                    {
                        Token = token,
                        isRegisterCompleted = true
                    };
                    response.Success = true;
                    return response;
                }
                else
                {
                    throw new Exception("Register failed.");
                }
            }

            
            
        }

        public async Task<ResponseBase<LoginToDoResEntityModel>> Login(LoginToDoReqEntityModel request)
        {
            var response = new ResponseBase<LoginToDoResEntityModel>();
            var user = await GetAndAuthenticateUser(request.UserName, request.Password);
            if (user == null)
            {
                throw new Exception("Invalid username / password");
            }
            else
            {
                response.Success = true;
            }

            var data = new
            {
                token = CreateToken(user.Email, user.Username),

            };

            response.Data = new LoginToDoResEntityModel() 
            { 
                Token = data.token 
            };

            return response;
        }

        public string CreateToken(string username, string email)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim (ClaimTypes.NameIdentifier, email),
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool UserExists(string username)
        {
            var result =  _bucket.Exists($"user::{username}");
            return result;
        }

        public async Task<ResponseBase<User>> CreateUser(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = CalculateMd5Hash(password),
                Email = email
            };

            var response = new ResponseBase<User>();
            response.Data = user;
            try
            {
                var result = await _bucket.InsertAsync($"user::{username}", user);
                response.Success = result.Success;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return response;
        }

        private static string CalculateMd5Hash(string password)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return string.Concat(bytes.Select(x => x.ToString("x2")));
            }
        }

        public async Task<User> GetAndAuthenticateUser(string username, string password)
        {
            var result = await _bucket.GetAsync<User>($"user::{username}");
            if (result.Value.Username == null)
            {
                Console.WriteLine("User not found!");
                return null;
            }

            if (result.Value.Password != CalculateMd5Hash(password))
            {
                Console.WriteLine("User password wrong");
                return null;
            }

            return result.Value;
        }
    }
}
