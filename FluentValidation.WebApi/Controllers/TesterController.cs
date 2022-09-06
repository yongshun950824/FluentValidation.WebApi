using FluentValidation.Results;
using FluentValidation.WebApi.Models;
using FluentValidation.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation.WebApi.Controllers
{
    /// <summary>
    /// Working with IValidator injection service.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TesterController : ControllerBase
    {
        private readonly IValidator<Tester> _validator;

        public TesterController(IValidator<Tester> validator)
        {
            _validator = validator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            ResponseModel response = new ResponseModel();

            Tester tester = new Tester
            {
                FirstName = "",
                LastName = "Murugan",
                Email = "abc",
                Experience = 2
            };

            var validationResult = await _validator.ValidateAsync(tester);
            if (!validationResult.IsValid)
            {
                response.IsValid = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    response.ValidationMessages.Add(failure.ErrorMessage);
                }
            }

            return Ok(response);
        }
    }
}
