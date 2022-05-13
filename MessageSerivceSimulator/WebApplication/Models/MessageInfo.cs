using System.Runtime.Serialization;

/// <summary>
/// Неймспейс моделей.
/// </summary>
namespace WebApplication.Models
{
    /// <summary>
    /// Класс сообщений.
    /// </summary>
    [DataContract]
    public class MessageInfo
    {
        /// <summary>
        /// Заглавие.
        /// </summary>
        [DataMember]
        public string Subject { get; set; }

        /// <summary>
        /// Сообщение.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Отправитель.
        /// </summary>
        [DataMember]
        public string SenderId { get; set; }

        /// <summary>
        /// Получатель.
        /// </summary>
        [DataMember]
        public string ReceiverId { get; set; }

        /// <summary>
        /// Конструктор для автореализуемых свойств.
        /// </summary>
        /// <param name="subject"> Заглавие. </param>
        /// <param name="message"> Сообщение. </param>
        /// <param name="senderId"> Отправитель. </param>
        /// <param name="receiverId"> Получатель. </param>
        public MessageInfo(string subject, string message, string senderId, string receiverId)
        {
            Subject = subject;
            Message = message;
            SenderId = senderId;
            ReceiverId = receiverId;
        }
    }
}