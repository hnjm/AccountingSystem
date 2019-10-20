using System;
using DL.DomainModels.Base;
using System.ComponentModel.DataAnnotations;
using Module.Enums;

namespace DL.DomainModels.Entities
{
    public class Operation : BaseEntity
    {
        [MaxLength(100)]
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public OperationType Type { get; set; }
        
        public decimal TotalAmount { get; set; }
    }
}
