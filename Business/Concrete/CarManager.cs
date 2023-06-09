using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utulities.Business;
using Core.Utulities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;

        public CarManager(ICarDal carDal, IColorService colorService)
        {
            _carDal = carDal;
            _colorService = colorService;
        }


        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            BusinessRules.Run(CheckIfProductExists(car.Description), CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfSameColor(car.ColorId));

            _carDal.Add(car);
            return new SuccessResult(Messages.AddedCar);


        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedCar);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedCar);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //business codes

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedCar);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.FailListedCar);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ListedCar);
            }

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == Id), Messages.ListedCarByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == Id), Messages.ListedCarByColorId);
        }

        private IResult CheckIfProductExists(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.CartNameAlreadyExistsError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfSameColor(int colorId)
        {
            var result = _colorService.GetAll();
            if (result.Data.Count > 50)
            {
                return new ErrorResult(Messages.CountOfColorError);
            }
            return new SuccessResult();
        }


    }
}
