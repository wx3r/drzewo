using drzewo;
using System;

namespace drzewo
{
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
    }

    public class BinaryTree
    {
        private Node korzen;

        public void DodajElement(int wartosc)
        {
            if (korzen == null)
            {
                korzen = new Node { Value = wartosc };
            }
            else
            {
                DodajDoDrzewa(korzen, wartosc);
            }
        }

        private void DodajDoDrzewa(Node aktualny, int wartosc)
        {
            if (CzyParzysta(wartosc))
            {
                if (aktualny.Left == null)
                {
                    aktualny.Left = new Node { Value = wartosc };
                }
                else
                {
                    DodajDoDrzewa(aktualny.Left, wartosc);
                }
            }
            else
            {
                if (aktualny.Right == null)
                {
                    aktualny.Right = new Node { Value = wartosc };
                }
                else
                {
                    DodajDoDrzewa(aktualny.Right, wartosc);
                }
            }
        }

        private bool CzyParzysta(int liczba)
        {
            return liczba % 2 == 0;
        }

        public bool ZnajdzElement(int wartosc)
        {
            return PrzeszukajDrzewo(korzen, wartosc);
        }

        private bool PrzeszukajDrzewo(Node aktualny, int wartosc)
        {
            if (aktualny == null)
            {
                return false;
            }
            if (aktualny.Value == wartosc)
            {
                return true;
            }
            if (CzyParzysta(wartosc))
            {
                return PrzeszukajDrzewo(aktualny.Left, wartosc);
            }
            else
            {
                return PrzeszukajDrzewo(aktualny.Right, wartosc);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        BinaryTree drzewo = new BinaryTree();
        drzewo.DodajElement(5);
        drzewo.DodajElement(1);
        drzewo.DodajElement(2);
        drzewo.DodajElement(4);
        drzewo.DodajElement(6);
        drzewo.DodajElement(8);
        drzewo.DodajElement(9);
        drzewo.DodajElement(10);

        Console.WriteLine(drzewo.ZnajdzElement(5)); // true
        Console.WriteLine(drzewo.ZnajdzElement(7)); // false
    }
}
