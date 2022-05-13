using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using WebApplication.Models;

/// <summary>
/// Неймспейс веба.
/// </summary>
namespace WebApplication
{
    /// <summary>
    /// Статический класс для работы с файлами.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Пересоздать JSON-файл.
        /// </summary>
        /// <param name="users"> Лист юзеров. </param>
        /// <param name="messages"> Лист сообщений. </param>
        /// <returns> Статус-код. </returns>
        public static int RemakeJSON(List<User> users, List<MessageInfo> messages)
        {
            try
            {
                var serializer1 = new DataContractJsonSerializer(typeof(List<User>));

                using (FileStream fs = new($"..{Path.DirectorySeparatorChar}users_list.json", FileMode.Create))
                    serializer1.WriteObject(fs, users);

                var serializer2 = new DataContractJsonSerializer(typeof(List<MessageInfo>));

                using (FileStream fs = new($"..{Path.DirectorySeparatorChar}messages_list.json", FileMode.Create))
                    serializer2.WriteObject(fs, messages);

                users.Sort();  // Сортировка через определённый в типе компоратор по Email.

                return 200;
            }
            catch (System.Exception)
            {
                return 400;
            }
        }

        /// <summary>
        /// Считать данные из JSON-файла.
        /// </summary>
        /// <returns> Статус-код. </returns>
        public static (int, List<User>, List<MessageInfo>) ReadFromJSON()
        {
            try
            {
                var deserializer1 = new DataContractJsonSerializer(typeof(List<User>));

                List<User> users;

                using (FileStream fs = new($"..{Path.DirectorySeparatorChar}users_list.json", FileMode.Open))
                    users = deserializer1.ReadObject(fs) as List<User>;

                var deserializer2 = new DataContractJsonSerializer(typeof(List<MessageInfo>));

                List<MessageInfo> messages;

                using (FileStream fs = new($"..{Path.DirectorySeparatorChar}messages_list.json", FileMode.Open))
                    messages = deserializer2.ReadObject(fs) as List<MessageInfo>;

                users.Sort();  // Сортировка через определённый в типе компоратор по Email.

                return (200, users, messages);
            }
            catch (System.Exception)
            {
                return (404, null, null);
            }
        }
    }
}
