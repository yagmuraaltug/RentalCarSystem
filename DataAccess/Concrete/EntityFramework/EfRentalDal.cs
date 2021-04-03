using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var table = from r in context.Rentals
                            join c in context.Cars on r.CarId equals c.Id
                            join cu in context.Customers on r.CustomerId equals cu.CustomerId
                            join u in context.Users on cu.UserId equals u.Id
                            select new RentalDetailDto()
                            {
                                ID = r.RentalId,
                                CarName = c.CarName,
                                FirstName = u.UserName,
                                LastName = u.UserLastName,
                                RentDate = r.RentDate,
                                ReturnDate = r.ReturnDate


                            };
                return table.ToList();
            }
        }
    }
}
