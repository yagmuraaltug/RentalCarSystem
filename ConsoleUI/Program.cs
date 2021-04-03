using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetails();
            //RentalAdded();
           
         
            
        }


        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + "/" + car.BrandName);
                }

            }
            else
            {
                Console.WriteLine(result.Messages);
            }
        }


        //private static void RentalAdded()
        //{
        //    RentalManager rentalManager = new RentalManager(new EfRentalDal());
        //    var result = rentalManager.Add(new Rental { CarId = 3, CustomerId = 5, RentDate = DateTime.Now, ReturnDate = new DateTime(2021, 04, 03) });
        //    if (result.Success == true)
        //    {
        //        Console.WriteLine(result.Messages);
        //        return;
        //    }
        //}
    }
}
