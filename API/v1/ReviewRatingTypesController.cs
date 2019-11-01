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

namespace TC_CS03_API.API.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewRatingTypesController : ControllerBase
    {
        private readonly ILogger<ReviewRatingTypesController> _logger;
        private readonly IReviewRatingTypeManager _reviewRatingTypeManager;
        private readonly IMapper _mapper;
        public ReviewRatingTypesController(IReviewRatingTypeManager reviewRatingTypeManager, IMapper mapper, ILogger<ReviewRatingTypesController> logger)
        {
            _reviewRatingTypeManager = reviewRatingTypeManager;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all rating type codes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<ReviewRatingType>>> Get()
        {
            try
            {
                return Ok(await _reviewRatingTypeManager.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while attempting to get all review rating types");
                return StatusCode(500);
            }
        }
    }
}