using AutoMapper;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using TC_CS03_API.Contracts;
using TC_CS03_API.Domain.Entity;
using TC_CS03_API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TC_CS03_API.API.v1
{
    /// <summary>
    /// Holds all methods to work on the reviews table
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewManager _reviewManager;
        private readonly IMapper _mapper;
        public ReviewController(IReviewManager reviewManager, IMapper mapper, ILogger<ReviewController> logger)
        {
            _reviewManager = reviewManager;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all reviews in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Review>>> Get()
        {
            try
            {
                return Ok(await _reviewManager.GetAllAsync());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while attempting to get all reviews");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get single review for a given ID
        /// </summary>
        /// <param name="id">The ID of the requested review</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Review>> Get(long id)
        {
            try
            {
                var review = await _reviewManager.GetByIdAsync(id);
                if (review != null)
                {
                    return Ok(review);
                }
                else
                {
                    var errorMessage = $"Record with id: {id} does not exist.";
                    _logger.LogDebug($"Get operation for id {id} returned a 404 error");
                    return NotFound(errorMessage); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while attempting to get reivew with id {id}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Create a new review
        /// </summary>
        /// <param name="dto">The review DTO you will have to pass in</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ApiResponse> Post([FromBody] ReviewDTO dto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var review = _mapper.Map<Review>(dto);

                    var newReview = await _reviewManager.CreateAsync(review);
                    return new ApiResponse("Created Successfully", newReview, 201);
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex, "Error when trying to insert.");
                    //return StatusCode(500);
                    throw;
                }
            }
            else
            {
                var errorsToLog = (from v in ModelState.AllErrors() select v.Message).Aggregate((i, j) => i + "\r\n" + j);
                _logger.LogError(errorsToLog);

                //return StatusCode(500);
                throw new ApiException(ModelState.AllErrors());
            }
        }

    }
}