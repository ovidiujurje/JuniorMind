﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CatalogueRemake
{
    [TestClass]
    public class CatalogueRemakeTests
    {
        [TestMethod]
        public void SortStudentsAlphabetically()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            Catalog catalogue = new Catalog(new Student[] { one, two, three });
            CollectionAssert.AreEqual(new Student[] { two, three, one }, catalogue.SortAlphabetically().ToArray());
        }
        [TestMethod]
        public void SortStudentsbyGeneralMeanDescending()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
            Catalog catalogue = new Catalog (new Student[] { one, two, three });
            CollectionAssert.AreEqual(new Student[] { three, one, two }, catalogue.SortByGeneralMeanDescending().ToArray());
        }
        [TestMethod]
        public void GetStudentsWithSpecificGeneralMean()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 9, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 10 }) });
            Catalog catalogue = new Catalog(new Student[] { one, two, three });
            CollectionAssert.AreEqual(new Student[] { one, three }, catalogue.GetStudentsWithSpecificGeneralMean(9.5).ToArray());
        }
        [TestMethod]
        public void GetStudentsWithGreatestNumberOfTens()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 9, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 10 }) });
            Catalog catalogue = new Catalog(new Student[] { one, two, three });
            CollectionAssert.AreEqual(new Student[] { one, three }, catalogue.GetStudentsWithGreatestNumberOfASpecificGrade(10).ToArray());
        }
        [TestMethod]
        public void GetStudentsWithLowestGeneralMean()
        {
            Student three = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
            Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
            Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 9, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 10 }) });
            Catalog catalogue = new Catalog(new Student[] { one, two, three });
            CollectionAssert.AreEqual(new Student[] { two }, catalogue.GetStudentsWithLowestGeneralMean().ToArray());
        }
    }
}