using FluentValidation;
using System;

namespace TC_CS03_API.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) class for REVIEW_RATING_TYPE.
    /// 
    /// Defines the model.
    /// </summary>
    public class ReviewRatingTypeDTO
    {
        /// <summary>
        /// Primary key for review rating type table
        /// </summary>
        public long REVIEW_RATING_TYPE_CD { get; set; }
        /// <summary>
        /// The text representing the review rating type
        /// </summary>
        public string REVIEW_RATING_TYPE_ETXT { get; set; }
    }

    /// <summary>
    /// Defines data validations for REVIEW_RATING_TYPE
    /// </summary>
    public class ReviewRatingTypeDTOValidator : AbstractValidator<ReviewRatingTypeDTO>
    {
        public ReviewRatingTypeDTOValidator()
        {
            RuleFor(o => o.REVIEW_RATING_TYPE_CD).NotEmpty();
            RuleFor(o => o.REVIEW_RATING_TYPE_ETXT).NotEmpty();
        }
    }
}
