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

        /// <summary>
        /// 输出输入字符所有全排列组合
        /// </summary>
        /// <param name="chars"></param>
        public static void TestDemo2(char[] chars) 
        {
            char[] tempChars;
            for (var i = 0; i < chars.Length; i++)
            {
                tempChars = new char[chars.Length-1];
                Array.Copy(chars,1,tempChars,0, chars.Length - 1);
                var tempList = Demo2(tempChars);
                foreach (var item in tempList)
                {
                    var sb = new StringBuilder();
                    sb.Append(chars[0] + "," + item);
                    Console.WriteLine(sb);
                }
                if (i < chars.Length - 1)
                {
                    char temp = chars[i + 1];
                    chars[i + 1] = chars[0];
                    chars[0] = temp;
                }
            }
            tempChars = null;
        }
        /// <summary>
        /// 1.交换2.递归
        /// </summary>
        /// <param name="chars"></param>
        private static List<StringBuilder> Demo2(char[] chars)
        {
            var list = new List<StringBuilder>();
            if (chars == null || chars.Length == 0) throw new Exception("参数异常!");
            else if (chars.Length == 1)
            {
                list.Add(new StringBuilder(chars[0]));
            }
            else if (chars.Length == 2)
            {
                var sb1 = new StringBuilder();
                sb1.Append(chars[0] + "," + chars[1]);
                list.Add(sb1);
                var sb2 = new StringBuilder();
                sb2.Append(chars[1] + "," + chars[0]);
                list.Add(sb2);
            }
            else
            {
                char[] tempChars;
                for (var i = 0; i < chars.Length; i++) 
                {
                    tempChars = new char[chars.Length - 1];
                    Array.Copy(chars, 1, tempChars, 0, chars.Length - 1);
                    var tempList = Demo2(tempChars);
                    foreach (var item in tempList) 
                    {
                        var sb = new StringBuilder();
                        sb.Append(chars[0]+","+ item);
                        list.Add(sb);
                    }
                    //把待处理的下一项放在第一个位置
                    if (i < chars.Length - 1) 
                    {
                        char temp = chars[i+1];
                        chars[i + 1] = chars[0];
                        chars[0] = temp;
                    }
                }
                tempChars = null;
            }
            return list;
        }

        /// <summary>
        /// 输入一组数，输出要求：奇数在前，偶数在后，时间复杂度要求O(n)
        /// </summary>
        /// <param name="nums"></param>
        public static void Demo3(int[] nums) 
        {
            int index = 0;
            int firstEvenNumIndex = -1;
            while (index < nums.Length) 
            {
                if (nums[index] % 2 == 0)
                {
                    if (index == 0||firstEvenNumIndex == -1||index< firstEvenNumIndex) firstEvenNumIndex = index;
                }
                else 
                {
                    if (firstEvenNumIndex > -1 && index > firstEvenNumIndex) 
                    {
                        var temp = nums[index];
                        nums[index] = nums[firstEvenNumIndex];
                        nums[firstEvenNumIndex] = temp;
                        if (index - firstEvenNumIndex > 1) firstEvenNumIndex++;
                        else firstEvenNumIndex = index;
                    }
                }
                index++;
            }
            Console.WriteLine(string.Join(',',nums));
        }
    }
}
