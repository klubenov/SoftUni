using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using P1Database;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 5, 15, 456, 100009 })]
        [TestCase(new int[] { 4, 2, 4, 1 })]
        public void TestConstructorWithValidData(int[] validData)
        {
            Database database = new Database(validData);

            FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
                | BindingFlags.Instance).First(f =>f.FieldType == typeof(int[]));

            IEnumerable<int> initialisedValues = ((int[])fieldInfo.GetValue(database)).Take(validData.Length);

            Assert.That(((int[])fieldInfo.GetValue(database)).Count(), Is.EqualTo(16));
            Assert.That(initialisedValues,Is.EquivalentTo(validData));
        }

        [Test]
        public void TestConstructorWithInvalidData()
        {
            var invalidData = new int[17];

            Assert.That(() => new Database(invalidData), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[0], 5)]
        [TestCase(new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15}, 5)]
        [TestCase(new int[]{1,2,3}, 5)]
        [TestCase(new int[0], int.MaxValue)]
        [TestCase(new int[0], int.MinValue)]
        public void TestValidAddMethod(int[] initialValues, int numberToAdd)
        {

            Database database = new Database(initialValues);

            database.Add(numberToAdd);

            FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
                                                             | BindingFlags.Instance).First(f => f.FieldType == typeof(int[]));

            int[] addedValue = ((int[])fieldInfo.GetValue(database)).Skip(initialValues.Length).Take(1).ToArray();

            Assert.That(addedValue[0],Is.EqualTo(numberToAdd));

        }

        [Test]
        public void TestInvalidAddMethod()
        {
            Database databaseToGetDefaultCapacity = new Database(new int[]{1});
            FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
                                                             | BindingFlags.Instance).First(f => f.FieldType == typeof(int[]));

            var defaultCapacity = ((int[]) fieldInfo.GetValue(databaseToGetDefaultCapacity)).Length;

            Database database = new Database(new int[defaultCapacity]);
            
            Assert.That(() => database.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestValidRemove(int[] initialValues)
        {
            Database database = new Database(initialValues);

            database.Remove();

            FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
                                                             | BindingFlags.Instance).First(f => f.FieldType == typeof(int[]));

            var initialisedValues = ((int[]) fieldInfo.GetValue(database)).Take(initialValues.Length).ToArray();

            if (initialisedValues.Length>1)
            {
                Assert.That(initialValues[initialValues.Length - 2], Is.EqualTo(initialisedValues[initialisedValues.Length-2]));
                Assert.That(initialisedValues[initialisedValues.Length - 1], Is.EqualTo(default(int)));
            }
            else
            {
                Assert.That(initialisedValues[initialisedValues.Length - 1], Is.EqualTo(default(int)));
            }
        }

        [Test]
        public void TestInvalidRemove()
        {
            Database database = new Database(new int[0]);

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFetch()
        {
            var initialValues = new int[] {1, 2, 3, 4, 5, 6};

            Database database = new Database(initialValues);

            var fetchValues = database.Fetch();

            Assert.That(initialValues,Is.EquivalentTo(fetchValues));
        }
    }
}
