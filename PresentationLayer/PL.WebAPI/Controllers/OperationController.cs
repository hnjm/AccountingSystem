using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BL.Interfaces.Services;
using BL.BusinessModels.Models;
using System.Collections.Generic;
using AutoMapper;
using PL.WebAPI.ViewModels;
using System;
using Module.Enums;
using System.Linq;

namespace PL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OperationController : Controller
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        #region CRUD

        /*[HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _operationService.GetOperationById(id);
            if (model == null)
                return BadRequest(new { message = "Operation not found" });

            var op = Mapper.Map<OperationViewModel>(model);

            return Json(op);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OperationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var op = Mapper.Map<OperationModel>(model);
            await _operationService.Add(op);

            return new OkObjectResult(new { message = "Operation has been created" });
        }

        /*[HttpPut]
        public async Task<IActionResult> Update([FromBody]OperationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var op = Mapper.Map<OperationModel>(model);
            await _operationService.Update(op);

            return new OkObjectResult(new { message = $"Operation has been updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var op = await _operationService.GetOperationById(id);
            if (op == null)
                return BadRequest(new { message = $"Operation not found" });

            await _operationService.Delete(id);

            return new OkObjectResult(new { message = $"Operation has been deleted" });
        }*/

        [HttpGet("{type:int?}")]
        public async Task<IActionResult> GetOperations(OperationType? type)
        {
            var list = await _operationService.GetOperationsList(type);
            var result = Mapper.Map<ICollection<OperationViewModel>>(list);

            return Json(result);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            var model = await _operationService.GetInfo();
            return Json(model);
        }

        #endregion
    }
}

