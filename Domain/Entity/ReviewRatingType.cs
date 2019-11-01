using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TC_CS03_API.Domain.Entity
{
    /// <summary>
    /// Entity class representing REVIEW table
    /// </summary>
    public class ReviewRatingType
    {
        /// <summary>
        /// Primary key for review rating type table
        /// </summary>
        public long REVIEW_RATING_TYPE_CD { get; set; }
        /// <summary>
        /// Descriptive text of review rating type
        /// </summary>
        public string REVIEW_RATING_TYPE_ETXT { get; set; }
    }
}