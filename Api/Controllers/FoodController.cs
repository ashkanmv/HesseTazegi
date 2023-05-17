using Application.Constracts.Infrastructure;
using Application.DTOs;
using Infrastructure.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        public readonly IFoodService _foodService;
        public readonly IFoodReplacementService _foodReplacementService;

        public FoodController(IFoodService foodService, IFoodReplacementService foodReplacementService)
        {
            _foodService = foodService;
            _foodReplacementService = foodReplacementService;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddFoodRequestDto requestDto)
        {
            try
            {
                return Ok(await _foodService.Add(requestDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FoodReplacement(FoodReplacementRequestDto requestDto)
        {
            try
            {
                return Ok(await _foodReplacementService.Add(requestDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        [HttpGet]
        [Route("[action]/{userId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(long userId)
        {
            try
            {
                return Ok(await _foodService.GetAll(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route("[action]/{foodId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetReplacement(long foodId)
        {
            try
            {
                return Ok(await _foodReplacementService.GetReplacement(foodId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
