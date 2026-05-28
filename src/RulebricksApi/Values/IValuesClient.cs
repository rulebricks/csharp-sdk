namespace RulebricksApi;

public partial interface IValuesClient
{
    /// <summary>
    /// Retrieve all dynamic values for the authenticated user. Use the 'include' parameter to control whether usage information is returned.
    /// </summary>
    WithRawResponseTask<IEnumerable<DynamicValue>> ListAsync(
        ListValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing dynamic values or add new ones for the authenticated user. Supports both flat and nested object structures. Nested objects are automatically flattened using dot notation and keys are converted to readable format (e.g., 'user_name' becomes 'User Name', nested 'user.contact_info.email' becomes 'User.Contact Info.Email').
    /// </summary>
    WithRawResponseTask<IEnumerable<DynamicValue>> UpdateAsync(
        UpdateValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific dynamic value for the authenticated user by its ID.
    /// </summary>
    WithRawResponseTask<SuccessMessage> DeleteAsync(
        DeleteValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
