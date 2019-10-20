using Module.Enums;
using System;

namespace PL.WebAPI.ViewModels
{
    public class OperationViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public OperationType Type { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime Date { get; set; }
    }
}
