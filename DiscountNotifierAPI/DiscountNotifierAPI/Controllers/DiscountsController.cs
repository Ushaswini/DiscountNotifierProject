using System;
using System.Threading.Tasks;
using DiscountNotifierAPI.Models;
using DiscountNotifierAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscountNotifierAPI.Controllers
{
    /// <summary>
    /// API to interact with discounts
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;   

        public DiscountsController(IDiscountRepository discountRepository)
        {
            this._discountRepository = discountRepository;
        }

        /// <summary>
        /// This API endpoint is used by the user to get list of discounts
        /// </summary>
        /// <returns>List of discounts</returns>
        [HttpGet]
        public async Task<ActionResult> GetDiscounts()
        {
            try
            {
                return Ok(await _discountRepository.GetDiscounts());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving discounts");
            }
        }

        /// <summary>
        /// This API endpoint is used by the user to get a discount with a particular id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Discount object</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Discount>> GetDiscount(int id)
        {
            try
            {
                var discount = await _discountRepository.GetDiscount(id);
                if (discount != null)
                {
                    return Ok(discount);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving discount of id:{id}");
            }
        }

        /// <summary>
        /// This API endpoint is used by the user to get list of discounts available for a particular beacon region
        /// </summary>
        /// <param name="beaconId"></param>
        /// <returns>List of discounts</returns>
        [HttpGet]
        [Route("beaconId:{int}")]
        public async Task<ActionResult>GetDiscounts(string beaconId)
        {
            try
            {
                return Ok(await _discountRepository.GetDiscountsByBeacon(beaconId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving discounts for beacon id: {beaconId}");
            }
        }
    }
}
