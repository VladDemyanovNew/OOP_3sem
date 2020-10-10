using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab3
{
    static class SetExtension
    {
        public static Set AddComma(this Set type)
        {
            for (int i = 0; i < type.Arr.Count; i++)
            {
                if (i % 2 != 0)
                    type.Arr.Insert(i, ",");
            }
            return type;
        }

        public static Set DeleteRepeated(this Set type)
        {
            type.Arr.Sort();
            string previous = type.Arr[0];
            int length = type.Arr.Count;
            for (int i = 1; i < length; i++)
            {
                if (type.Arr[i] == previous)
                {
                    type.Arr.RemoveAt(i);
                    previous = type.Arr[i - 1];
                    i--;
                }
                else
                {
                    previous = type.Arr[i];
                }
                
                length = type.Arr.Count;
            }
            
            return type;
        }
    }
}
