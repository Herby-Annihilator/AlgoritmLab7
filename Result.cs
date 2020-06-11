using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorGraph
{
    public static class Result
    {
        public static List<int> Verties { get; set; } = new List<int>();

        public static List<int> ColorIndex { get; set; } = new List<int>();

        public static string[] GetResult()
        {
            string[] result = new string[Verties.Count + 1];
            result[0] = "Вершина\t\t" + "Цвет\n\r";
            for (int i = 0; i < Verties.Count; i++)
            {
                result[i + 1] = Verties[i] + "\t\t" + ColorIndex[i] + "\n\r";
            }
            return result;
        }
    }
}
