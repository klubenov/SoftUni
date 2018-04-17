using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using P3IteratorTest;

namespace UnitTests
{
    [TestFixture]
    public class ListIteratorTests
    {
        [Test]
        public void TestValidConstructor()
        {
            ICollection<string> initialItems = new string[] {"a", "b", "c"};

            ListIterator listIterator = new ListIterator(initialItems);

            FieldInfo fieldInfo = typeof(ListIterator).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(List<string>));

            var internalList = (List<string>)fieldInfo.GetValue(listIterator);

            Assert.That(initialItems, Is.EquivalentTo(internalList));
        }

        [Test]
        public void TestInvalidConstructor()
        {
            Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
        }

        [Test]
        public void TestHasNextMethod()
        {
            ListIterator listIterator = new ListIterator(new string[] { "a", "b", "c" });

            FieldInfo fieldInfo = GetIndexFieldInfo();

            fieldInfo.SetValue(listIterator,1);
            Assert.That(() => listIterator.HasNext(), Is.EqualTo(true));
            fieldInfo.SetValue(listIterator, 2);
            Assert.That(() => listIterator.HasNext(), Is.EqualTo(false));
        }

        [Test]
        public void TestMoveMethod()
        {
            ListIterator listIterator = new ListIterator(new string[] { "a", "b", "c" });
            FieldInfo fieldInfo = GetIndexFieldInfo();

            int defaultIndex = (int)fieldInfo.GetValue(listIterator);

            Assert.That(() => listIterator.Move(), Is.EqualTo(true));
            Assert.That(defaultIndex + 1, Is.EqualTo(fieldInfo.GetValue(listIterator)));
            fieldInfo.SetValue(listIterator, 2);
            Assert.That(() => listIterator.Move(), Is.EqualTo(false));
        }

        [Test]
        public void TestPrintMethod()
        {
            var initialValues = new string[] {"a", "b", "c"};
            ListIterator listIterator = new ListIterator(initialValues);

            int indexToCheck = initialValues.Length - 2;

            FieldInfo fieldInfo = GetIndexFieldInfo();
            fieldInfo.SetValue(listIterator, indexToCheck);

            Assert.That(() => listIterator.Print(), Is.EqualTo(initialValues[indexToCheck]));
        }

        private static FieldInfo GetIndexFieldInfo()
        {
            return typeof(ListIterator).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int));
        }
    }
}
