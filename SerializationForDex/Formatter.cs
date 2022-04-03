using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SerializationForDex.Machines;
using System.IO;

namespace SerializationForDex
{
    /// <summary>
    /// Форматор. Тут происходит сериализация и десериализация с последующей записью\выводом из файла.
    /// </summary>
    class Formatter
    {
        public event EventHandler<string> Notify;

        /// <summary>
        /// Делегирование события
        /// </summary>
        /// <param name="message">Сообщение</param>
        private void CallingNotify(string message)
        {
            EventHandler<string> notifyHandler = Notify;
            notifyHandler?.Invoke(this, message);
        }

        /// <summary>
        /// Сериализация и запись json в файл 
        /// </summary>
        /// <param name="car">Объект автомобиля для сериализации и дальнейшей записи в файл</param>
        public void SerializeAndWriteOnFile(Car car)
        {
            string jsonFormatOfCar = JsonConvert.SerializeObject(car);
            CallingNotify($"Объект сериализован. \n {jsonFormatOfCar}");

            using (FileStream fs = new FileStream("jsonCar.txt", FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(jsonFormatOfCar);

                fs.Write(buffer, 0, buffer.Length);

                CallingNotify("Сериализованный объект записан в файл.");
            }

        }

        /// <summary>
        /// Вывод данных из файла и последующая его десериализация
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns></returns>
        public Car DeserializeAndOutputFromFile(string path = "jsonCar.txt")
        {
            Car car;
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] buffer = new byte[fs.Length];

                fs.Read(buffer, 0, buffer.Length);

                string jsonFormatOfCar = Encoding.Default.GetString(buffer);
                CallingNotify($"Объект был считан. \n {jsonFormatOfCar}");
                car = JsonConvert.DeserializeObject<Car>(jsonFormatOfCar);
                CallingNotify("Объект был десериализован.");
            }
            return car;
        }
    }
}
