﻿using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using System;
using System.Linq;

namespace CoxinhaSystem.Domain.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IUnityOfWork _unitOfWork;

        public PhoneService(IPhoneRepository phoneRepository, IUnityOfWork unitOfWork)
        {
            _phoneRepository = phoneRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Phone> GetAll()
        {
            return _phoneRepository.GetAll();
        }

        public Phone GetById(int id)
        {
            return _phoneRepository.GetById(id);
        }

        public void Post(Phone phone)
        {
            //Verificando se existe
            if (GetById(phone.Id) != null)
            {
                throw new Exception("phone already exists");
            }

            _unitOfWork.Begin();
            _phoneRepository.Insert(phone);
            _unitOfWork.Commit();
        }

        public void Update(Phone phone)
        {
            _unitOfWork.Begin();
            _phoneRepository.Update(phone);
            _unitOfWork.Commit();
        }
    }
}
