using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Tree
{
    //二叉树结点类
    public class TreeNode<T>
    {
        private T data; //数据域
        private TreeNode<T> lChild; //左孩子
        private TreeNode<T> rChild; //右孩子

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public TreeNode<T> LChild
        {
            get { return lChild; }
            set { lChild = value; }
        }

        public TreeNode<T> RChild
        {
            get { return rChild; }
            set { rChild = value; }
        }

        public TreeNode()
        {
            data = default(T);
            lChild = null;
            rChild = null;
        }

        public TreeNode(T val)
        {
            data = val;
            lChild = null;
            rChild = null;
        }
    }
}
