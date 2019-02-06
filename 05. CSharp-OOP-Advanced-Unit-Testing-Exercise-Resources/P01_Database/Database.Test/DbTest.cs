using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using P01_Database;

namespace DbTest
{
    [TestFixture]
    public class DbTest
    {

        [Test]
        public void EmptyConstructorShouldInitElements()
        {
            Database db = new Database();

            Type type = typeof(Database);

            var field = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "elemetns").GetValue(db);

            var actualResult = field.Length;
            var expectedResult = 16;

            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }
    }
}