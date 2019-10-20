using BL.BusinessModels.DTO;
using BL.BusinessModels.Models;
using Module.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces.Services
{
    public interface IOperationService
    {
        Task<OperationModel> Add(OperationModel model);

        /*Task Update(OperationModel model);

        Task Delete(int id);*/

        Task<OperationModel> GetOperationById(int id);

        Task<ICollection<OperationModel>> GetOperationsList(OperationType? type);

        Task<bool> IsValidCredit(decimal amount);

        Task<InfoModel> GetInfo();
    }
}
