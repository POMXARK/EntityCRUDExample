using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityCRUDExample.Extantions
{
    /// <summary>
    /// Расширение Generics
    /// </summary>
    static class Generics
    {
        /// <summary>
        /// Принимает гибкий список параметров
        /// </summary>
        /// <param name="aValues"></param>
        /// <returns>List</returns>
        public static List<T> Add<T>(this List<T> list, params T[] aValues)
        {
            foreach (T value in aValues)
            {
                list.Add(value);
            }
            return list;
        }
    }
}
