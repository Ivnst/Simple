using System;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Trees;

namespace Simple.Tests.Trees
{
    [TestClass]
    public class BinarySearchTree_Tests
    {
        [TestMethod]
        public void BinarySearchTree_AddTopItem()
        {
            var bst = new BinarySearchTree<int, string>();

            Assert.IsNull(bst.TopItem);

            //add top item
            bst.Insert(100, "100");

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsNull(bst.TopItem.Parent);

            //remove top item
            bst.Remove(100);

            //check top item
            Assert.IsNull(bst.TopItem);
            Assert.IsFalse(bst.ContainsKey(100));
        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndRight()
        {
            var bst = new BinarySearchTree<int, string>();

            //add top item
            bst.Insert(100, "100");
            bst.Insert(150, "150");//goes to right

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            var second = bst.TopItem.Right;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(150));
            Assert.AreEqual("150", bst.Find(150));
            Assert.AreEqual("150", second.Value);
            Assert.AreEqual(150, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //remove top item
            bst.Remove(100);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsFalse(bst.ContainsKey(100));
            Assert.IsTrue(bst.ContainsKey(150));
            Assert.AreEqual("150", bst.Find(150));
            Assert.AreEqual("150", bst.TopItem.Value);
            Assert.AreEqual(150, bst.TopItem.Key);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Parent);

        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndLeft()
        {
            var bst = new BinarySearchTree<int, string>();

            //add top item
            bst.Insert(100, "100");
            bst.Insert(50, "50");//goes to left

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);
            
            //check second item
            var second = bst.TopItem.Left;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(50));
            Assert.AreEqual("50", bst.Find(50));
            Assert.AreEqual("50", second.Value);
            Assert.AreEqual(50, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //remove top item
            bst.Remove(100);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsFalse(bst.ContainsKey(100));
            Assert.IsTrue(bst.ContainsKey(50));
            Assert.AreEqual("50", bst.Find(50));
            Assert.AreEqual("50", bst.TopItem.Value);
            Assert.AreEqual(50, bst.TopItem.Key);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Parent);

        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndRightAndRight()
        {
            var bst = new BinarySearchTree<int, string>();

            bst.Insert(100, "100");
            bst.Insert(150, "150");//goes to right
            bst.Insert(200, "200");//goes to right of right

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            var second = bst.TopItem.Right;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(150));
            Assert.AreEqual("150", bst.Find(150));
            Assert.AreEqual("150", second.Value);
            Assert.AreEqual(150, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNull(second.Left);
            Assert.IsNotNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check thirs item
            var third = second.Right;
            Assert.IsNotNull(third);
            Assert.IsTrue(bst.ContainsKey(200));
            Assert.AreEqual("200", bst.Find(200));
            Assert.AreEqual("200", third.Value);
            Assert.AreEqual(200, third.Key);
            Assert.IsNotNull(third.Parent);
            Assert.AreEqual(second, third.Parent);

            //remove second item
            bst.Remove(150);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            second = bst.TopItem.Right;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(200));
            Assert.AreEqual("200", bst.Find(200));
            Assert.AreEqual("200", second.Value);
            Assert.AreEqual(200, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNull(second.Left);
            Assert.IsNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check deleted item
            Assert.IsFalse(bst.ContainsKey(150));
        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndRightAndLeft()
        {
            var bst = new BinarySearchTree<int, string>();

            bst.Insert(100, "100");
            bst.Insert(150, "150");//goes to right
            bst.Insert(125, "125");//goes to left of right

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            var second = bst.TopItem.Right;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(150));
            Assert.AreEqual("150", bst.Find(150));
            Assert.AreEqual("150", second.Value);
            Assert.AreEqual(150, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNotNull(second.Left);
            Assert.IsNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check third item
            var third = second.Left;
            Assert.IsNotNull(third);
            Assert.IsTrue(bst.ContainsKey(125));
            Assert.AreEqual("125", bst.Find(125));
            Assert.AreEqual("125", third.Value);
            Assert.AreEqual(125, third.Key);
            Assert.IsNotNull(third.Parent);
            Assert.AreEqual(second, third.Parent);

            //remove second item
            bst.Remove(150);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            second = bst.TopItem.Right;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(125));
            Assert.AreEqual("125", bst.Find(125));
            Assert.AreEqual("125", second.Value);
            Assert.AreEqual(125, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNull(second.Left);
            Assert.IsNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check deleted item
            Assert.IsFalse(bst.ContainsKey(150));
        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndLeftAndLeft()
        {
            var bst = new BinarySearchTree<int, string>();

            bst.Insert(100, "100");
            bst.Insert(50, "50");//goes to left
            bst.Insert(25, "25");//goes to left of left

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            var second = bst.TopItem.Left;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(50));
            Assert.AreEqual("50", bst.Find(50));
            Assert.AreEqual("50", second.Value);
            Assert.AreEqual(50, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNotNull(second.Left);
            Assert.IsNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check third item
            var third = second.Left;
            Assert.IsNotNull(third);
            Assert.IsTrue(bst.ContainsKey(25));
            Assert.AreEqual("25", bst.Find(25));
            Assert.AreEqual("25", third.Value);
            Assert.AreEqual(25, third.Key);
            Assert.IsNotNull(third.Parent);
            Assert.AreEqual(second, third.Parent);

            //remove second item
            bst.Remove(50);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            second = bst.TopItem.Left;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(25));
            Assert.AreEqual("25", bst.Find(25));
            Assert.AreEqual("25", second.Value);
            Assert.AreEqual(25, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNull(second.Left);
            Assert.IsNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check deleted item
            Assert.IsFalse(bst.ContainsKey(50));
        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndLeftAndRight()
        {
            var bst = new BinarySearchTree<int, string>();

            bst.Insert(100, "100");
            bst.Insert(50, "50");//goes to left
            bst.Insert(75, "75");//goes to right of left

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            var second = bst.TopItem.Left;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(50));
            Assert.AreEqual("50", bst.Find(50));
            Assert.AreEqual("50", second.Value);
            Assert.AreEqual(50, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNull(second.Left);
            Assert.IsNotNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check third item
            var third = second.Right;
            Assert.IsNotNull(third);
            Assert.IsTrue(bst.ContainsKey(75));
            Assert.AreEqual("75", bst.Find(75));
            Assert.AreEqual("75", third.Value);
            Assert.AreEqual(75, third.Key);
            Assert.IsNotNull(third.Parent);
            Assert.AreEqual(second, third.Parent);

            //remove second item
            bst.Remove(50);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            second = bst.TopItem.Left;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(75));
            Assert.AreEqual("75", bst.Find(75));
            Assert.AreEqual("75", second.Value);
            Assert.AreEqual(75, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNull(second.Left);
            Assert.IsNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check deleted item
            Assert.IsFalse(bst.ContainsKey(50));
        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndRightAndBoth()
        {
            var bst = new BinarySearchTree<int, string>();

            bst.Insert(100, "100");
            bst.Insert(150, "150");//goes to right
            bst.Insert(125, "125");//goes to left of right
            bst.Insert(200, "200");//goes to right of right

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            var second = bst.TopItem.Right;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(150));
            Assert.AreEqual("150", bst.Find(150));
            Assert.AreEqual("150", second.Value);
            Assert.AreEqual(150, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNotNull(second.Left);
            Assert.IsNotNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check third (left) item
            var third = second.Right;
            Assert.IsNotNull(third);
            Assert.IsTrue(bst.ContainsKey(200));
            Assert.AreEqual("200", bst.Find(200));
            Assert.AreEqual("200", third.Value);
            Assert.AreEqual(200, third.Key);
            Assert.IsNotNull(third.Parent);
            Assert.AreEqual(second, third.Parent);

            //check third (right) item
            var forth = second.Left;
            Assert.IsNotNull(forth);
            Assert.IsTrue(bst.ContainsKey(125));
            Assert.AreEqual("125", bst.Find(125));
            Assert.AreEqual("125", forth.Value);
            Assert.AreEqual(125, forth.Key);
            Assert.IsNotNull(forth.Parent);
            Assert.AreEqual(second, forth.Parent);

            //remove second item
            bst.Remove(150);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            second = bst.TopItem.Right;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(125));
            Assert.AreEqual("125", bst.Find(125));
            Assert.AreEqual("125", second.Value);
            Assert.AreEqual(125, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNull(second.Left);
            Assert.IsNotNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check third item
            third = second.Right;
            Assert.IsNotNull(third);
            Assert.IsTrue(bst.ContainsKey(200));
            Assert.AreEqual("200", bst.Find(200));
            Assert.AreEqual("200", third.Value);
            Assert.AreEqual(200, third.Key);
            Assert.IsNotNull(third.Parent);
            Assert.IsNull(third.Left);
            Assert.IsNull(third.Right);
            Assert.AreEqual(second, third.Parent);



            //check deleted item
            Assert.IsFalse(bst.ContainsKey(150));
        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndLeftAndBoth()
        {
            var bst = new BinarySearchTree<int, string>();

            bst.Insert(100, "100");
            bst.Insert(50, "50");//goes to left
            bst.Insert(25, "25");//goes to left of left
            bst.Insert(75, "75");//goes to right of left

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            var second = bst.TopItem.Left;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(50));
            Assert.AreEqual("50", bst.Find(50));
            Assert.AreEqual("50", second.Value);
            Assert.AreEqual(50, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNotNull(second.Left);
            Assert.IsNotNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check third (left) item
            var third = second.Right;
            Assert.IsNotNull(third);
            Assert.IsTrue(bst.ContainsKey(75));
            Assert.AreEqual("75", bst.Find(75));
            Assert.AreEqual("75", third.Value);
            Assert.AreEqual(75, third.Key);
            Assert.IsNotNull(third.Parent);
            Assert.AreEqual(second, third.Parent);

            //check third (right) item
            var forth = second.Left;
            Assert.IsNotNull(forth);
            Assert.IsTrue(bst.ContainsKey(25));
            Assert.AreEqual("25", bst.Find(25));
            Assert.AreEqual("25", forth.Value);
            Assert.AreEqual(25, forth.Key);
            Assert.IsNotNull(forth.Parent);
            Assert.AreEqual(second, forth.Parent);

            //remove second item
            bst.Remove(50);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check second item
            second = bst.TopItem.Left;
            Assert.IsNotNull(second);
            Assert.IsTrue(bst.ContainsKey(25));
            Assert.AreEqual("25", bst.Find(25));
            Assert.AreEqual("25", second.Value);
            Assert.AreEqual(25, second.Key);
            Assert.IsNotNull(second.Parent);
            Assert.IsNull(second.Left);
            Assert.IsNotNull(second.Right);
            Assert.AreEqual(bst.TopItem, second.Parent);

            //check third item
            third = second.Right;
            Assert.IsNotNull(third);
            Assert.IsTrue(bst.ContainsKey(75));
            Assert.AreEqual("75", bst.Find(75));
            Assert.AreEqual("75", third.Value);
            Assert.AreEqual(75, third.Key);
            Assert.IsNotNull(third.Parent);
            Assert.IsNull(third.Left);
            Assert.IsNull(third.Right);
            Assert.AreEqual(second, third.Parent);

            //check deleted item
            Assert.IsFalse(bst.ContainsKey(50));
        }

        [TestMethod]
        public void BinarySearchTree_AddTopAndBoth()
        {
            var bst = new BinarySearchTree<int, string>();

            bst.Insert(100, "100");
            bst.Insert(50, "50");//goes to left
            bst.Insert(25, "25");//goes to left of left
            bst.Insert(75, "75");//goes to right of left
            bst.Insert(150, "150");//goes to right
            bst.Insert(125, "125");//goes to left of right
            bst.Insert(175, "175");//goes to right of right

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(100));
            Assert.AreEqual("100", bst.Find(100));
            Assert.AreEqual("100", bst.TopItem.Value);
            Assert.AreEqual(100, bst.TopItem.Key);

            //check left item
            var left = bst.TopItem.Left;
            Assert.IsNotNull(left);
            Assert.IsTrue(bst.ContainsKey(50));
            Assert.AreEqual("50", bst.Find(50));
            Assert.AreEqual("50", left.Value);
            Assert.AreEqual(50, left.Key);
            Assert.IsNotNull(left.Parent);
            Assert.IsNotNull(left.Left);
            Assert.IsNotNull(left.Right);
            Assert.AreEqual(bst.TopItem, left.Parent);

            //check left right item
            var leftRight = left.Right;
            Assert.IsNotNull(leftRight);
            Assert.IsTrue(bst.ContainsKey(75));
            Assert.AreEqual("75", bst.Find(75));
            Assert.AreEqual("75", leftRight.Value);
            Assert.AreEqual(75, leftRight.Key);
            Assert.IsNotNull(leftRight.Parent);
            Assert.AreEqual(left, leftRight.Parent);

            //check left left item
            var leftLeft = left.Left;
            Assert.IsNotNull(leftLeft);
            Assert.IsTrue(bst.ContainsKey(25));
            Assert.AreEqual("25", bst.Find(25));
            Assert.AreEqual("25", leftLeft.Value);
            Assert.AreEqual(25, leftLeft.Key);
            Assert.IsNotNull(leftLeft.Parent);
            Assert.AreEqual(left, leftLeft.Parent);

            //check right item
            var right = bst.TopItem.Right;
            Assert.IsNotNull(right);
            Assert.IsTrue(bst.ContainsKey(150));
            Assert.AreEqual("150", bst.Find(150));
            Assert.AreEqual("150", right.Value);
            Assert.AreEqual(150, right.Key);
            Assert.IsNotNull(right.Parent);
            Assert.IsNotNull(right.Left);
            Assert.IsNotNull(right.Right);
            Assert.AreEqual(bst.TopItem, right.Parent);

            //check right right item
            var rightRigth = right.Right;
            Assert.IsNotNull(rightRigth);
            Assert.IsTrue(bst.ContainsKey(175));
            Assert.AreEqual("175", bst.Find(175));
            Assert.AreEqual("175", rightRigth.Value);
            Assert.AreEqual(175, rightRigth.Key);
            Assert.IsNotNull(rightRigth.Parent);
            Assert.AreEqual(right, rightRigth.Parent);

            //check third (right) item
            var rightLeft = right.Left;
            Assert.IsNotNull(rightLeft);
            Assert.IsTrue(bst.ContainsKey(125));
            Assert.AreEqual("125", bst.Find(125));
            Assert.AreEqual("125", rightLeft.Value);
            Assert.AreEqual(125, rightLeft.Key);
            Assert.IsNotNull(rightLeft.Parent);
            Assert.AreEqual(right, rightLeft.Parent);

            //remove top item
            bst.Remove(100);

            //check top item
            Assert.IsNotNull(bst.TopItem);
            Assert.IsNull(bst.TopItem.Parent);
            Assert.IsNotNull(bst.TopItem.Left);
            Assert.IsNotNull(bst.TopItem.Right);
            Assert.IsTrue(bst.ContainsKey(75));
            Assert.AreEqual("75", bst.Find(75));
            Assert.AreEqual("75", bst.TopItem.Value);
            Assert.AreEqual(75, bst.TopItem.Key);

            //check left item
            left = bst.TopItem.Left;
            Assert.IsNotNull(left);
            Assert.IsTrue(bst.ContainsKey(50));
            Assert.AreEqual("50", bst.Find(50));
            Assert.AreEqual("50", left.Value);
            Assert.AreEqual(50, left.Key);
            Assert.IsNotNull(left.Parent);
            Assert.IsNotNull(left.Left);
            Assert.IsNull(left.Right);
            Assert.AreEqual(bst.TopItem, left.Parent);

            //left right item is null

            //check left left item
            leftLeft = left.Left;
            Assert.IsNotNull(leftLeft);
            Assert.IsTrue(bst.ContainsKey(25));
            Assert.AreEqual("25", bst.Find(25));
            Assert.AreEqual("25", leftLeft.Value);
            Assert.AreEqual(25, leftLeft.Key);
            Assert.IsNotNull(leftLeft.Parent);
            Assert.AreEqual(left, leftLeft.Parent);

            //check right item
            right = bst.TopItem.Right;
            Assert.IsNotNull(right);
            Assert.IsTrue(bst.ContainsKey(150));
            Assert.AreEqual("150", bst.Find(150));
            Assert.AreEqual("150", right.Value);
            Assert.AreEqual(150, right.Key);
            Assert.IsNotNull(right.Parent);
            Assert.IsNotNull(right.Left);
            Assert.IsNotNull(right.Right);
            Assert.AreEqual(bst.TopItem, right.Parent);

            //check right right item
            rightRigth = right.Right;
            Assert.IsNotNull(rightRigth);
            Assert.IsTrue(bst.ContainsKey(175));
            Assert.AreEqual("175", bst.Find(175));
            Assert.AreEqual("175", rightRigth.Value);
            Assert.AreEqual(175, rightRigth.Key);
            Assert.IsNotNull(rightRigth.Parent);
            Assert.AreEqual(right, rightRigth.Parent);

            //check third (right) item
            rightLeft = right.Left;
            Assert.IsNotNull(rightLeft);
            Assert.IsTrue(bst.ContainsKey(125));
            Assert.AreEqual("125", bst.Find(125));
            Assert.AreEqual("125", rightLeft.Value);
            Assert.AreEqual(125, rightLeft.Key);
            Assert.IsNotNull(rightLeft.Parent);
            Assert.AreEqual(right, rightLeft.Parent);

            //check deleted item
            Assert.IsFalse(bst.ContainsKey(100));
        }

        [TestMethod]
        public void BinarySearchTree_RandomAccess()
        {
            var dict = new Dictionary<int, int>();
            var bst = new BinarySearchTree<int, int>();

            var rnd = new Random((int)DateTime.Now.Ticks%10000);
            
            for (var i = 0; i < 100000; i++)
            {
                var action = rnd.Next(3);

                switch (action)
                {
                    case 0://add
                        var val = 0;
                        do
                        {
                            val = rnd.Next(1000);
                        } while (dict.ContainsKey(val));
                        dict.Add(val, val);
                        bst.Insert(val, val);

                        break;
                    case 1://find
                        var val2 = rnd.Next(1000);
                        Assert.AreEqual(dict.ContainsKey(val2), bst.ContainsKey(val2));

                        break;
                    case 2://remove
                        if (dict.Count > 0)
                        {
                            var val3 = 0;
                            do
                            {
                                val3 = rnd.Next(1000);
                            } while (!dict.ContainsKey(val3));
                            dict.Remove(val3);
                            bst.Remove(val3);
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
