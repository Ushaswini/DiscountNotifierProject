using System;
using System.Threading.Tasks;
using DiscountNotifierAPI.Models;
using DiscountNotifierAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountNotifierAPI.Controllers
{
    /// <summary>
    /// API to interact with regions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionsRepository _regionsRepository; 

        public RegionsController(IRegionsRepository regionsRepository)
        {
            this._regionsRepository = regionsRepository;
        }

        /// <summary>
        /// This API endpoint is used by the user to get list of regions
        /// </summary>
        /// <returns>List of Regions</returns>
        [HttpGet]
        public async Task<ActionResult> GetRegions()
        {
            try
            {
                return Ok(await _regionsRepository.GetRegions());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving regions");
            }
        }

        /// <summary>
        /// This API endpoint is used by the user to get a discount with a particular id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Region object</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Discount>> GetRegion(int id)
        {
            try
            {
                var region = await _regionsRepository.GetRegion(id);
                if (region != null)
                {   
                    return Ok(region);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving region of id:{id}");
            }
        }
    }
}
