using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
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
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult <List<CarImage>> GetCarImageById(int id);

    }
}
