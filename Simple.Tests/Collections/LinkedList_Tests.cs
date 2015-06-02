using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Sorting;
using Simple.Collections;

namespace Simple.Tests.Collections
{
    [TestClass]
    public class LinkedList_Tests
    {
        #region <Methods>

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void LinkedList_Creation()
        {
            //creation
            var test = new LinkedList<int>();

            Assert.AreEqual(0, test.Count);

            //add first
            test.AddFirst(1);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(1, test[0]);

            //Clear all
            test.Clear();

            Assert.AreEqual(0, test.Count);

            //Add last
            test.AddLast(2);

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(2, test[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void LinkedList_AddSeveral()
        {
            //creation
            var test = new LinkedList<int>();

            Assert.AreEqual(0, test.Count);

            //add items
            test.AddFirst(2);
            test.AddFirst(1);
            test.AddLast(3);
            test.AddLast(4);
            test.AddLast(5);

            Assert.AreEqual(5, test.Count);

            //test foreach
            foreach (var i in test)
            {
                Assert.AreEqual(test[i - 1], i);
            }

            for (int i = 1; i <= 5; i++)
            {
                Assert.IsTrue(test.Contains(i));
                Assert.IsFalse(test.Contains(i*10));

                Assert.AreEqual(i - 1, test.IndexOf(i));
                Assert.AreEqual(-1, test.IndexOf(i*10));
            }

            Assert.IsFalse(test.Contains(0));
            Assert.IsFalse(test.Contains(6));

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void LinkedList_Removing()
        {
            //creation
            var test = new LinkedList<int>();

            //add items
            var fillItems = new Action<LinkedList<int>>(ints =>
            {
                test.AddFirst(1);
                test.AddLast(2);
                test.AddLast(3);
            });

            fillItems(test);
            Assert.AreEqual(3, test.Count);

            //check remove first
            test.RemoveFirst();
            Assert.AreEqual(2, test.Count);
            Assert.AreEqual(2, test[0]);
            Assert.AreEqual(3, test[1]);
            
            test.RemoveFirst();
            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(3, test[0]);

            test.RemoveFirst();
            Assert.AreEqual(0, test.Count);

            //check remove last
            fillItems(test);
            test.RemoveLast();
            Assert.AreEqual(2, test.Count);
            Assert.AreEqual(1, test[0]);
            Assert.AreEqual(2, test[1]);

            test.RemoveLast();
            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(1, test[0]);
            
            test.RemoveLast();
            Assert.AreEqual(0, test.Count);


            //check deleting first
            fillItems(test);
            test.RemoveAt(0);
            Assert.AreEqual(2, test.Count);
            Assert.AreEqual(2, test[0]);
            Assert.AreEqual(3, test[1]);
            
            test.RemoveAt(0);
            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(3, test[0]);

            test.RemoveAt(0);
            Assert.AreEqual(0, test.Count);

            //check deleting last
            fillItems(test);
            test.RemoveAt(2);
            Assert.AreEqual(2, test.Count);
            Assert.AreEqual(1, test[0]);
            Assert.AreEqual(2, test[1]);

            test.RemoveAt(1);
            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(1, test[0]);

            test.RemoveAt(0);
            Assert.AreEqual(0, test.Count);

            //check deleting particular item
            fillItems(test);
            test.Remove(2);
            Assert.AreEqual(2, test.Count);
            Assert.AreEqual(1, test[0]);
            Assert.AreEqual(3, test[1]);

            test.Remove(3);
            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(1, test[0]);

            test.Remove(1);
            Assert.AreEqual(0, test.Count);
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void LinkedList_Exceptions()
        {
            //yes, I know about ExpectedException attribute

            var test = new LinkedList<int>();

            try
            {
                var val = test[0];
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                var val = test[-1];
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                test.RemoveAt(-1);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                test.RemoveAt(100);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                test.RemoveFirst();
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
            }

            try
            {
                test.RemoveLast();
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
            }
        }


        #endregion
    }
}
