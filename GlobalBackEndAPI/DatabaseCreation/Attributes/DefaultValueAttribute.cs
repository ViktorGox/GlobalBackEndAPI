namespace GlobalBackEndAPI.DatabaseCreation.Attributes
{
    // Default value of properties utilizing the default C# way (int n { get; set; } = 2;) does not work for non nullable values. Thus, this attribute.
    /// <summary>
    /// Specifies default value. <br></br>
    /// Takes the toString() from the <paramref name="defaultValue"/>. <br></br> 
    /// For current <see cref="DateOnly"/> and <see cref="DateTime"/> enter "Now", casing does not matter.<br></br>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DefaultValueAttribute(object defaultValue) : Attribute
    {
        public object DefaultValue { get; } = defaultValue;
    }
}
