using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library;
using NUnit.Framework;

namespace Model.Tests
{
    class RentalRepositoryTests
    {
        RentalRepositoryMock repositoryMock;

        static Rental rental1 = new Rental(1, new List<RentalItem>());
        static Rental rental2 = new Rental(2, new List<RentalItem>());
        static Rental rental3 = new Rental(3, new List<RentalItem>());

        public class RentalRepositoryMock : IRentalRepository
        {
            public readonly List<Rental> rentals = new List<Rental>()
            {
               rental1,rental2,rental3
            };

            public Rental Create()
            {
                int nextId = rentals.Count + 1;
                Rental rental = new Rental(nextId, new RentalItem[0]);
                rentals.Add(rental);

                return rental;
            }

            public Rental GetById(int id)
            {
                return rentals.Single(rental => rental.Id == id);
            }

            public void Update(Rental rental)
            {
                //database update
            }
        }

        [SetUp]
        public void Setup()
        {
            repositoryMock = new RentalRepositoryMock();
        }
        [Test, MaxTime(20)]
        public void GetRentalByCorrectId()
        {
            Assert.AreEqual(rental1, repositoryMock.GetById(1));
        }
        [Test, MaxTime(20)]
        public void GetRental_ByInvalidId_ReturnInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => repositoryMock.GetById(5));
        }
        [Test, MaxTime(20)]
        public void CreateNewRental_ByCorrectId_IsWorking()
        {
            Assert.AreEqual(4, repositoryMock.Create().Id);
        }
        [Test, MaxTime(20)]
        public void CreateNewRental_ReturnRightCountOfRentals()
        {
            repositoryMock.Create();
            Assert.AreEqual(4, repositoryMock.rentals.Count);
        }
    }
}
