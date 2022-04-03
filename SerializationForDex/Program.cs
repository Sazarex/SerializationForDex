using System;
using SerializationForDex.Machines;

namespace SerializationForDex
{
    class Program
    {
        static void Main(string[] args)
        {

            //Создается объект автомобиля со вложенными объектами других классов (двигатель и шины)
            Car Audi = new Car("Audi RS 3 Sedan", 350, 3.5f, new Engine("T333", 550), new Tire[]
            {
                new Tire("Michelin", Season.Winter),
                new Tire("Michelin", Season.Winter),
                new Tire("Michelin", Season.Winter),
                new Tire("Michelin", Season.Winter)
            });

            //Создается объект, который будет заниматься сериализацией\десериализацией и записью\чтением информации из файла
            Formatter AudiFormatter = new Formatter();

            //Имитация оповещение наблюдателя за действиями в объекте форматора.
            //Какой-либо объект, который подписан на событие, вызывающееся в объекте нашего форматора.
            //Подписываемся на событие форматора через конструктор наблюдателя
            Observer AudiFormatterObserver = new Observer(AudiFormatter);

            //В форматере вызываем сериализацию  и запись в файл объекта автомобиля.
            AudiFormatter.SerializeAndWriteOnFile(Audi);

            //Выводится сериализованная JSON строка из файла и десериализуется в объект.
            Car someonecar = AudiFormatter.DeserializeAndOutputFromFile();

        }
    }
}
