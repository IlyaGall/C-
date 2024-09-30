using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/*
    Реализуйте класс OtusDictionary, который позволяет оперировать int-овыми значениями в качестве ключей и строками в качестве значений. 
    Для добавления используйте метод void Add(int key, string value), а для получения элементов - string Get(int key). 
    Внутреннее хранилище реализуйте через массив. 
    При нахождении коллизий, создавайте новый массив в два раза больше и не забывайте пересчитать хеши для всех уже вставленных элементов. 
    Метод GetHashCode использовать не нужно и массив/список объектов по одному адресу создавать тоже не нужно (только один объект по одному индексу). 
    Словарь не должен давать сохранить null в качестве строки, соответственно, проверять заполнен элемент или нет можно сравнивая строку с null.
 */
namespace HomeWork
{
    /// <summary>
    /// кастомный словарь
    /// </summary>
    internal class OtusDictionary
    {

        /// <summary>
        /// первоначальная длина коллекции OtusDictionary
        /// </summary>
        private int _size;
        /// <summary>
        /// текущая позиция элемента
        /// </summary>
        private int _nowPosition;
        /// <summary>
        /// массив items (ключ-значение)
        /// </summary>
        private ItemDictionary[] _items;

        public OtusDictionary()
        {
            _size = 32;
            _nowPosition = 0;
            _items = new ItemDictionary[_size];
        }


        #region 1 Реализуйте метод Add с неизменяемым массивом размером 32 элемента(исключение, если уже занято место).

        /// <summary>
        /// добавить элемент
        /// </summary>
        /// <param name="key">ключ-значение (int)</param>
        /// <param name="value">значение (string)</param>
        //TODO: 1 задание противоречит 3 "(исключение, если уже занято место)"
        //"Реализуйте увеличение массива в два раза при нахождении коллизий"
        public void Add(int key, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Значение не может быть пустым");
            }
            //if (_nowPosition >= _size)
            //{ 
            //    throw new ArgumentNullException("место закончилось!");
            //}
            // закомментированный фрагмент для первого задания  "(исключение, если уже занято место)"
            if (_nowPosition >= _size)
            {
                lengthIncrease();
            }
            int keyHash = hashKey(key);
            if (_items[keyHash] != null) 
            {
                // Решаем проблему. При использовании хеш-кода,например, число 40 при преобразовании превращается в 8
                // согласно ТЗ, "только один объект по одному индексу". 
                keyHash = findNewIndex(keyHash);
            }
            
            _items[keyHash] = new ItemDictionary(key, value);
            _nowPosition++;

        }
        #endregion

        #region 2 Реализуйте метод Get.

        /// <summary>
        /// получить элемент по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns>значение элемента</returns>
        public string Get(int key)
        {
            int hash = hashKey(key);
            while (hash < _size)
            {
                ItemDictionary entry = _items[hash];
                if (entry != null && entry.Key == key)
                {
                    return entry.Value;
                }
                hash++;
            }
            return null;
        }
        #endregion

        /// <summary>
        /// получить key при помощи хеш таблицы
        /// </summary>
        /// <param name="key"> ключ </param>
        /// <returns>хеш - ключ</returns>
        private int hashKey(int key) =>  key % _size;


        /// <summary>
        /// поиск нового индекса
        /// </summary>
        /// <param name="index">текущий индекс</param>
        /// <returns>индекс элемента</returns>
        private int findNewIndex(int index)
        {
            int sds = index;
            while (_items[index] != null)
            {
                index = (index + 1) % _size;
            }
            if (_size <= index) 
            {
                lengthIncrease();
            }
            return index;
        }
        /// <summary>
        /// поиск нового индекса
        /// </summary>
        /// <param name="index">текущий индекс</param>
        /// <param name="_itemsNew">новый массив, в котором нужно сделать поиск</param>
        /// <returns>индекс элемента</returns>
        private int findNewIndex(int index, ItemDictionary[] _itemsNew)
        {

            while (_itemsNew[index] != null)
            {
                index = (index + 1) % _size;
            }
            if (_size <= index)
            {
                lengthIncrease();
            }
            return index;
        }



        #region 3 Реализуйте увеличение массива в два раза при нахождении коллизий
        /// <summary>
        /// увеличение длины основного массива OtusDictionary
        /// </summary>
        private void lengthIncrease()
        {
            _size = _size * 2;
            ItemDictionary[] _itemsNew = new ItemDictionary[_size];
            foreach (ItemDictionary item in _items)
            {
                int keyHash = hashKey(item.Key);
                if (_itemsNew[keyHash] != null)
                {
                    keyHash = findNewIndex(keyHash, _itemsNew);
                }
                _itemsNew[keyHash] = new ItemDictionary(item.Key, item.Value);
            }
            _items = _itemsNew;

        }
        #endregion

        #region Добавьте к классу возможность работы с индексатором
        /// <summary>
        /// индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ItemDictionary this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
            // get and set accessors
        }
        #endregion
    }

}
