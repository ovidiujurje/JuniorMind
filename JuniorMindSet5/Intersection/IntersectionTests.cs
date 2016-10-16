using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intersection
{
    [TestClass]
    public class IntersectionTests
    {
        [TestMethod]
        public void ShouldReturnFirstIntersectionPoint()
        {
            Direction[] directions = new Direction[] { Direction.Right, Direction.Right, Direction.Up, Direction.Left, Direction.Down, Direction.Down };
            Assert.AreEqual("First intersection point is at (0, 1)", GetFirstIntersectionPoint(directions));
        }
        [TestMethod]
        public void ShouldReturnNoIntersectionPoint()
        {
            Direction[] directions = new Direction[] { Direction.Right, Direction.Right, Direction.Up, Direction.Left, Direction.Up, Direction.Up };
            Assert.AreEqual("No point of intersection", GetFirstIntersectionPoint(directions));
        }
        struct Point
        {
            public int longitude;
            public int latitude;
            public Point (int longitude, int latitude)
            {
                this.longitude = longitude;
                this.latitude = latitude;
            }
        }
        public enum Direction { Up, Down, Right, Left }
        string GetFirstIntersectionPoint( Direction[] directions)
        {
            string result = "No point of intersection";
            Point[] sectionPoints = new Point[1];
            foreach(Direction arrow in directions)
            {
                Array.Resize(ref sectionPoints, sectionPoints.Length + 1);
                sectionPoints[sectionPoints.Length - 1] = sectionPoints[sectionPoints.Length - 2];
                switch (arrow)
                {
                    case Direction.Up:
                        sectionPoints[sectionPoints.Length - 1].longitude++;
                        break;
                    case Direction.Down:
                        sectionPoints[sectionPoints.Length - 1].longitude--;
                        break;
                    case Direction.Right:
                        sectionPoints[sectionPoints.Length - 1].latitude++;
                        break;
                    case Direction.Left:
                        sectionPoints[sectionPoints.Length - 1].latitude--;
                        break;
                }
                if (DoesItContain(sectionPoints))
                {
                    result = "First intersection point is at (" + sectionPoints[sectionPoints.Length - 1].longitude + ", " + sectionPoints[sectionPoints.Length - 1]. latitude + ")";
                    break;
                }
            }
            return result;
        }
        bool DoesItContain(Point[] givenArray)
        {
            for (int i = 0; i < givenArray.Length - 1; i++)
                if (givenArray[i].longitude == givenArray[givenArray.Length - 1].longitude && givenArray[i].latitude == givenArray[givenArray.Length - 1].latitude)
                    return true;
            return false;
        }
    }
}
