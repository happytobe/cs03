using FluentValidation;
using System;

namespace TC_CS03_API.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) class for REVIEW.
    /// 
    /// Defines the model.
    /// </summary>
    public class ReviewDTO
    {
        /// <summary>
        /// The foreign key to review rating type table representing the reviewer's rating
        /// </summary>
        public string REVIEW_RATING_TYPE_CD { get; set; }
        /// <summary>
        /// The comments left by the reviers
        /// </summary>
        public string COMMENTS_TXT { get; set; }
    }

    /// <summary>
    /// Defines data validations for REVIEW_RATING_TYPE
    /// </summary>
    public class ReviewDTOValidator : AbstractValidator<ReviewDTO>
    {
        public ReviewDTOValidator()
        {
            RuleFor(o => o.REVIEW_RATING_TYPE_CD).NotEmpty();
            RuleFor(o => o.COMMENTS_TXT).Length(0, 250);
        }
    }
}
