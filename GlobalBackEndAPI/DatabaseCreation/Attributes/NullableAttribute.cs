namespace GlobalBackEndAPI.DatabaseCreation.Attributes
{
    /// <summary>
    /// Specifies that a property or a field can be null. Used by model classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NullableAttribute : Attribute { }
}
