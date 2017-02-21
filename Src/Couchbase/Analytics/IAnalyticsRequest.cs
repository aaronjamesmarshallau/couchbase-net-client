﻿using System.Collections.Generic;
using Couchbase.Configuration.Client;

namespace Couchbase.Analytics
{
    public interface IAnalyticsRequest
    {
        /// <summary>
        /// Gets the original analytics statement.
        /// </summary>
        /// <returns>The original statement as a <see cref="string"/></returns>
        string OriginalStatement { get; }

        /// <summary>
        /// Gets the context identifier for the analytics request. Useful for debugging.
        /// </summary>
        /// <returns>The unique request ID.</returns>.
        /// <remarks>
        /// This value changes for every request.
        /// </remarks>
        string CurrentContextId { get; }

        /// <summary>
        /// Gets a <see cref="IDictionary{K, V}"/> of the name/value pairs to be POSTed to the analytics service.
        /// </summary>
        /// <returns>The <see cref="IDictionary{K, V}"/> of the name/value pairs to be POSTed to the analytics service.</returns>
        IDictionary<string, object> GetFormValues();

        /// <summary>
        /// Gets the JSON representation of this analytics request's parameters.
        /// </summary>
        /// <returns>The form values as a JSON object.</returns>
        string GetFormValuesAsJson();

        /// <summary>
        /// True if the request exceeded it's <see cref="ClientConfiguration.AnalyticsRequestTimeout"/>.
        /// </summary>
        /// <returns><c>true</c> if the request times out; otherwise <c>false</c>.</returns>
        bool TimedOut();

        /// <summary>
        /// Sets a analytics statement to be executed.
        /// </summary>
        /// <param name="statement">Any valid SQL++ statement for.</param>
        /// <returns>A reference to the current <see cref="IAnalyticsRequest"/> for method chaining.</returns>
        IAnalyticsRequest Statement(string statement);

        /// <summary>
        /// Adds a set of credentials to the list of credentials, in the form of username/password.
        /// </summary>
        /// <param name="username">The bucket or username.</param>
        /// <param name="password">The password of the bucket.</param>
        /// <param name="isAdmin">True if connecting as an admin.</param>
        /// <returns>A reference to the current <see cref="IAnalyticsRequest"/> for method chaining.</returns>
        /// <remarks>Optional.</remarks>
        IAnalyticsRequest Credentials(string username, string password, bool isAdmin);

        /// <summary>
        /// A user supplied piece of data supplied with the request to the sevice. Any result will also contain the same data.
        /// </summary>
        /// <param name="contextId"></param>
        /// <returns>A reference to the current <see cref="IAnalyticsRequest"/> for method chaining.</returns>
        /// <remarks>Optional.</remarks>
        /// <remarks>Maximum allowed size is 64 characters. A clientContextID longer than 64 characters is cut off at 64 characters.</remarks>
        IAnalyticsRequest ClientContextId(string contextId);

        /// <summary>
        /// Sets whether the analytics query and result JSON formatting will be intended.
        /// NOTE: Setting <see cref="Pretty"/> to true can have a negative performance impact due to larger payloads.
        /// </summary>
        /// <param name="pretty">if set to <c>true</c> [pretty].</param>
        /// <returns>A reference to the current <see cref="IAnalyticsRequest"/> for method chaining.</returns>
        /// <remarks>Optional.</remarks>
        IAnalyticsRequest Pretty(bool pretty);

        /// <summary>
        /// Specifies that metrics should be returned with query results.
        /// </summary>
        /// <param name="includeMetrics">True to return query metrics.</param>
        /// <returns>
        /// A reference to the current <see cref="IAnalyticsRequest" /> for method chaining.
        /// </returns>
        /// <remarks>
        /// Optional.
        /// </remarks>
        IAnalyticsRequest IncludeMetrics(bool includeMetrics);
    }
}