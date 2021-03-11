using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if(rental.ReturnDate==null)
            {
               return new ErrorResult(Messages.ReturnDateInvalid);


            }
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
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.ReturnDate == returndate));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
