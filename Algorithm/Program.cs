using Algorithm.Demo;
using Algorithm.LinkedList;
using Algorithm.Queue;
using Algorithm.Tree;
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
            //char[] data = { 'A', 'B', 'C','D', 'E', 'F', 'G', 'H', 'I', 'J','K' };
            //BinaryTree<char> tree = new BinaryTree<char>(data);
            //Console.Write("先序遍历：");
            //tree.PreTraversal(tree.Head);
            //Console.WriteLine();
            //Console.Write("中序遍历：");
            //tree.InTraversal(tree.Head);
            //Console.WriteLine();
            //Console.Write("后序遍历：");
            //tree.LastTraversal(tree.Head);
            //Console.WriteLine();
            //Console.Write("层次遍历：");
            //tree.LevelTranversal(tree.Head);
            //AlgorithmDemo.TestDemo2(new char[] { '1','2','3','4'});
            AlgorithmDemo.Demo3(new int[] { 2,4,3,6,9,8,1,12,3,10,5,7 });
            Console.ReadLine();
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
