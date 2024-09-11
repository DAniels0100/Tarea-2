using System.ComponentModel;
using Tarea_2;

namespace pruebas_unitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MergedList_ShouldReturnALinkedListMerged()
        {
            int[] numerosLista1 = { 1, 3, 5, 7, 9 };
            int[] numerosLista2 = { 2, 4, 6, 8 };
            int[] numerosLista3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            DoublyLinkedList listB = new DoublyLinkedList();
            DoublyLinkedList listA = new DoublyLinkedList();
            DoublyLinkedList listC = new DoublyLinkedList();
            DoublyLinkedList listD = new DoublyLinkedList();

            for (int i = 0; i < numerosLista1.Length; i++)
            {
                listA.AddNode(numerosLista1[i]);
            }
            for (int i = 0; i < numerosLista2.Length; i++)
            {
                listB.AddNode(numerosLista2[i]);
            }
            for (int i = 0; i < numerosLista3.Length; i++)
            {
                listC.AddNode(numerosLista3[i]);

            }

            DoublyLinkedList mergedAscendente = Tarea_2.DoublyLinkedList.MergeSorted(listA, listB, 1);

            

            Assert.AreEqual(listC.Tail.Data, mergedAscendente.Tail.Data);
            
        }
    }
}