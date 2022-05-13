using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Models;

/// <summary>
/// Неймспейс контроллеров.
/// </summary>
namespace WebApplication.Controllers
{
    /// <summary>
    /// Юзерский контроллер.
    /// </summary>
    [Route("[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Список юзеров.
        /// </summary>
        private List<User> users = new List<User>();

        /// <summary>
        /// Список сообщений.
        /// </summary>
        private List<MessageInfo> messages = new List<MessageInfo>();

        /// <summary>
        /// Радномная генерация.
        /// </summary>
        /// <returns> Статус код и лист юзеров. </returns>
        [HttpPost("GenerateUsers&MessagesByRandom(2)")]
        public IActionResult Post()
        {
            users.AddRange(Generation.GenerateUsers());
            messages.AddRange(Generation.GenerateMessages(users));
            int code = FileManager.RemakeJSON(users, messages);
            return StatusCode(code, users);
        }

        /// <summary>
        /// Искать инфу по имейлу.
        /// </summary>
        /// <param name="email"> Имейл. </param>
        /// <returns> Статус-код и инфа. </returns>
        [HttpGet("ViewInfoByEmail(3a)")]
        public IActionResult GetInfoByEmail(string email)
        {
            if (email == null)
                return StatusCode(404);

            int code;

            (code, users, messages) = FileManager.ReadFromJSON();

            if (code == 404)
            {
                return StatusCode(code);
            }

            var sb = new StringBuilder();

            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    sb.Append($"{user.UserName}'s MailBox" + Environment.NewLine);
                    break;
                }
            }

            if (sb.ToString() == string.Empty)
                return StatusCode(400);

            foreach (var info in messages)
            {
                if (info.SenderId == email)
                {
                    sb.Append($"Receiver: {info.ReceiverId}, Subject: {info.Subject}, Message: {info.Message}\n");
                }
            }
            string mystring = sb.ToString();

            if (mystring == string.Empty)
                return Ok("No messages yet...");

            return StatusCode(code, mystring);
        }

        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        /// <returns> Список пользователей. </returns>
        [HttpGet("ViewUserList(3b)")]
        public IActionResult GetUserList()
        {
            int code;
            (code, users, messages) = FileManager.ReadFromJSON();
            return StatusCode(code, users);
        }

        /// <summary>
        /// Получить все сообщения между двумя юзерами.
        /// </summary>
        /// <param name="senderEmail"> Отправитель. </param>
        /// <param name="receiverEmail"> Получатель. </param>
        /// <returns> Статус-код и сообщения. </returns>
        [HttpGet("ViewAllMessagesBetweenTwoUsers(4)/{senderEmail}:{receiverEmail}")]
        public IActionResult GetMessagesBetween(string senderEmail, string receiverEmail)
        {
            int code;
            (code, users, messages) = FileManager.ReadFromJSON();

            if (code == 404)
                return StatusCode(code);

            var sb = new StringBuilder();

            foreach (var info in messages)
            {
                if (info.SenderId == senderEmail && info.ReceiverId == receiverEmail)
                    sb.Append(info.Message + Environment.NewLine);
            }

            string mystring = sb.ToString();

            if (mystring == string.Empty)
                return Ok("No messages yet...");

            return StatusCode(code, mystring);
        }

        /// <summary>
        /// Получить все сообщения от отправителя.
        /// </summary>
        /// <param name="senderEmail"> Отправитель. </param>
        /// <returns> Статус-код и сообщения. </returns>
        [HttpGet("ViewAllMessagesBySender(5a)/{senderEmail}")]
        public IActionResult GetMessagesSender([FromRoute] string senderEmail)
        {
            int code;
            (code, users, messages) = FileManager.ReadFromJSON();

            if (code == 404)
                return StatusCode(code);

            var sb = new StringBuilder();

            foreach (var info in messages)
            {
                if (info.SenderId == senderEmail)
                    sb.Append(info.Message + Environment.NewLine);
            }

            string mystring = sb.ToString();

            if (mystring == string.Empty)
                return Ok("No messages yet...");

            return StatusCode(code, mystring);
        }

        /// <summary>
        /// Получитель все сообщения для получателя.
        /// </summary>
        /// <param name="receiverEmail"> Получатель. </param>
        /// <returns> Статус-код и сообщения. </returns>
        [HttpGet("ViewAllMessagesByReceiver(5b)/{receiverEmail}")]
        public IActionResult GetMessagesReceiver([FromRoute] string receiverEmail)
        {
            int code;
            (code, users, messages) = FileManager.ReadFromJSON();

            if (code == 404)
                return StatusCode(code);

            var sb = new StringBuilder();

            foreach (var info in messages)
            {
                if (info.ReceiverId == receiverEmail)
                    sb.Append(info.Message + Environment.NewLine);
            }

            string mystring = sb.ToString();

            if (mystring == string.Empty)
                return Ok("No messages yet...");

            return StatusCode(code, mystring);
        }
    }
}