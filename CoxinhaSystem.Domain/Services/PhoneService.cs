using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using System;
using System.Linq;

namespace CoxinhaSystem.Domain.Services
{
    public class PhoneService : BaseService<Phone>, IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IBaseRepository<Phone> entityRepository, IUnityOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
            _phoneRepository = entityRepository as IPhoneRepository;
        }
    }
}
