using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_3
{
    class Mahalle
    {
        String Ad;
        
        public String getAd()
        {
            return Ad;
        }
        
        public Mahalle(String ad)
        {
            Ad = ad;
        }
    }
    class YemekSınıfı
    {
        string Ad;
        int Adet;
        int Fiyat;
        public YemekSınıfı(string ad, int adet, int fiyat)
        {
            Ad = ad;
            Adet = adet;
            Fiyat = fiyat;
        }
        public string toString()
        {
            return (Ad + " " + Adet + " " + Fiyat + "TL");
        }
        public int getÜcret()
        {
            return (Adet * Fiyat);
        }
        public string getYemekAd()
        {
            return Ad;
        }
        public int getAdet()
        {
            return Adet;
        }
        public int indirim(int indirimYüzdesi)
        {
            int indirimliFiyat = Fiyat - Fiyat * (indirimYüzdesi / 100);
            return indirimliFiyat;
        }
    }

    class TreeNode
    {
        public Mahalle data;
        public List<List<YemekSınıfı>> siparişlerListesi = new List<List<YemekSınıfı>>();
        public TreeNode leftChild;
        public TreeNode rightChild;

        public Mahalle getData()
        {
            return data;
        }
        public void displayNode()
        {
            Console.Write(" " + data.getAd() + "\n");
            
            for(int i= 0; i< siparişlerListesi.Count(); i++)
            {
                for(int j= 0; j<siparişlerListesi[i].Count(); j++)
                {
                    Console.WriteLine(siparişlerListesi[i][j].toString());
                }
                Console.WriteLine(" ");
            }
        }
        public void yüzElli()
        {
            for(int i= 0; i<siparişlerListesi.Count(); i++)
            {
                int top = 0;
                for(int j = 0; j < siparişlerListesi[i].Count(); j++)
                {
                    top += siparişlerListesi[i][j].getÜcret();
                }
                if (top > 150)
                {
                    for (int j = 0; j < siparişlerListesi[i].Count(); j++)
                    {
                        Console.WriteLine(siparişlerListesi[i][j].toString());
                    }
                    Console.WriteLine(" ");
                }

            }
        }
        public int yiyecekAdet(string yiyecek)
        {
            int topYiyecek = 0;
            for (int i = 0; i < siparişlerListesi.Count(); i++)
            {
                for (int j = 0; j < siparişlerListesi[i].Count(); j++)
                {
                    if(siparişlerListesi[i][j].getYemekAd() == yiyecek)
                    {
                        topYiyecek += siparişlerListesi[i][j].getAdet();

                    }
                }
            }
            return topYiyecek;

        }

    }

    class Tree
    {
        private TreeNode root;
        public int sayi;
        public Tree() { root = null; }
        public TreeNode getRoot()
        { return root; }

        // Ağacın preOrder Dolasılması
        public void preOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                localRoot.displayNode();
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }

        // Agacın inOrder Dolasılması
        public void inOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                localRoot.displayNode();
                inOrder(localRoot.rightChild);
            }
        }

        // Agacın postOrder Dolasılması
        public void postOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
                localRoot.displayNode();
            }
        }

        //Ağacın derinliğini bulduran metod
        public int maxDepth(TreeNode localRoot) 
        {
            if(localRoot == null)
            {
                return -1;
            }
            else
            {
                int lDepth = maxDepth(localRoot.leftChild);
                int rDepth = maxDepth(localRoot.rightChild);

                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }
        //Adı verilen mahallede 150 TL üstü siparişleri gösteren metod
        public TreeNode search(String name, TreeNode node)
        {
            if (node != null)
            {
                if (node.data.getAd().Equals(name))
                {
                    Console.WriteLine(node.getData().getAd());
                    node.yüzElli();
                    return node;
                }
                else
                {
                    TreeNode foundNode = search(name, node.leftChild);
                    if (foundNode == null)
                    {
                        foundNode = search(name, node.rightChild);
                    }
                    return foundNode;
                }
            }
            else
            {
                return null;
            }
        }

        public int yiyecekAdet(string yemekAd, TreeNode node)
        {
            
            return node.yiyecekAdet(yemekAd);
        }


        // Ağaca bir düğüm eklemeyi sağlayan metot
        public void insert(Mahalle newdata, List<List<YemekSınıfı>> siparişListe)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;
            newNode.siparişlerListesi = siparişListe;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;

                while (true)
                {
                    parent = current;
                    
                    if (String.Compare(newdata.getAd(), current.data.getAd()) < 0)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } // end while
            } // end else not root
        } // end insert()
    } // class Tree


    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            

            string[] menu = { "Lahmacun", "Dürüm", "Kebap", "Çiğ Köfte", "Hamburger", "Pizza" };
            int[] menuFiyat = { 5, 10, 20, 5, 15, 20 };

            string[] mahalleAdları = { "Evka 3", "Özkanlar", "Atatürk", "Erzene", "Kazımdirik" };

            Tree agac = new Tree();

            for (int i= 0; i<5; i++)
            {
                int siparisAdet = rand.Next(5, 11);
                List<List<YemekSınıfı>> siparişlerListesi = new List<List<YemekSınıfı>>(siparisAdet);
                
                for(int j = 0; j<siparisAdet; j++)//siparişler listesine ekleme yapacak döngü
                {
                    int siparisTürü = rand.Next(3, 6);
                    List<YemekSınıfı> siparişBilgileri = new List<YemekSınıfı>(siparisTürü);
                    List<int> control = new List<int>();
                    for (int k= 0; k<siparisTürü; k++)//Sipariş bilgilerine ekleme yapacak döngü
                    {
                        int yemekAdet = rand.Next(1, 9);
                        int yemekNo = rand.Next(0, 6);                        
                        while (control.Contains(yemekNo))
                        {
                            yemekNo = rand.Next(0, 6);
                        }
                        control.Add(yemekNo);
                        siparişBilgileri.Add(new YemekSınıfı(menu[yemekNo], yemekAdet, menuFiyat[yemekNo]));

                    }
                    siparişlerListesi.Add(siparişBilgileri);
                }


                Mahalle mahalleAdı = new Mahalle(mahalleAdları[i]);
                agac.insert(mahalleAdı, siparişlerListesi);
            }

            agac.inOrder(agac.getRoot());//Inorder dolaşma
            Console.WriteLine("Ağacın derinliği: " + agac.maxDepth(agac.getRoot()) + "\n");//Derinlik 

            string mahalle = "Erzene";
            agac.search(mahalle, agac.getRoot());//Adı verilen mahalledeki 150 TL üstü siparişler

            string yiyecek = "Lahmacun";
            Console.WriteLine(yiyecek + " " + agac.yiyecekAdet(yiyecek, agac.getRoot()) + " adet sipariş edilmiş.");

            

            Console.ReadKey();
        }
    }
}
