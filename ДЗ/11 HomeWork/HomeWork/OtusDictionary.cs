using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


/*
    Здравствуйте, Илья. Спасибо большое за вашу работу. Для начала давайте уточню, что пункт 1 и 3 действительно не могут работать одновременно, 
    однако, так как для набора минимально необходимого балла, чтобы сдать домашнюю работу, не обязательно делать 3 пункт, то вполне может
    существовать пункт 1 с использованием исключений. (принято)

    Теперь что касается вашей работы. Мне нравится, что вы инициализируете переменные в конструкторе и подробно комментируете код. 
    Правда, несколько смущает что комментарии начинаются с маленькой буквы, равно как и названия некоторых методов. 
    Напомню, что по общепринятой конвенции в C# методы всегда начинаются с большой буквы. (исправлено)

    Также, вижу, что вы реализовали разрешение коллизий с помощью открытой адресации. Это несомненно отличное решение, к сожалению, в задании предполагается,
    что вы реализуете закрытую адресацию. 

    То есть, если у элемента есть ключ, то по этому и только этому ключу будет находиться элемент. 

    Плюс, проверьте, пожалуйста, работу индексаторов с ключом, превышающим размер массива, у меня такой вызов не сработал. (исправлено)

    Также, думаю, что при работе с индексатором в качестве value должна приниматься строка, а не ItemDictionary. 
    Ещё, в текущей реализации можно добавить несколько разных значений по одному ключу и они все будут храниться в _items.

    Предлагаю вам в качестве хранилища использовать массив строк, как это указано в задаче и реализовать задачу с ним. Возможно,
    придётся немного поломать голову над тем, как это сделать, однако, уверен, что будете приятно удивлены тем, как просто и элегантно можно сделать 
    это задание.

    Если же не получится и вы где-то застрянете, то пишите здесь и я с удовольствием вам помогу. А пока возвращаю работу вам.
 */


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
    /// Кастомный словарь
    /// </summary>
    internal class OtusDictionary
    {
        /// <summary>
        /// Первоначальная длина коллекции OtusDictionary
        /// </summary>
        private int _size;
        /// <summary>
        /// Текущая позиция элемента
        /// </summary>
        private int _nowPosition;
        /// <summary>
        /// Массив items (ключ-значение)
        /// </summary>
        private ItemDictionary[] _items;

        /// <summary>
        /// конструктор(по умолчанию размер OtusDictionary равен 32 
        /// </summary>
        public OtusDictionary()
        {
            _size = 32;
            _nowPosition = 0;
            _items = new ItemDictionary[_size];
        }


        #region 1 Реализуйте метод Add с неизменяемым массивом размером 32 элемента(исключение, если уже занято место).

        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="key">Ключ-значение (int)</param>
        /// <param name="value">Значение (string)</param>
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
                LengthIncrease();
            }
            int keyHash = HashKey(key);
            if (_items[keyHash] != null)
            {
                // Решаем проблему. При использовании хеш-кода,например, число 40 при преобразовании превращается в 8
                // согласно ТЗ, "только один объект по одному индексу". 
                keyHash = FindNewIndex(keyHash);
            }

            _items[keyHash] = new ItemDictionary(key, value);
            _nowPosition++;

        }
        #endregion

        #region 2 Реализуйте метод Get.

        /// <summary>
        /// Получить элемент по ключу
        /// </summary>
        /// <param name="key">Значение ключа по которому нужно вернуть значение</param>
        /// <returns>Значение элемента</returns>
        public string Get(int key)
        {
            int hash = HashKey(key);
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
        /// Получить key при помощи хеш таблицы
        /// </summary>
        /// <param name="key"> Ключ </param>
        /// <returns>Хеш - ключ</returns>
        private int HashKey(int key) => key % _size;


        /// <summary>
        /// Поиск нового индекса
        /// </summary>
        /// <param name="index">Текущий индекс</param>
        /// <returns>Индекс элемента</returns>
        private int FindNewIndex(int index)
        {
            int sds = index;
            while (_items[index] != null)
            {
                index = (index + 1) % _size;
            }
            if (_size <= index)
            {
                LengthIncrease();
            }
            return index;
        }
        /// <summary>
        /// Поиск нового индекса
        /// </summary>
        /// <param name="index">Текущий индекс</param>
        /// <param name="_itemsNew">Новый массив, в котором нужно сделать поиск</param>
        /// <returns>Индекс элемента</returns>
        private int FindNewIndex(int index, ItemDictionary[] _itemsNew)
        {

            while (_itemsNew[index] != null)
            {
                index = (index + 1) % _size;
            }
            if (_size <= index)
            {
                LengthIncrease();
            }
            return index;
        }



        #region 3 Реализуйте увеличение массива в два раза при нахождении коллизий
        /// <summary>
        /// Увеличение длины основного массива OtusDictionary
        /// </summary>
        private void LengthIncrease()
        {
            _size = _size * 2;
            ItemDictionary[] _itemsNew = new ItemDictionary[_size];
            foreach (ItemDictionary item in _items)
            {
                int keyHash = HashKey(item.Key);
                if (_itemsNew[keyHash] != null)
                {
                    keyHash = FindNewIndex(keyHash, _itemsNew);
                }
                _itemsNew[keyHash] = new ItemDictionary(item.Key, item.Value);
            }
            _items = _itemsNew;

        }
        #endregion

        #region Добавьте к классу возможность работы с индексатором
        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Значение ItemDictionary</returns>
        public ItemDictionary this[int index]
        {
            get
            {
                if (_size <= index)
                {
                    Console.WriteLine("По этому индексу ничего нет, но согласно ТЗ нельзя положить программу");
                    return null;
                }
                else
                {
                    return _items[index];
                }
            }
            set => _items[index] = value;
            // get and set accessors
        }
        #endregion
    }

}
