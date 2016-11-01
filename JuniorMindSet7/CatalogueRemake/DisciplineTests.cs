using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class DisciplineTests
{
    [TestMethod]
    public void ShouldCalculateMean()
    {
        Discipline one = new Discipline("Math", new int[] { 7, 10 });
        Assert.AreEqual(8.5, one.Mean());
    }
    [TestMethod]
    public void ShouldCountNumberOfInstancesforSpeciffiecGrade()
    {
        Discipline one = new Discipline("Math", new int[] { 7, 10, 10 });
        Assert.AreEqual(2, one.Count(10));
    }
}
