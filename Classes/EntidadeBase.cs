using System;
using DIO.Series.Enum;
using DIO.Series.Classes;
using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
    }
}