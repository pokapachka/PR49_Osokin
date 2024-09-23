﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using ПР49_Осокин.Models;

namespace ПР49_Осокин.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="Email">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <param name="Token">Токен пользователя</param>
        /// <returns>Данный метод преднозначен для авторизации пользователя на сайте</returns>
        /// <response code="200">Пользователь успешно авторизован</response>
        /// <response code="400">Проблема аутентификации</response>
        /// <response code="401">Пользователь не найден</response>
        [Route("SingIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult SingIn([FromForm] string Email, [FromForm] string Password, [FromForm] string Token)
        {
            if (Email == null || Password == null || Token == null) return StatusCode(400);
            try
            {
                Users User = new UsersContext().Users.First(x => x.Email == Email && x.Password == Password && x.Token == Token);
                return Json(User.Token);
            }
            catch
            {
                return StatusCode(401);
            }
        }
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="Email">Почта</param>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <param name="Token">Токен уже зарегистрированного пользователя</param>
        /// <returns>Данный метод предназначен для регистрации пользователя на сайте</returns>
        /// <response code="200">Успешная регистрация</response>
        /// <response code="400">Проблемы при регистрации</response>
        [Route("RegIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(400)]
        public ActionResult RegIn([FromForm] string Email, [FromForm] string Login, [FromForm] string Password, [FromForm] string Token)
        {
            if (Login == null || Password == null) return StatusCode(403);
            try
            {
                var newUser = new UsersContext();
                if (newUser.Users.FirstOrDefault(x => x.Email == Email && x.Login == Login && x.Password == Password) != null) return StatusCode(400);
                if (newUser.Users.FirstOrDefault(x => x.Token == Token) == null) return StatusCode(400, "Такого токена нету!");
                else
                {
                    Users User = new Users()
                    {
                        Email = Email,
                        Login = Login,
                        Password = Password,
                        Token = GenerateToken()
                    };
                    newUser.Users.Add(User);
                    newUser.SaveChanges();
                    return Json(newUser);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public static string GenerateToken()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, 16).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
