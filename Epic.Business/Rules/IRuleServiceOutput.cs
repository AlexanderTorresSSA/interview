namespace Epic.Business.Rules;

/// <summary>
/// Represents the output of a rule service execution.
/// </summary>
/// <typeparam name="T">The type of the processed model.</typeparam>
public interface IRuleServiceOutput<T>
{
    /// <summary>
    /// Gets the processed model.
    /// </summary>
    T Model { get; }

    /// <summary>
    /// Gets the list of property names that were modified during processing.
    /// </summary>
    IList<string> ModifiedProperties { get; }
}