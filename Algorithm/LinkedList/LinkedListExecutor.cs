using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.LinkedList
{
    public class LinkedListExecutor
    {
        private readonly LinkedList<int> list;

        public LinkedListExecutor() 
        {
            list = new LinkedList<int>(new List<int> { 1,2,3});
            Add();
        }

        private void Add() 
        {
            list.AddLast(4);
            list.AddFirst(0);
            list.AddAfter(list.Find(2),6);
            list.AddBefore(list.Find(3),7);
        }

        /// <summary>
        /// 遍历链表
        /// </summary>
        public void Show() 
        {
            //foreach (var item in list) 
            //{
            //    Console.Write(item+" ");
            //}
            list.Clear();
            //var firstNode = list.First;
            //var nodeValue = firstNode.Value;
            //nodeValue = 2;
            //while (firstNode != null) 
            //{
            //    Console.Write(firstNode.Value+" ");
            //    firstNode = firstNode.Next;
            //}
            
        }
    }
}
