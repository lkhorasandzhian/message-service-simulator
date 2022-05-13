using System;
using System.Runtime.Serialization;

/// <summary>
/// Неймспейс моделей.
/// </summary>
namespace WebApplication.Models
{
    /// <summary>
    /// Класс юзеров.
    /// </summary>
    [DataContract]
    public class User : IComparable<User>
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Почта.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Конструктор для автореализуемых свойств.
        /// </summary>
        /// <param name="userName"> Имя. </param>
        /// <param name="email"> Почта. </param>
        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        /// <summary>
        /// Компоратор для сравнения и сортировки по почтам.
        /// </summary>
        /// <param name="other"> Сравниваемый юзер. </param>
        /// <returns> 1 или 0 или -1. </returns>
        public int CompareTo(User other)
        {
            return this.Email.CompareTo(other.Email);
        }
    }
}