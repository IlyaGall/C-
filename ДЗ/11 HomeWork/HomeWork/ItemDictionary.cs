using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    /// <summary>
    /// элемент коллекции OtusDictionary
    /// </summary>
    internal class ItemDictionary
    {
        /// <summary>
        /// ключ словаря
        /// </summary>
        public int Key { get; set; }
        /// <summary>
        /// значение словаря
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// конструктор item
        /// </summary>
        /// <param name="key">ключ</param>
        /// <param name="value">значение</param>
        public ItemDictionary(int key, string value) 
        {
            Key = key;
            Value = value;
        }

    }
}
