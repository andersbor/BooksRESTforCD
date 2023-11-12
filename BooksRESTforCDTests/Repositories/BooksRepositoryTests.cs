using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksRESTforCD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksRESTforCD.Models;

namespace BooksRESTforCD.Repositories.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {
        [TestMethod()]
        public void BooksRepositoryTest()
        {
          Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            BooksRepository booksRepository = new();
            IEnumerable<Book> books = booksRepository.GetAll();
            Assert.AreEqual(3, books.Count());

            books = booksRepository.GetAll(sortBy: "title");
            Assert.AreEqual("Benjamin", books.ToList()[1].Title);

            books = booksRepository.GetAll(sortBy: "price");
            Assert.AreEqual("20", books.ToList()[1].Title);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            
        }

        [TestMethod()]
        public void AddTest()
        {
           
        }

        [TestMethod()]
        public void DeleteTest()
        {
            
        }
    }
}