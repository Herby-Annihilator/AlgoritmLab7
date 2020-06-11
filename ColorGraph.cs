using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorGraph
{
    /// <summary>
    /// Цветной граф
    /// </summary>
    public class ColorGraph
    {
        private bool[] bannedVerties;
        /// <summary>
        /// Матрица смежности
        /// </summary>
        private int[][] adjacencyMatrix;
        /// <summary>
        /// Список для хранения списков независимых множеств
        /// </summary>
        public List<List<int>> IndependentSets { get; private set; }
        /// <summary>
        /// Цветные коробки, содержащие банки с краской
        /// </summary>
        public ColorBox[] ColorBoxes { get; private set; }

        public ColorGraph(int[][] adjacencyMatrix, ColorBox[] colorBoxes)
        {
            this.adjacencyMatrix = adjacencyMatrix;
            ColorBoxes = colorBoxes;
            VertexCount = adjacencyMatrix.GetLength(0);
            bannedVerties = new bool[VertexCount];
            IndependentSets = new List<List<int>>();
        }
        /// <summary>
        /// Возвращает список вершин, не смежных данной вершине
        /// </summary>
        /// <param name="currentVertex">вершина, для которой ищутся несмженые</param>
        /// <returns></returns>
        public List<int> GetNonAdjacentPeaks(int currentVertex)
        {
            List<int> toReturn = new List<int>();
            if (currentVertex < 1 || currentVertex >= VertexCount)
            {
                toReturn = null;
            }
            else
            {
                for (int i = 0; i < VertexCount; i++)
                {
                    if (!bannedVerties[i])
                    {
                        if (adjacencyMatrix[currentVertex][i] == 0 && i != currentVertex)
                        {
                            toReturn.Add(i);
                        }
                    }
                }
            }
            return toReturn;
        }
        /// <summary>
        /// Число вершин в графе
        /// </summary>
        public int VertexCount { get; private set; }
        /// <summary>
        /// Корректирует список независимых вершин - выделяет из него уже независимое множество
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<int> CorrectNonAdjacentPeaks(List<int> list)
        {
            int[] visited = new int[list.Count];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = -1;
            }
            // начинать я буду с первой вершины 
            visited[0] = list[0];
            int k = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                list = ExcludeAdjacentToCurrent(k, list);
                //
                // нужно выбрать следующую вершину для сравнения
                //
                for (int j = 0; j < visited.Length; j++)
                {
                    bool chosen = false;
                    for (int d = 0; d < list.Count; d++)
                    {
                        // если вершина еще не была посещена
                        if (list[d] != visited[j])
                        {
                            // ее нужно занести в массив посещенных вершин
                            for (int g = 0; g < visited.Length; g++)
                            {
                                if (visited[g] == -1)
                                {
                                    visited[g] = list[d];
                                    k = list[d];
                                    break;
                                }
                            }
                            chosen = true;
                        }
                    }
                    if (chosen)
                    {
                        break;
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Исключает из списка вершины, смежные с данной. Данная вершина также должна находиться в этом списке.
        /// </summary>
        /// <param name="currentVertex">текущая вершина</param>
        /// <param name="list">список вершин-кандидатов на независимость</param>
        /// <returns></returns>
        private List<int> ExcludeAdjacentToCurrent(int currentVertex, List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != currentVertex)
                {
                    // если вершины смежные
                    if (adjacencyMatrix[currentVertex][list[i]] > 0)
                    {
                        // если степень текущей вершины меньше или равна степени другой вершины
                        if (VertexDegree(currentVertex) <= VertexDegree(list[i]))
                        {
                            // то нужно удалить другую вершину из списка
                            list.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            // нужно удалить саму текущую вершину
                            list.Remove(currentVertex);
                            break;
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Вычисляет степень вершины
        /// </summary>
        /// <param name="vertexNumber">вершина, для которой нужно вычислить степень</param>
        /// <returns></returns>
        public int VertexDegree(int vertexNumber)
        {
            int degree = 0;
            for (int i = 0; i < VertexCount; i++)
            {
                if (adjacencyMatrix[vertexNumber][i] > 0)
                {
                    degree++;
                }
            }
            return degree;
        }
        /// <summary>
        /// Вносит вершины, подлежащие удалению в массив (булевый) забаненных вершин
        /// </summary>
        /// <param name="veretexsToDelete"></param>
        public void DeleteVertexs(List<int> veretexsToDelete)
        {
            //for (int i = 0; i < veretexsToDelete.Count; i++)
            //{
            //    for (int j = 0; j < VertexCount; j++)
            //    {
            //        adjacencyMatrix[veretexsToDelete[i]][j] = 0;
            //        adjacencyMatrix[j][veretexsToDelete[i]] = 0; 
            //    }
            //}

            for (int i = 0; i < veretexsToDelete.Count; i++)
            {
                bannedVerties[veretexsToDelete[i]] = true;
            }
        }
    }
}
