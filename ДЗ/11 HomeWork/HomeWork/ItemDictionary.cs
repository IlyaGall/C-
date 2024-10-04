using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    /// <summary>
    /// Элемент коллекции OtusDictionary
    /// </summary>
    internal class ItemDictionary
    {
        /// <summary>
        /// Ключ словаря
        /// </summary>
        public int Key { get; private set; }
        /// <summary>
        /// Значение словаря
        /// </summary>
        public string? Value { get; private set; }

        /// <summary>
        /// Конструктор item
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public ItemDictionary(int key, string value)
        {
            Key = key;
            Value = value;
        }

    }
}
