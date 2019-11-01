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
    /// Concrete class that implements DBFactoryBase base class and IReviewRatingTypeManager interface.
    /// 
    /// Implements DB operations for REVIEW_RATING_TYPE table.
    /// </summary>
    public class ReviewRatingTypeManager : DBFactoryBase, IReviewRatingTypeManager
    {
        public ReviewRatingTypeManager(IConfiguration config) : base(config)
        {

        }
        public async Task<IEnumerable<ReviewRatingType>> GetAllAsync()
        {
            try
            {
                string sqlQuery = $@"
                    SELECT * FROM REVIEW_RATING_TYPE
                    ";
                return await DbQueryAsync<ReviewRatingType>(sqlQuery);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }
        }

        public async Task<ReviewRatingType> GetByIdAsync(object id)
        {
            try
            {
                string sqlQuery = $@"
                    SELECT
                        *
                    FROM
                        REVIEW_RATING_TYPE
                    WHERE
                        REVIEW_RATING_TYPE_CD = @ID
                    ";
                return await DbQuerySingleAsync<ReviewRatingType>(sqlQuery, new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }
        }

        public async Task<long> CreateAsync(ReviewRatingType reviewRatingType)
        {
            try
            {
                string sqlQuery = $@"
                    INSERT INTO 
                    REVIEW_RATING_TYPE (
                        REVIEW_RATING_TYPE_CD,
                        REVIEW_RATING_TYPE_ETXT) 
                    VALUES (
                        @REVIEW_RATING_TYPE_CD,
                        @REVIEW_RATING_TYPE_ETXT)
                    SELECT CAST(SCOPE_IDENTITY() as bigint)
                    ";
                return await DbQuerySingleAsync<long>(sqlQuery, reviewRatingType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "something bad");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(ReviewRatingType reviewRatingType)
        {
            try
            {
                string sqlQuery = $@"
                    IF EXISTS (SELECT 1 FROM REVIEW_RATING_TYPE WHERE REVIEW_RATING_TYPE_CD = @ID) 
                    UPDATE
                        REVIEW_RATING_TYPE
                    SET
                        REVIEW_RATING_TYPE_CD = @REVIEW_RATING_TYPE_CD,
                        REVIEW_RATING_TYPE_ETXT = @REVIEW_RATING_TYPE_ETXT
                    WHERE
                        REVIEW_RATING_TYPE_CD = @ID
                    ";
                return await DbExecuteAsync<bool>(sqlQuery, reviewRatingType);
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
                    IF EXISTS (SELECT 1 FROM REVIEW_RATING_TYPE WHERE ID = @ID)
                    DELETE
                        REVIEW_RATING_TYPE
                    WHERE
                        REVIEW_RATING_TYPE_CD = @ID
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
                        REVIEW_RATING_TYPE
                    WHERE
                        REVIEW_RATING_TYPE_CD = @ID
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
