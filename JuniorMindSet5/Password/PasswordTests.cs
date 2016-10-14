using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void GenerateRandomPasswordContainingLowerCaseLetters()
        {
            Assert.AreNotEqual("abcde", GeneratePassword(5));
        }
        public enum LowerCaseLetters { a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z }
        string GeneratePassword(int passwordLength)
        {
            string password = string.Empty;
            Random randomCharacter = new Random();
            for (int i = 0; i <= passwordLength; i++)
            {
                password += (LowerCaseLetters)randomCharacter.Next(26);
            }
            return password;
        }
    }
}
