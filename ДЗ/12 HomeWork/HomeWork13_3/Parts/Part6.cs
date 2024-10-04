using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13_3.Parts
{
    internal class Part6 : Part
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="poem">Старая поэма</param>
        public Part6(ImmutableList<string> poem) : base(poem)
        {
            text = new[] {
                "А это корова безрогая,",
                "Лягнувшая старого пса без хвоста,",
                "Который за шиворот треплет кота,",
                "Который пугает и ловит синицу",
                "Которая часто ворует пшеницу,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            };
        }
    }
}
