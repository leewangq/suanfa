using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Demo
{
    public class AlgorithmDemo
    {
        /// <summary>
        /// 获取所有和等于输入正整数的连续正整数
        /// </summary>
        /// <param name="n"></param>
        public static void GetContinuousNumBySumEqualsInputNum(int n)
        {
            if (n < 3) return;
            int startnum = 0;
            if (n % 2 == 0)//偶数
            {
                if ((n / 2) % 2 == 0) startnum = n / 2 - 1;//中间数是否是偶数
                else startnum = n / 2;
            }
            else  //奇数
            {
                startnum = n / 2;
                Console.WriteLine($"{n}={startnum}+{startnum + 1}");
                if (startnum == 1 || startnum == 2 || startnum == 3) return;
            }
            var list = new List<int>() { startnum };
            int count = 0;
            while (startnum >= 1)
            {
                count++;
                var sum = list.Sum();
                if (n - sum < startnum - 1)
                {
                    list.RemoveAt(0);
                    startnum--;
                    list.Add(startnum);
                }
                else if (n - sum == startnum - 1)
                {
                    startnum--;
                    list.Add(startnum);
                    var content = $"{n}=";
                    content += string.Join('+', list.OrderBy(p => p));
                    Console.WriteLine(content);
                    list.RemoveAt(0);
                }
                else
                {
                    startnum--;
                    list.Add(startnum);
                }
            }
            Console.WriteLine("执行总次数:" + count);
        }
    }
}
