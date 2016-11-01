using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void ShouldCalculateGeneralMean()
    {
        Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 8 }) });
        Assert.AreEqual(8.5, one.GeneralMean());
    }
    [TestMethod]
    public void ShouldCountNumberOfInstancesforSpeciffiecGrade()
    {
        Student one = new Student("Chira Iulia", new Discipline[] { new Discipline("Math", new int[] { 7, 10 }), new Discipline("English", new int[] { 9 }), new Discipline("Chemistry", new int[] { 10 }) });
        Assert.AreEqual(2, one.Count(10));
    }
    [TestMethod]
    public void ShouldDetermineIfOneAlphabeticallyPrecedesTwo()
    {
        Student one = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
        Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
        Assert.AreEqual(true, two.DetermineIfAlphabeticallyPrecedes(one));
    }
    [TestMethod]
    public void ShouldDetermineIfTwoAlphabeticallyPrecedesOne()
    {
        Student one = new Student("Chereches Voicu", new Discipline[] { new Discipline("Math", new int[] { 10 }), new Discipline("English", new int[] { 10, 9 }), new Discipline("Chemistry", new int[] { 9 }) });
        Student two = new Student("Brete Origen", new Discipline[] { new Discipline("Math", new int[] { 5 }), new Discipline("English", new int[] { 5 }), new Discipline("Chemistry", new int[] { 8, 6 }) });
        Assert.AreEqual(true, two.DetermineIfAlphabeticallyPrecedes(one));
    }
}