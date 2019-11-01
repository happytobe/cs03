using TC_CS03_API.Contracts;
using TC_CS03_API.Data;
using TC_CS03_API.Domain.Entity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace TC_CS03_API.Domain
{
    /// <summary>
    /// Concrete class that implements DBFactoryBase base class and IReviewManager interface.
    /// 
    /// Implements DB operations for REVIEW table.
    /// </summary>
    public class ReviewManager : DBFactoryBase, IReviewManager
    {
        public ReviewManager(IConfiguration config) : base(config)
        {

        }
        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            try
            {
                string sqlQuery = $@"   
                    SELECT  
                        R.REVIEW_ID,
                        R.REVIEW_RATING_TYPE_CD,
                        R.COMMENTS_TXT,
                        RRT.REVIEW_RATING_TYPE_ETXT
                    FROM
                        REVIEW R 
                        JOIN REVIEW_RATING_TYPE RRT ON R.REVIEW_RATING_TYPE_CD = RRT.REVIEW_RATING_TYPE_CD
                    ";
                return await DbQueryAsync<Review>(sqlQuery);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }

        }

        public async Task<Review> GetByIdAsync(Object id)
        {
            try
            {
                string sqlQuery = $@"   
                    SELECT  
                        R.REVIEW_ID,
                        R.REVIEW_RATING_TYPE_CD,
                        R.COMMENTS_TXT,
                        RRT.REVIEW_RATING_TYPE_ETXT
                    FROM
                        REVIEW R 
                        JOIN REVIEW_RATING_TYPE RRT ON R.REVIEW_RATING_TYPE_CD = RRT.REVIEW_RATING_TYPE_CD
                    WHERE
                        REVIEW_ID = @ID
                    ";
                return await DbQuerySingleAsync<Review>(sqlQuery, new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }
        }

        public async Task<long> CreateAsync(Review review)
        {
            try
            {
                string sqlQuery = $@"
                    INSERT INTO 
                    REVIEW (
                        REVIEW_RATING_TYPE_CD,
                        COMMENTS_TXT) 
                    VALUES (
                        @REVIEW_RATING_TYPE_CD,
                        @COMMENTS_TXT)
                    SELECT CAST(SCOPE_IDENTITY() as bigint)
                    ";
                return await DbQuerySingleAsync<long>(sqlQuery, review);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Review review)
        {
            try
            {
                string sqlQuery = $@"
                    IF EXISTS (SELECT 1 FROM REVIEW WHERE REVIEW_ID = @ID)
                    UPDATE
                        REVIEW
                    SET
                        REVIEW_RATING_TYPE_CD = @REVIEW_RATING_TYPE_CD,
                        COMMENTS_TXT = @COMMENTS_TXT
                    WHERE
                        REVIEW_ID = @ID
                    ";
                return await DbExecuteAsync<bool>(sqlQuery, review);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                string sqlQuery = $@"
                    IF EXISTS (SELECT 1 FROM REVIEW WHERE ID = @ID)
                    DELETE
                        REVIEW
                    WHERE
                        REVIEW_ID = @ID
                    ";
                return await DbExecuteAsync<bool>(sqlQuery, new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }
        }

        public async Task<bool> ExistAsync(object id)
        {
            try
            {
                string sqlQuery = $@"
                    SELECT
                        COUNT(1)
                    FROM
                        REVIEW
                    WHERE
                        REVIEW_ID = @ID
                    ";
                return await DbExecuteScalarAsync(sqlQuery, new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }
        }
    }
}
