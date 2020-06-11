using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorGraph
{
    /// <summary>
    /// "Цветная коробка". Содержит в себе некоторое кол-во банок одного цвета
    /// </summary>
    public class ColorBox
    {
        /// <summary>
        /// Цветовой индекс
        /// </summary>
        private int colorIndex;
        /// <summary>
        /// Возвращает цветовой индекс
        /// </summary>
        public int ColorIndex
        {
            get
            {
                return colorIndex;
            }
            private set
            {
                if (value < 0)
                {
                    colorIndex = 1;
                }
                else
                {
                    colorIndex = value;
                }
            }
        }
        /// <summary>
        /// Число банок в коробке
        /// </summary>
        private int countOfCans;
        /// <summary>
        /// Возвращает число банок в коробке
        /// </summary>
        public int CountOfCans
        {
            get
            {
                return countOfCans;
            }
            private set
            {
                if (value > 15)
                {
                    countOfCans = 15;
                }
                else if (value < 1)
                {
                    countOfCans = 1;
                }
                else
                {
                    countOfCans = value;
                }
            }
        }
        /// <summary>
        /// Собирает цветную коробку
        /// </summary>
        /// <param name="colorIndex">цветовой индекс</param>
        /// <param name="countOfCans">число банок в коробке</param>
        public ColorBox(int colorIndex, int countOfCans)
        {
            ColorIndex = colorIndex;
            CountOfCans = countOfCans;
            UsedCans = 0;
            NotUsedCans = CountOfCans;
            isUsed = false;
        }
        /// <summary>
        /// Сколько банок использовано
        /// </summary>
        public int UsedCans { get; set; }
        /// <summary>
        /// Сколько банок не использовано
        /// </summary>
        public int NotUsedCans { get; set; }
        /// <summary>
        /// Был ли данный цвет уже использован
        /// </summary>
        public bool isUsed { get; set; }
    }
}
