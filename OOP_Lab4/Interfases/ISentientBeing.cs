using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    interface ISentientBeing
    {
        int IQ { get; }
        int Year { get; }
        string Name { get; }
        void Say();
        bool DoClone();
    }
}
