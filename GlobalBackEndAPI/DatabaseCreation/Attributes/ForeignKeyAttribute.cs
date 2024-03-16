namespace GlobalBackEndAPI.DatabaseCreation.Attributes
{
    /// <summary>
    /// Specifies that a property or a field as a foreign key. Takes in the other tables name and the column name
    /// from the other table, to be referenced in this one. Also accepts custom settings which can be assigned on delete rules and other.
    /// Used by model classes. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ForeignKeyAttribute(string foreignTable, string foreignTableKey, string customSetting = "") : Attribute
    {
        public string ForeignTable { get; } = foreignTable;
        public string ForeignTableKey { get; } = foreignTableKey;
        public string CustomSetting { get; } = customSetting;
    }
}
