using Newtonsoft.Json.Linq;

namespace Moodify.DB
{
    internal interface IDBHandler
    {
        /// <summary>
        /// Executes the aggregation query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The result of the query. -1 is returned in case of a failed query.</returns>
        int ExecuteAggregationQuery(string query);

        /// <summary>
        /// Executes a query with no result expected (i.e: Insert, Update or Delete).
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>true if succeeded, false o.w.</returns>
        bool ExecuteNoResult(string query);

        /// <summary>
        /// Executes the query and returns the results in a JArray.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A JArray containing the results.</returns>
        JArray ExecuteWithResults(string query);
    }
}