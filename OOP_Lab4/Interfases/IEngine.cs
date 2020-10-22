using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab4
{
    interface IEngine
    {
        int Power { get; }
        void Start();
        void Stop();
    }
}
