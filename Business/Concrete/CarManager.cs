using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Logging;
using Core.Aspects.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validaton;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
           
        }

        [ValidationAspect(typeof(CarValidator))]//dogrulama kodları
        [SecuredOperation("car.add")]//yetki verme
        [CacheAspect]//Cacheye kopyalama 
        public IResult Add(Car car)
        {
            //IResult result = BusinessRules.Run(CheckIfBrandLimitExceded());
            //if (result != null)
            //{
                //return result;
            //}
            _carDal.Add(car);
            return new SuccessResult(Message.CarAdded);
        }
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Car carId)
        {
            _carDal.Delete(carId);
            return new SuccessResult(Message.CarDeleted);
        }

        [CacheAspect] //key,value ile tutulur.
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]//kullanımı 5 saniyeyi geçerse beni uyarıcak.
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==12)
            {
                return new ErrorDataResult<List<Car>>(Message.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Message.Carlisted);
        }

        public IDataResult<List<Car>> GetAllByBrand(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b=>b.BrandId==brandId));
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetAllByColor(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            if (DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Message.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetailDtos());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Message.CarUpdated);
        }
        //Business kuralı
        //private IResult CheckIfBrandLimitExceded()
        //{
            //var result = _brandService.GetAll();
            //if (result.Data.Count>15)
            //{
                //return new ErrorResult(Message.BrandLimitExceded);
            //}
           // return new SuccessResult();
        //}

    }
}
