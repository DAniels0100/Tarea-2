using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_2
{
    //Interfaz de la lista
    interface IList 
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        //void MergeSorted(IList listA, IList listB, ListSortDirection direction);

    }

    //Enum de las posibles direcciones
    enum ListSortDirection
    {
        Ascendente = 1,
        Descendente = 2
    }

    public class DoublyLinkedList:IList
    {

        public Node Head;
        public Node Tail;

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        //poder anadir nodos al ser una linked list custom
        public void AddNode(int data)
        {
            Node newNode = new Node(data);

            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }
        //completar los metodos de la interfaz
        public int DeleteFirst()
        {
            int HeadValue = Head.Data;
            if (Head == null)
            {
                return 0;
            }
            if (Head == Tail) 
            {
                Head = Tail = null;
            }
            else 
            {
                Head = Head.Next;
                Head.Prev = null;   
            }
            return HeadValue;
        }

        public int DeleteLast()
        {
            int TailValue = Tail.Data;
            if (Tail == null)
            {
                return 0;
            }
            if (Head == Tail) 
            {
                Head = Tail = null;
            }
            else 
            {
                Tail=Tail.Prev;
            }
            return TailValue;
        }
        public bool DeleteValue(int value)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data == value)
                {
                    current = current.Next;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        // Método para mezclar dos linkedlist 
        public static DoublyLinkedList MergeSorted(DoublyLinkedList listA, DoublyLinkedList listB, int direction)
        {
            Node a = listA.Head;
            Node b = listB.Head;
            DoublyLinkedList mergedList = new DoublyLinkedList();

            // Mezcla en orden ascendente
            if (direction==1)
            {
                while (a != null && b != null)
                {
                    if (a.Data <= b.Data)
                    {
                        mergedList.AddNode(a.Data);
                        a = a.Next;
                    }
                    else
                    {
                        mergedList.AddNode(b.Data);
                        b = b.Next;
                    }
                }

                // si las listas no son de misma longitud, se anaden los nodos sobrantes
                while (a != null)
                {
                    mergedList.AddNode(a.Data);
                    a = a.Next;
                }
                while (b != null)
                {
                    mergedList.AddNode(b.Data);
                    b = b.Next;
                }
            }
            // Mezcla en orden descendente
            else if (direction==2)
            {
                while (a != null && b != null)
                {
                    if (b.Data >= a.Data)
                    {
                        mergedList.AddNode(a.Data);
                        a = a.Next;
                    }
                    else
                    {
                        mergedList.AddNode(b.Data);
                        b = b.Next;
                    }
                }

                // Añadir los nodos restantes de listA o listB
                while (a != null)
                {
                    mergedList.AddNode(a.Data);
                    a = a.Next;
                }
                while (b != null)
                {
                    mergedList.AddNode(b.Data);
                    b = b.Next;
                }

                // Invertir la lista final
                mergedList = InvertList(mergedList);
            }

            return mergedList;
        }

        // Método para invertir una linked list
        public static DoublyLinkedList InvertList(DoublyLinkedList list)
        {
            if (list.Head == null) return list; 

            Node current = list.Head;
            Node temp = null;

            // Intercambiar apuntadores (invertir orden)
            while (current != null)
            {
                temp = current.Prev;
                current.Prev = current.Next;
                current.Next = temp;
                current = current.Prev;
            }

            // Intercambiar nodo head y tail
            temp = list.Head;
            list.Head = list.Tail;
            list.Tail = temp;

            return list;
        }

        public void InsertInOrder(int data)
        {
            Node newNode = new Node(data);

            if (Head == null) 
            {
                Head = Tail = newNode;
                return;
            }
            // verificacion si nodo se inserta de primero
            if (data <= Head.Data) 
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
                return;
            }
            // verificacion si nodo se inserta de ultimo
            if (data >= Tail.Data)
            {
                newNode.Prev = Tail;
                Tail.Next = newNode;
                Tail = newNode;
                return;
            }

            //Se inserta en medio de la linked list
            Node current = Head;
            while (current != null && current.Data < data)
            {
                current = current.Next;
            }

            //reorganizar apuntadores
            newNode.Prev = current.Prev;
            newNode.Next = current;
            current.Prev.Next = newNode;
            current.Prev = newNode;
        }
        public int GetMiddle()
        {

            Node apuntadorMedio = Head;
            Node ApuntadorFinal = Head;

            // se recorre la lista hasta el final con un apuntador, mientras que el otro avanza hasta la mitad
            while (ApuntadorFinal != null && ApuntadorFinal.Next != null)
            {
                apuntadorMedio = apuntadorMedio.Next;
                ApuntadorFinal = ApuntadorFinal.Next.Next; 
            }

          
            return apuntadorMedio.Data;
        }
        public void PrintList()
        {
            Node current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
