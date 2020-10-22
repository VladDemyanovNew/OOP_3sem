﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    abstract class Vehicle
    {
        public int Weight { get; set; }
        public int MaxSpeed { get; set; }

        // Без полиморфизма подтипов
        public double calculateRate()
        {
            return (this.Weight + 1000) / 2;
        }

        // С полиморфизмом подтипов
        public virtual double calculateRate2()
        {
            return (this.Weight + 1000) / 2;
        }
    }
}
