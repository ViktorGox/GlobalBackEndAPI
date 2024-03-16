namespace GlobalBackEndAPI.DatabaseCreation.Attributes
{
    /// <summary>
    /// Specifies that a property or a field should be assigned as the primary key of the table. Used by model classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PrimaryKeyAttribute : Attribute { }
}
