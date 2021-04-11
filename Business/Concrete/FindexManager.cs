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
    public class FindexManager : IFindexService
    {
        private readonly IFindexDal _findeksDal;
        ICustomerService _customerService;
        ICarService _carService;


        public FindexManager(IFindexDal findeksDal, ICustomerService customerService, ICarService carService)
        {
            _findeksDal = findeksDal;
            _customerService = customerService;
            _carService = carService;

        }
        public IDataResult<Findex> GetById(int id)
        {
            return new SuccessDataResult<Findex>(_findeksDal.Get(f => f.Id == id));
        }

        public IDataResult<Findex> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<Findex>(_findeksDal.Get(f => f.Id == customerId));
        }

        public IDataResult<List<Findex>> GetAll()
        {
            return new SuccessDataResult<List<Findex>>(_findeksDal.GetAll());
        }

     

       

    }
}
