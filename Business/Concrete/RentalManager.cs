using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IFindexService _findexService;
        ICarService _carService;
        ICustomerService _customerService;


        public RentalManager(IRentalDal rentalDal, IFindexService findexService, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _findexService = findexService;
            _carService = carService;
            _customerService = customerService;
        }
        // [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRented);

        }

    
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {

            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(Messages.CustomerListed);
        }

        public IDataResult<Rental> GetByReturnDate(DateTime returndate)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.ReturnDate == returndate));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public bool AvailableCars(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId && c.ReturnDate == null);

            if (result.Count > 0)
            {
                return false;
            }
            return true;
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }


    }
}
