using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagment.Application.Interfaces;
using UserManagment.Application.Models;
using UserManagment.Application.Models.Requests;

namespace UserManagment.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutController : ControllerBase
    {
        private readonly ILayoutService _layoutService;       

        public LayoutController(
            ILayoutService layoutService)
        {
           _layoutService = layoutService;
        }

        [HttpGet]        
        public async Task<IActionResult> GetAlertByIdAsync([FromQuery] LayoutsRequest request)
        {            
            var layout = await _layoutService.GetLayoutAsync(request);
            return Ok(layout);
        }

        /// <summary>
        /// Добавить\Обновить запись
        /// </summary>
        /// <param name="value">запись</param>        
        /// <returns>id</returns>
        [HttpPut]
        public async Task<ActionResult<int>> AddAsync([FromBody] LayoutDto dto)
        {
            var result = await _layoutService
                .SetLayoutAsync(dto);
            return Ok(result);
        }
    }
}
