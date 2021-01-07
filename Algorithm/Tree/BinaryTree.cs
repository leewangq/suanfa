using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Tree
{
    public class BinaryTree<T>
    {
        private TreeNode<T> head; //头指针
        private T[] datas; //用于构造二叉树的字符串
        public TreeNode<T> Head
        {
            get { return head; }
        }

        //创建二叉树
        public BinaryTree(T[] vals)
        {
            datas = vals;
            Add(head, 0); //给头结点添加孩子节点
        }

        //使用先序创建二叉树 #:表示该位置无节点()
        private void Add(TreeNode<T> parent, int index)
        {
            if (parent == null)
            {
                parent = new TreeNode<T>(datas[index]);
                head = parent;
            }

            int leftIndex = 2 * index + 1; //计算当前结点左孩子的索引
            int rightIndex = 2 * index + 2; //计算当前结点右孩子的索引

            if (leftIndex < datas.Length)
            {
                parent.LChild = new TreeNode<T>(datas[leftIndex]);
                Add(parent.LChild, leftIndex);
            }
            if (rightIndex < datas.Length)
            {
                parent.RChild = new TreeNode<T>(datas[rightIndex]);
                Add(parent.RChild, rightIndex);
            }
        }

        //先序遍历
        public void PreTraversal(TreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                PreTraversal(node.LChild);
                PreTraversal(node.RChild);
            }
        }

        //中序遍历
        public void InTraversal(TreeNode<T> node)
        {
            if (node != null)
            {
                InTraversal(node.LChild);
                Console.Write(node.Data + " ");
                InTraversal(node.RChild);
            }
        }

        //后序遍历
        public void LastTraversal(TreeNode<T> node)
        {
            if (node != null)
            {
                LastTraversal(node.LChild);
                LastTraversal(node.RChild);
                Console.Write(node.Data + " ");
            }
        }

        //层次遍历
        //引入队列
        public void LevelTranversal(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                //结点出队
                TreeNode<T> temp = queue.Dequeue();
                Console.Write(temp.Data + " ");
                if (temp.LChild != null)
                {
                    queue.Enqueue(temp.LChild);
                }
                if (temp.RChild != null)
                {
                    queue.Enqueue(temp.RChild);
                }
            }
        }
    }
}
