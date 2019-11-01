using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TC_CS03_API.Domain.Entity
{
    /// <summary>
    /// Entity class representing REVIEW table
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Review ID which is also the primary key of the table
        /// </summary>
        public long REVIEW_ID { get; set; }
        /// <summary>
        /// The review rating type code, which foreign keys to the review rating type table
        /// </summary>
        public string REVIEW_RATING_TYPE_CD { get; set; }
        /// <summary>
        /// The desctive text of the review rating type
        /// </summary>
        public string REVIEW_RATING_TYPE_ETXT { get; set; }
        /// <summary>
        /// The comments left by the reviewer
        /// </summary>
        public string COMMENTS_TXT { get; set; }
    }
}