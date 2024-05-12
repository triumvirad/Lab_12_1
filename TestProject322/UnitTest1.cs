using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using ClassLibrary;
using Lab_12_1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodCreateMyList()
        {
            MyList<MusicalInstrument> muz = new MyList<MusicalInstrument>(5);
            Assert.AreEqual(4, muz.Count);
        }
        [TestMethod]
        public void TestMethodToString1()
        {
            string test = "Бибизяна";
            var mmm = new Point<string>(test);
            Assert.AreEqual(test, mmm.ToString());
        }
        [TestMethod]
        public void TestMethodToString2()
        {
            int test = 12;
            var mmm = new Point<int>(test);
            string test2 = "12";
            Assert.AreEqual(test2, mmm.ToString());
        }
        [TestMethod]
        public void TestMethodGetHashCode1()
        {
            int test = 99;
            var mmm = new Point<int>(test);
            int hashCode = mmm.GetHashCode();
            Assert.AreEqual(test.GetHashCode(), hashCode);
        }
        [TestMethod]
        public void TestMethodGetHashCode2()
        {
            int test = 17;
            var mmm = new Point<int>(test);
            int hashCode = mmm.GetHashCode();
            Assert.AreEqual(test.GetHashCode(), hashCode);
        }
        [TestMethod]
        public void TestMethodAddToBeginForEmptyList1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToBegin(muz);
            Assert.AreEqual(muz, myList.beg.Data);
        }
        [TestMethod]
        public void TestMethodAddToBeginForEmptyList2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToBegin(muz);
            Assert.AreEqual(muz, myList.end.Data);
        }
        [TestMethod]
        public void TestMethodAddToBeginForEmptyList3()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToBegin(muz);
            Assert.AreEqual(muz, myList.FindItem(muz).Data);
        }
        [TestMethod]
        public void TestMethodAddToEndForEmptyList1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToEnd(muz);
            Assert.AreEqual(muz, myList.beg.Data);
        }
        [TestMethod]
        public void TestMethodAddToEndForEmptyList2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToEnd(muz);
            Assert.AreEqual(muz, myList.end.Data);
        }
        [TestMethod]
        public void TestMethodAddToEndForEmptyList3()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToEnd(muz);
            Assert.AreEqual(muz, myList.FindItem(muz).Data);
        }
        [TestMethod]
        public void TestMethodAddToBeginForNotEmptyList1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToBegin(muz);
            Assert.AreEqual(muz, myList.beg.Data);
        }
        [TestMethod]
        public void TestMethodAddToBeginForNotEmptyList2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToBegin(muz);
            Assert.AreEqual(muz, myList.FindItem(muz).Data);
        }
        [TestMethod]
        public void TestMethodAddToEndForNotEmptyList1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToEnd(muz);
            Assert.AreEqual(muz, myList.end.Data);
        }
        [TestMethod]
        public void TestMethodAddToEndForNotEmptyList2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToEnd(muz);
            Assert.AreEqual(muz, myList.FindItem(muz).Data);
        }
        [TestMethod]
        public void TestMethodFindItemByTitle()
        {
            MusicalInstrument mz = new MusicalInstrument();
            mz.RandomInit();
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            myList.AddToBegin(mz);
            Assert.AreEqual(5, myList.Count);
        }
        [TestMethod]
        public void TestMethodFindItemFromBeguin()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument();
            myList.AddToBegin(muz);
            Assert.IsNotNull(myList.FindItem(muz));
        }
        [TestMethod]
        public void TestMethodFindItemFromEnd()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument();
            myList.AddToEnd(muz);
            Assert.IsNotNull(myList.FindItem(muz));
        }
        [TestMethod]
        public void TestMethodFindItemInEmptyList()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument();
            Assert.IsNull(myList.FindItem(muz));
        }
        [TestMethod]
        public void TestMethodFindItemNotExist()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            Assert.IsNull(myList.FindItem(muz));
        }
        [TestMethod]
        public void TestMethodRemoveItemInEmptyList()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument();
            Assert.ThrowsException<Exception>(() => { myList.RemoveItem(muz); });
        }
        [TestMethod]
        public void TestMethodRemoveItemNotExist1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            Assert.AreEqual(false, myList.RemoveItem(muz));
        }
        [TestMethod]
        public void TestMethodRemoveItemNotExist2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            Assert.IsNull(myList.FindItem(muz));
        }
        [TestMethod]
        public void TestMethodRemoveItemWhereOneElemInList1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToBegin(muz);
            Assert.AreEqual(true, myList.RemoveItem(muz));
        }
        [TestMethod]
        public void TestMethodRemoveItemFirst1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(2);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToBegin(muz);
            Assert.AreEqual(true, myList.RemoveItem(muz));
        }
        [TestMethod]
        public void TestMethodRemoveItemFirst2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(2);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToBegin(muz);
            Assert.IsNotNull(myList.FindItem(muz));
        }
        [TestMethod]
        public void TestMethodRemoveItemLast1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(2);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToEnd(muz);
            Assert.AreEqual(true, myList.RemoveItem(muz));
        }
        [TestMethod]
        public void TestMethodRemoveItemLast2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(2);
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            myList.AddToEnd(muz);
            Assert.IsNotNull(myList.FindItem(muz));
        }
        [TestMethod]
        public void TestMethodRemoveItemClassic1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MusicalInstrument muz1 = new MusicalInstrument("Бибизяна", 10);
            MusicalInstrument muz2 = new MusicalInstrument("Чупапимуняня", 50);
            myList.AddToBegin(muz1);
            myList.AddToBegin(muz2);
            Assert.AreEqual(true, myList.RemoveItem(muz1));
        }
        [TestMethod]
        public void TestMethodRemoveItemClassic2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(2);
            MusicalInstrument muz1 = new MusicalInstrument("Бибизяна", 10);
            MusicalInstrument muz2 = new MusicalInstrument("Чупапимуняня", 50);
            myList.AddToBegin(muz1);
            myList.AddToBegin(muz2);
            Assert.IsNotNull(myList.FindItem(muz1));
        }
        [TestMethod]
        public void TestMethodCloneList1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MyList<MusicalInstrument> myListClone = myList.CloneList();
            Assert.IsNotNull(myListClone);
        }
        [TestMethod]
        public void TestMethodCloneList2()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            MyList<MusicalInstrument> myListClone = myList.CloneList();
            Assert.AreEqual(5, myListClone.Count);
        }
        [TestMethod]
        public void TestMethodCloneListEmpty()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MyList<MusicalInstrument> myListClone = myList.CloneList();
            int count = myList.Count;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void TestMethodRemoveItem21()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            Assert.ThrowsException<Exception>(() => { myList.RemoveItem2(muz); });
        }
        [TestMethod]
        public void TestMethodRemoveItem22()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz1 = new MusicalInstrument("Бибизяна", 10);
            MusicalInstrument muz2 = new MusicalInstrument("Гамарджоба", 15);
            MusicalInstrument muz3 = new MusicalInstrument("Бибизяна", 10);
            MusicalInstrument muz4 = new MusicalInstrument("Гамарджоба", 15);
            myList.AddToBegin(muz1);
            myList.AddToBegin(muz2);
            myList.AddToBegin(muz3);
            myList.AddToBegin(muz4);
            myList.RemoveItem2(muz2);
            Assert.AreNotEqual(true, myList.FindItem(muz1));
            Assert.AreNotEqual(true, myList.FindItem(muz2));
            Assert.AreNotEqual(true, myList.FindItem(muz3));
            Assert.AreEqual(true, myList.FindItem(muz4));
        }
        [TestMethod]
        public void TestMethodAddByPlace1()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            MusicalInstrument muz = new MusicalInstrument("Бибизяна", 10);
            Assert.ThrowsException<Exception>(() => { myList.RemoveItem2(muz); });
        }
        [TestMethod]
        public void TestMethodAddByPlace()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>();
            for (int i = 0; i < 3; i++)
            {
                myList.AddToBegin(new MusicalInstrument("Бибизяна", 10));

            }
            myList.AddByPlace();
            Point<MusicalInstrument>? current = myList.beg;
            int cnt = 0;
            int error = 0;
            while (current != null)
            {
                if (cnt % 2 != 0)
                {
                    if (current.Data.Title == "Бибизяна")
                    {
                        error++;
                    }
                }
                else
                {
                    if (current.Data.Title != "Бибизяна")
                    {
                        error++;
                    }
                }
                cnt++;
                current = current.Next;
            }
            Assert.AreEqual(0, error);
        }
        [TestMethod]
        public void TestMethodClearList()
        {
            MyList<MusicalInstrument> myList = new MyList<MusicalInstrument>(5);
            myList.ClearList();
            Point<MusicalInstrument>? current = myList.beg;
            int cnt = 0;
            while (current != null)
            {
                cnt++;
                current = current.Next;
            }
            Assert.AreEqual(0, cnt);
        }
    }
}
