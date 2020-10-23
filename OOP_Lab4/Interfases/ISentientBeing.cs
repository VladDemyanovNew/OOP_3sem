using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    interface ISentientBeing
    {
        int IQ { get; }
        void Say();
        bool DoClone();
    }
}
