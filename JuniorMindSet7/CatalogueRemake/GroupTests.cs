using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogueRemake
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void AddLast()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student>(new Student[] { three, two, one });
            students.AddLast(two);
            CollectionAssert.AreEqual(new Group<Student>(new Student[] { three, two, one, two }), students);
        }
        [TestMethod]
        public void Insert()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student>(new Student[] { three, two, one });
            students.Insert(1, two);
            CollectionAssert.AreEqual(new Group<Student>(new Student[] { three, two, two, one }), students);
        }
        [TestMethod]
        public void Clear()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student>(new Student[] { three, two, one });
            students.Clear();
            CollectionAssert.AreEqual(new Group<Student>(new Student[] { }), students);
        }
        [TestMethod]
        public void Remove()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student>(new Student[] { three, two, one });
            students.Remove(two);
            CollectionAssert.AreEqual(new Group<Student>(new Student[] { three, one }), students);
        }
        [TestMethod]
        public void RemoveAt()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student>(new Student[] { three, two, one });
            students.RemoveAt(1);
            CollectionAssert.AreEqual(new Group<Student>(new Student[] { three, one }), students);
        }
        [TestMethod]
        public void Swap()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student>(new Student[] { three, two, one });
            students.SwapItemsAtIndexes(0, 1);
            CollectionAssert.AreEqual(new Group<Student>(new Student[] { two, three, one }), students);
        }
    }
}
