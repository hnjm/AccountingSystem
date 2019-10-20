using BL.Interfaces.Services;
using FluentValidation;
using Module.Enums;
using PL.WebAPI.ViewModels;

namespace PL.WebAPI.ViewModels.Validations
{
    public class OperationViewModelValidator : AbstractValidator<OperationViewModel>
    {
        private readonly IOperationService _opearitionService;

        public OperationViewModelValidator(IOperationService opearitionService)
        {
            _opearitionService = opearitionService;

            RuleFor(vm => vm.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .Must(x => x.Length >= 2 && x.Length <= 100).WithMessage("Discription should be between 2 and 100 chars");

            RuleFor(vm => vm.Amount)
                .NotEmpty().WithMessage("Amount cannot be empty")
                .GreaterThan(0).WithMessage("Amount should be greater than 0");

            RuleFor(vm => vm.Type)
                .NotEmpty().WithMessage("Type cannot be empty")
                .IsInEnum().WithMessage("Please specify the operation type");

            RuleFor(vm => new { vm.Type, vm.Amount })
                .MustAsync(async (model, cancel) => model.Type == OperationType.Credit ? await _opearitionService.IsValidCredit(model.Amount) : true)
                .OverridePropertyName("CustomValidation")
                .WithMessage("This transaction leads to negative amount");
        }
    }
}
