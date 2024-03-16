namespace GlobalBackEndAPI.DatabaseCreation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ForeignKeyAttribute(string foreignTable, string foreignTableKey, string customSetting = "") : Attribute
    {
        public string ForeignTable { get; } = foreignTable;
        public string ForeignTableKey { get; } = foreignTableKey;
        public string CustomSetting { get; } = customSetting;
    }
}
