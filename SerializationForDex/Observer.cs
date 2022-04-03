using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationForDex
{
    /// <summary>
    /// Наблюдатель. Следит за изменениями в объекте форматора. Подписываемся на событие, возникающее в форматоре.
    /// </summary>
    class Observer
    {
        /// <summary>
        /// Подписка на событие форматора.
        /// </summary>
        /// <param name="formatter">Объект форматора</param>
        public Observer(Formatter formatter)
        {
            formatter.Notify += Formatter_Notify;
        }

        /// <summary>
        /// Обработчик события форматора
        /// </summary>
        private void Formatter_Notify(object sender, string e)
        {
            Console.WriteLine("_______________________\n*Оповещается Observer*|");
            Console.WriteLine(e);
        }
    }
}
