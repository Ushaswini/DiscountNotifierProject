using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountNotifierAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountNotifierAPI.Controllers
{
    /// <summary>
    /// API to interact with Beacons
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BeaconsController : ControllerBase
    {
        private readonly IBeaconsRepository _beaconsRepository; 

        public BeaconsController(IBeaconsRepository beaconsRepository)
        {
            this._beaconsRepository = beaconsRepository;
        }

        /// <summary>
        /// This API returns the list of beacons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetBeacons()
        {
            try
            {
                return Ok(await _beaconsRepository.GetBeacons());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving beacons");
            }
        }
    }
}
