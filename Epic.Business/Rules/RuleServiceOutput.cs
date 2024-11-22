namespace Epic.Business.Rules;

/// <summary>
/// Concrete implementation of <see cref="IRuleServiceOutput{T}"/>.
/// </summary>
/// <typeparam name="T">The type of the processed model.</typeparam>
public class RuleServiceOutput<T> : IRuleServiceOutput<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RuleServiceOutput{T}"/> class.
    /// </summary>
    /// <param name="model">The processed model.</param>
    /// <param name="modifiedProperties">The list of modified property names.</param>
    public RuleServiceOutput(T model, IList<string> modifiedProperties)
    {
        Model = model;
        ModifiedProperties = modifiedProperties;
    }
    public T Model { get; }

    public IList<string> ModifiedProperties { get; }
}