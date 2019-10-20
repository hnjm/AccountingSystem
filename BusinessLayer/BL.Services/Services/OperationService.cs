using AutoMapper;
using BL.BusinessModels.Models;
using BL.Interfaces.Services;
using DL.Interfaces.UoW;
using DL.DomainModels.Entities;
using DL.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Module.Enums;
using BL.BusinessModels.DTO;
using System;

namespace BL.Services.Services
{
    public class OperationService : IOperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Operation> _operationRepository;
        
        public OperationService(IUnitOfWork unitOfWork, IRepository<Operation> operationRepository)
        {
            _unitOfWork = unitOfWork;
            _operationRepository = operationRepository;
        }

        public async Task<OperationModel> Add(OperationModel model)
        {
            var current = await GetCurrentAmmount();
            model.TotalAmount = model.Type == OperationType.Debit ? current + model.Amount : current - model.Amount;

            var entity = Mapper.Map<Operation>(model);

            var result = await _unitOfWork.Add(entity);
            await _unitOfWork.SaveChanges();

            return Mapper.Map<OperationModel>(result);
        }

        /*public async Task Update(OperationModel model)
        {
            var entity = Mapper.Map<Operation>(model);

            await _unitOfWork.Update(entity);
            await _unitOfWork.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var entity = await _operationRepository.GetById(id);
            _unitOfWork.Delete(entity);
            await _unitOfWork.SaveChanges();
        }*/

        public async Task<OperationModel> GetOperationById(int id)
        {
            var model = await _operationRepository.GetById(id);
            return Mapper.Map<OperationModel>(model);
        }

        public async Task<ICollection<OperationModel>> GetOperationsList(OperationType? type)
        {
            var models = type.HasValue ?
                await _operationRepository.GetCustom(x => x.Where(w => w.Type == type)) :
                await _operationRepository.GetAll();

            return Mapper.Map<ICollection<OperationModel>>(models);
        }

        

        public async Task<bool> IsValidCredit(decimal amount)
        {
            var current = await GetCurrentAmmount();
            return current >= amount;
        }

        public async Task<InfoModel> GetInfo()
        {
            var model = new InfoModel();
            model.CurrentAmount = await GetCurrentAmmount();
            model.LastTransactionDate = await GetLastTransactionDate();

            return model;
        }

        private async Task<decimal> GetCurrentAmmount()
        {
            var result = await _operationRepository.GetCustomSingle(x => x.OrderByDescending(o => o.CreateDate));
            return result?.TotalAmount ?? 0;
        }

        private async Task<DateTime> GetLastTransactionDate()
        {
            var result = await _operationRepository.GetCustomSingle(x => x.OrderByDescending(o => o.CreateDate));
            return result?.CreateDate ?? DateTime.Now;
        }
    }
}
