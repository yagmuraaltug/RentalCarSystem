﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result =
                   from car in filter == null ? context.Cars : context.Cars.Where(filter)
                   join brand in context.Brands on car.BrandId equals brand.BrandId
                   join color in context.Colors on car.ColorId equals color.ColorId
                   join image in context.CarImages on car.Id equals image.CarId
                   select new CarDetailDto
                   {
                       Id = car.Id,
                       BrandName = brand.BrandName,
                       ColorName = color.ColorName,
                       BrandId = brand.BrandId,
                       ColorId = color.ColorId,
                       DailyPrice = car.DailyPrice,
                       Description = car.Description,
                       ModelYear = car.ModelYear,
                       FindexNote = (int)car.FindexNote,
                       CarImageId = image.Id,
                       ImagePath = image.ImagePath,
                       Date = image.Date

                   };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarFilter(int brandId, int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result =
                   from car in context.Cars
                   join brand in context.Brands on car.BrandId equals brand.BrandId
                   join color in context.Colors on car.ColorId equals color.ColorId
                   join image in context.CarImages on car.Id equals image.CarId
                   where car.ColorId == colorId && brand.BrandId == brandId
                   select new CarDetailDto
                   {
                       Id = car.Id,
                       BrandName = brand.BrandName,
                       BrandId = brand.BrandId,
                       ColorId = color.ColorId,
                       ColorName = color.ColorName,
                       DailyPrice = car.DailyPrice,
                       Description = car.Description,
                       ModelYear = car.ModelYear,
                       CarImageId = image.Id,
                       ImagePath = image.ImagePath,
                       FindexNote = car.FindexNote,
                       Date = image.Date
                   };
                return result.ToList();
            }
        }


    }
}
