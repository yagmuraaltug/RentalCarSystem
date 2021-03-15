using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddCarImage(IFormFile formFile, CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IResult UpdateCarImage(IFormFile formFile, CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetCarImageById(int id);


    }
}
