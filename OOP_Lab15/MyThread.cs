using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP_Lab15
{
    class MyThread
    {
        public delegate void MakeComputation();
        private Thread t;

        public MyThread(MakeComputation _del, string name, ThreadPriority priority)
        {
            t = new Thread(_del.Invoke);
            t.Name = name;
            t.Priority = priority;
            t.Start();
            //t.Join();
        }
    }
}
