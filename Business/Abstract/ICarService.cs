using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
       
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car carId);
        IDataResult<List<Car>> GetAll();

        IDataResult<Car> GetById(int carId);

        IDataResult<List<Car>> GetAllByBrand(int brandId);

        IDataResult<List<CarDetailDto>> GetCarDetailDtos();

        IDataResult<List<Car>> GetAllByBrandId(int Id);

        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetAllByColor(int colorId);
    }
}
