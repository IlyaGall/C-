﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13_3.Parts
{
    internal class Part1 : Part
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="poem">Старая поэма</param>
        public Part1(ImmutableList<string> poem) : base(poem)
        {
            text = new[] {
                "Вот дом,",
                "Который построил Джек."
            };
        }
    }
}
