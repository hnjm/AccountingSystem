using System;
using BL.BusinessModels.Base;
using Module.Enums;

namespace BL.BusinessModels.Models
{
    public class OperationModel : BaseModel
    {
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public OperationType Type { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
