using System;
using System.Collections.Generic;
using WebApplication.Models;

/// <summary>
/// Неймспейс веба.
/// </summary>
namespace WebApplication
{
    /// <summary>
    /// Класс генерации.
    /// </summary>
    public static class Generation
    {
        /// <summary>
        /// Рандомайзер.
        /// </summary>
        private static Random randomizer = new Random();

        /// <summary>
        /// Константное кол-во юзеров.
        /// </summary>
        private const int usersCount = 10;

        /// <summary>
        /// БД имён.
        /// </summary>
        private static Dictionary<int, string> usernames = new Dictionary<int, string> {
            { 1, "Fedya" }, { 2, "Oleg" }, { 3, "Victor" }, { 4, "Andrey" }, { 5, "Artem" },
            { 6, "Misha" }, { 7, "Gleb" }, { 8, "Vyacheslav" }, { 9, "Kirill" },{ 10, "Sergey" },
            { 11, "Petr" }, { 12, "Ilya" }, { 13, "Maksim" }, { 14, "Aleksei" }, { 15, "Robert" },
            { 16, "Julia" }, { 17, "Valeria" }, { 18, "Evelina" }, { 19, "Sofia" }, { 20, "Ksenia" },
            { 21, "Olga" }, { 22, "Alena" }, { 23, "Maria" }, { 24, "Polina" }, { 25, "Diana" },
            { 26, "Milena" }, { 27, "Victoria" }, { 28, "Alisa" }, { 29, "Karina" }, { 30, "Elizaveta" },
        };

        /// <summary>
        /// БД доменов.
        /// </summary>
        private static Dictionary<int, string> domens = new Dictionary<int, string> {
            { 1, "yandex.ru" }, { 2, "gmail.com" }, { 3, "mail.ru" }, { 4, "outlook.com" }, { 5, "hse.ru" }
        };

        /// <summary>
        /// БД заглавий.
        /// </summary>
        private static Dictionary<int, string> subjects = new Dictionary<int, string> {
            {1, "My Life" }, { 2, "Reminder" }, { 3, "Secret recipes" }, { 4, "Traveling" }, { 5, "Interview" }
        };

        /// <summary>
        /// БД сообщений.
        /// </summary>
        private static Dictionary<int, string> messages = new Dictionary<int, string> {
            { 1, "KEK :P" },
            { 2, "LOL xD"},
            { 3, "give me back my 2007... :,(" },
            { 4, "Do you wanna anekdot? >:)" },
            { 5, "Look at me, I'm chereshnya! :З" }
        };

        /// <summary>
        /// Генерация юзеров.
        /// </summary>
        /// <returns> Возвращение через yield экземпляров типа User. </returns>
        public static IEnumerable<User> GenerateUsers()
        {
            for (int i = 1; i <= usersCount; i++)
            {
                string generatedName = usernames[randomizer.Next(1, 31)];
                string generatedEmail = $"{generatedName}_{randomizer.Next(1, 1000)}@{domens[randomizer.Next(1, 6)]}";
                yield return new User(generatedName, generatedEmail);
            }
        }

        /// <summary>
        /// Генерация сообщений.
        /// </summary>
        /// <param name="users"> Лист юзеров. </param>
        /// <returns> Возвращение через yield экземпляров типа MessageInfo. </returns>
        public static IEnumerable<MessageInfo> GenerateMessages(List<User> users)
        {
            for (int i = 1; i <= usersCount; i++)
            {
                string subject, message, senderId, receiverId;

                subject = subjects[randomizer.Next(1, 6)];
                message = messages[randomizer.Next(1, 6)];
                senderId = users[randomizer.Next(10)].Email;
                receiverId = users[randomizer.Next(10)].Email;

                yield return new MessageInfo(subject, message, senderId, receiverId);
            }
        }
    }
}