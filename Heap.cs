using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_3_Heap
{
    public class Node
    {
        public Node left;
        public Node right;
        public Node parent;

        public string mahalleAd;
        public int nüfus;

        public Node(string mahalleAd, int nüfus)
        {
            this.mahalleAd = mahalleAd;
            this.nüfus = nüfus;
        }
    }

    class maxHeap
    {
        Node root;
        Node position;
        public maxHeap(Node node)
        {
            root = node;
            position = node;
        }

        public void insert(Node n)
        {
            if(position.left == null)
            {
                position.left = n;
                n.parent = position;
                balanceHeap(n);
                return;
            }
            else
            {
                position.right = n;
                n.parent = position;

                adjustPosition();
                balanceHeap(n);
            }
        }
        public void balanceHeap(Node n)
        {
            while(n.parent != null)
            {
                if(n.parent.nüfus < n.nüfus)
                {
                    int tmp = n.nüfus;
                    n.nüfus = n.parent.nüfus;
                    n.parent.nüfus = tmp;
                    n = n.parent;
                }
                else
                {
                    break;
                }
            }
        }
        public void adjustPosition()
        {
            Node node;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                node = q.Dequeue();

                if(node.left != null)
                {
                    q.Enqueue(node.left);
                }
                else
                {
                    position = node;
                    break;
                }

                if(node.right != null)
                {
                    q.Enqueue(node.right);
                }
                else
                {
                    position = node;
                    break;
                }
            }
        }
        public void traversal()
        {
            Node node;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                node = q.Dequeue();
                Console.Write(node.mahalleAd.ToString() + " " + node.nüfus.ToString() + "\n");
                if(node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
        }
        public void biggestThree()
        {
            Node node;
            int counter = 0;
            Console.WriteLine("Nüfusu en fazla olan 3 mahalle: ");
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                node = q.Dequeue();
                if (counter < 3)
                {
                    Console.Write(node.mahalleAd.ToString() + " " + node.nüfus.ToString() + "\n");
                }
                counter++;
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] mahalle = { "Erzene", "Kazımdirik", "Yeşilova", "Atatürk", "İnönü", "Mevlana", "Doğanlar", "Evka 3", "Rafet Paşa", "Kızılay" };
            int[] nüfusList = { 35135, 33934, 31008, 28912, 25778, 25492, 21461, 20445, 19476, 15795 };

            maxHeap heap = new maxHeap(new Node(mahalle[0], nüfusList[0]));
            for (int i = 1; i<mahalle.Length; i++)
            {
                Node data = new Node(mahalle[i], nüfusList[i]);
                
                heap.insert(data);
                
            }
            heap.traversal();

            heap.biggestThree();
            Console.ReadKey();
        }
    }
}
