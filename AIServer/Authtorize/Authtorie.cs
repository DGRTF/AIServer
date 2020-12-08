﻿using AIServer.DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace AIServer.Authtorize
{
    public class AccountController : Controller
    {
        public AccountController(ApplicationContext context)
        {
            DB = context;
        }

        ApplicationContext DB { get; }

        //    new Person {Login="admin@gmail.com", Password="12345", Role = "admin" },

        [HttpPost("/login")]
        public IActionResult Login(string email, string name, string password)
        {
            User user = this.DB.Users.ToList().FirstOrDefault(x => x.Name == name);

            if(user!=null)
                return BadRequest(new { errorText = "пользователь с таким именем уже существует" });

            User userEmail = this.DB.Users.ToList().FirstOrDefault(x => x.Email == email);


            if (userEmail != null)
                return BadRequest(new { errorText = "пользователь с таким email уже существует" });

            this.DB.Users.Add(new User
            {
                Email = email,
                Password = password,
                Name = name,
            });

            this.DB.SaveChanges();

            return this.Token(name, password);
        }

        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            User person = this.DB.Users.ToList().FirstOrDefault(x => x.Name == username && x.Password == password);

            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Name),
                };

                var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
