using BusinessLogicLayer.Services;
using DataAccessLayer.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task24_Tests
{
    [TestFixture]
    public class GuestRoomTests
    {
        int callCount = 0;
        int addUser = 0;
        int saveChanges = 0;
        
        [Test]
        public void Setup()
        {
            var mockContext = new Mock<LibraryDbContext>();
        }
    }
}
