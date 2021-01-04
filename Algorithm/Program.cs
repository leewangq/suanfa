using Algorithm.LinkedList;
using Algorithm.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //new LinkedListExecutor().Show();

            //Console.WriteLine("Hello World!");
            //var bc = new BookCollection();
            //bc.ListBooks();

            //ref var book = ref bc.GetBookByTitle("Call of the Wild, The");
            //if (book != null)
            //    book = new Book { Title = "Republic, The", Author = "Plato" };
            //bc.ListBooks();

            while (true) 
            {
                Console.Write("请求输入一个数:");
                var str=Console.ReadLine();
                if (str.Equals("end")) break;
                ShowNumList(int.Parse(str));
                Find(int.Parse(str));
            }
        }

        /// <summary>
        /// 差值法计算
        /// </summary>
        /// <param name="n"></param>
        static void ShowNumList(int n) 
        {
            if (n < 3) return;
            int startnum = 0;
            if (n % 2 == 0)//偶数
            {
                if((n/2)%2==0) startnum = n / 2 - 1;
                else startnum = n / 2 ;
            }
            else  //奇数
            {
                startnum = n / 2;
                Console.WriteLine($"{n}={startnum}+{startnum+1}");
                if (startnum == 1 || startnum == 2 || startnum == 3) return;
            }
            var list = new List<int>() { startnum };
            int count=0;
            while (startnum>=1) 
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
                    //list=list.OrderBy(p=>p).ToList();
                    var content = $"{n}=";
                    content+=string.Join('+', list.OrderBy(p => p));
                    Console.WriteLine(content);
                    list.RemoveAt(0);
                    
                    //list.Add(startnum);
                    //startnum = list.First();
                    //list = new List<int> { startnum };
                }
                else
                {
                    startnum--;
                    list.Add(startnum);
                }
            }
            Console.WriteLine("执行总次数:"+count);

        }

        public static void Find(int num)
        {

            if (num <= 0)
            {
                return;
            }
            int start = 1;
            int end = 2;
            int count = (num + 1) / 2;
            int sum = 1;
            int execount = 0;
            while (start <= count)
            {
                execount++;
                if (sum == num)
                {

                    Console.WriteLine(num + " = " + start + " +...+ " + (end - 1));

                    sum -= start;
                    start++;
                }
                else if (sum < num)
                {
                    sum += end;
                    end++;
                }
                else
                {
                    sum -= start;
                    start++;
                }
            }
            Console.WriteLine("执行总次数:" + execount);
        }

        #region 引用返回值

        public class Book
        {
            public string Author;
            public string Title;
        }

        public class BookCollection
        {
            private Book[] books = { new Book { Title = "Call of the Wild, The", Author = "Jack London" },
                        new Book { Title = "Tale of Two Cities, A", Author = "Charles Dickens" }
                       };
            private Book nobook = null;

            public ref Book GetBookByTitle(string title)
            {
                for (int ctr = 0; ctr < books.Length; ctr++)
                {
                    if (title == books[ctr].Title)
                        return ref books[ctr];
                }
                return ref nobook;
            }

            public void ListBooks()
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title}, by {book.Author}");
                }
                Console.WriteLine();
            }
        }

        #endregion
    }
}
