using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Concurrency
{
    public class ParallelDemo
    {
        public static int GetSum(IEnumerable<int> list) 
        {
            object mutex = new object();
            int result = 0;
            Parallel.ForEach(source:list,localInit:()=>0,body:(item,state,localValue)=>localValue+item,
                localFinally:localValue=> 
                {
                    lock (mutex) 
                    {
                        result += localValue;
                    }
                });

            return result;
        }
    }
}
