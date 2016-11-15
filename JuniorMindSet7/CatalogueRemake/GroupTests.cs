using System;
using Xunit;
using System.Collections;

namespace CatalogueRemake
{
    public class GroupTests
    {
        [Fact]
        public void Insert1()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student> { three, two, one };
            students.Insert(1, two);
            Assert.Equal(new Student[] { three, two, two, one }, students);
        }
        [Fact]
        public void Insert2()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student>{ one, one, one, one, one, one, one, one, one, one };
            students.Insert(1, two);
            Assert.Equal(new Student[] { one, two, one, one, one, one, one, one, one, one, one }, students);
            Assert.Equal(20, students.ArrayLength);
        }
        [Fact]
        public void Add1()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student> { three, two, one };
            students.Add(two);
            Assert.Equal(new Student[] { three, two, one, two }, students);
        }
        [Fact]
        public void Add2()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student> { one, one, one, one, one, one, one, one, one, one };
            students.Add(two);
            Assert.Equal(new Student[] { one, one, one, one, one, one, one, one, one, one, two }, students);
            Assert.Equal(20, students.ArrayLength);
        }
        [Fact]
        public void Remove()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student> { three, two, one };
            students.Remove(two);
            Assert.Equal(new Student[] { three, one }, students);
        }
        [Fact]
        public void RemoveAt()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student> { three, two, one };
            students.RemoveAt(1);
            Assert.Equal(new Student[] { three, one }, students);
        }
        [Fact]
        public void Swap()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student> { three, two, one };
            students.SwapItemsAtIndexes(0, 1);
            Assert.Equal(new Student[] { two, three, one }, students);
        }
        [Fact]
        public void Count()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student> { three, two, one };
            Assert.Equal(3, students.Count);
        }
        [Fact]
        public void CheckEnumerator()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }),
                                                           new Discipline("English", new int[] { 10, 9 }),
                                                           new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }),
                                                      new Discipline("English", new int[] { 5 }),
                                                      new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }),
                                                     new Discipline("English", new int[] { 9 }),
                                                     new Discipline("Chemistry", new int[] { 8 }) });
            Group<Student> students = new Group<Student>{ three, two, one };
            Assert.Equal(new Student[] { three, two, one }, students);
        }
    }
}
