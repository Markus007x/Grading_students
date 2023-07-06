﻿using GradingStudents;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingStudents
{
    public class Statistics
    {

        public double High;
        public double Low;
        public double Sum;
        public int Count;


        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count++;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
    }

}
