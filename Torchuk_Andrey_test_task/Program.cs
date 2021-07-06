using System;
using NUnit.Framework;

namespace Torchuk_Andrey_test_task
{
    public static class Program
    {
        public static void Main()
        {
            SolutionTest tests = new SolutionTest();
            tests.ExampleTestMerge();
            tests.ExampleTestCut();
            tests.MyTestEmpty();
        }
    }
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void ExampleTestMerge()
        {
            CustomStructure target = new CustomStructure();
            target.Add("collection1", new int[] { 1, 2, 4, 5 });
            target.Add("collection2", new int[] { 1, 2, 3, 4, 5 });
            target.Add("collection4", new int[] { 4, 5 });
            CustomStructure source = new CustomStructure();
            source.Add("collection1", new int[] { 2, 3, 5, 6, 2, 10 });
            source.Add("collection2", new int[] { 2, 4, 5, 20 });
            source.Add("collection3", new int[] { 4, 5 });
            source.Add("collection4", new int[] { 4, 5 });
            CustomStructure expected = new CustomStructure();
            expected.Add("collection1", new int[] { 1, 2, 3, 4, 5, 6, 10 });
            expected.Add("collection2", new int[] { 1, 2, 3, 4, 5, 20 });
            expected.Add("collection3", new int[] { 4, 5 });
            expected.Add("collection4", new int[] { 4, 5 });

            target.Merge(source);
            Assert.AreEqual(expected, target);
        }
        [Test]
        public void ExampleTestCut()
        {
            CustomStructure target = new CustomStructure();
            target.Add("collection1", new int[] { 1, 2, 4, 5 });
            target.Add("collection2", new int[] { 1, 2, 3, 4, 5 });
            target.Add("collection4", new int[] { 4, 5 });
            CustomStructure source = new CustomStructure();
            source.Add("collection1", new int[] { 2, 3, 5, 6, 2, 10 });
            source.Add("collection2", new int[] { 2, 4, 5, 20 });
            source.Add("collection3", new int[] { 4, 5 });
            source.Add("collection4", new int[] { 4, 5 });
            CustomStructure expected = new CustomStructure();
            expected.Add("collection1", new int[] { 1, 4 });
            expected.Add("collection2", new int[] { 1, 3 });

            target.Cut(source);
            Assert.AreEqual(expected, target);
        }
        [Test]
        public void MyTestEmpty()
        {
            CustomStructure target = new CustomStructure();
            target.Add("collection1", new int[] {});
            target.Add("collection2", new int[] { 1, 2, 3, 4, 5 });
            CustomStructure source = new CustomStructure();
            source.Add("collection1", new int[] { 1, 2, 3, 4, 5 });
            source.Add("collection2", new int[] {});
            CustomStructure emptySource = new CustomStructure();
            emptySource.Add("collection1", new int[] { });
            emptySource.Add("collection2", new int[] { });
            CustomStructure expected = new CustomStructure();
            expected.Add("collection1", new int[] { 1, 2, 3, 4, 5 });
            expected.Add("collection2", new int[] { 1, 2, 3, 4, 5 });

            target.Merge(source);
            Assert.AreEqual(expected, target);
            target.Cut(emptySource);
            Assert.AreEqual(expected, target);
        }
    }
}
