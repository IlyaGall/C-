using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13_3.Parts
{
    internal class Part 
    {
        /// <summary>
        /// Новый текст который будет записан
        /// </summary>
        protected new string[] text = new[] { "Вот дом,","Который построил Джек." };

        /// <summary>
        /// Текст который один раз будет перезаписан
        /// </summary>
        public ImmutableList<string> Poem { get; private set; }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="poem">Старая поэма</param>
        public Part(ImmutableList<string> poem) 
        {
            Poem = poem;
        }

        /// <summary>
        /// Добавление нового четверостишье
        /// </summary>
        /// <param name="prevPoem"></param>
        /// <returns></returns>
        public ImmutableList<string> AddPart(ImmutableList<string> prevPoem)
        {
            ImmutableList<string> newPoem = ImmutableList<string>.Empty.AddRange(text);// text.ToImmutableList(); 
            Poem = prevPoem.Concat(newPoem).ToImmutableList();
            return Poem;
        }
    }
}
