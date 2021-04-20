using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace OK.Tech.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly List<string> _errors;

        public MainController()
        {
            _errors = new List<string>();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (!IsOperationValid())
            {
                return BadRequest(new { success = false, errors = _errors, data = result });
            }

            return Ok(new { success = true, data = result });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState, object result = null)
        {
            if (!modelState.IsValid)
            {
                var errorMessages = modelState.Values.SelectMany(ms => ms.Errors).Select(me => me.ErrorMessage);
                _errors.AddRange(errorMessages.ToList());

                return BadRequest(new { success = false, errors = _errors, data = result });
            }

            return Ok(new { success = true, data = result });
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }
    }
}
