using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Moq;
using NUnit.Framework;
using P10TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem;

namespace UnitTests
{
    [TestFixture]
    public class TirePressureMonitoringSystemTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(15.3)]
        [TestCase(17)]
        [TestCase(21)]
        [TestCase(18.3695)]
        [TestCase(20.999)]
        [TestCase(23.9)]
        public void TestCheckMethod(double testPsiValue)
        {
            Mock<ISensor> sesnsorMock = new Mock<ISensor>();
            sesnsorMock.Setup(s => s.PopNextPressurePsiValue()).Returns(testPsiValue);

            Alarm alarm = new Alarm();
            FieldInfo[] fieldInfo = typeof(Alarm).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.First(fi => fi.FieldType == typeof(ISensor)).SetValue(alarm,sesnsorMock.Object);

            alarm.Check();

            bool isAlarmOn = (bool) fieldInfo.First(fi => fi.FieldType == typeof(bool)).GetValue(alarm);

            if (testPsiValue<17||testPsiValue>21)
            {
                Assert.That(isAlarmOn,Is.EqualTo(true));
            }
            else
            {
                Assert.That(isAlarmOn,Is.EqualTo(false));
            }
            
        }
    }
}
