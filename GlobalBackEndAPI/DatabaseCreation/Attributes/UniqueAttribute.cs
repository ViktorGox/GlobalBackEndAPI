namespace GlobalBackEndAPI.DatabaseCreation.Attributes
{
    /// <summary>
    /// Specifies that a property or a field should have the UNIQUE modifier. Used by model classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class UniqueAttribute : Attribute { }
}
