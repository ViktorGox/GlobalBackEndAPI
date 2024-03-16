namespace GlobalBackEndAPI.DatabaseCreation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ForeignKeyAttribute : Attribute
    {
        public string ForeignTable { get; }
        public string ForeignTableKey { get; }
        public string CustomSetting { get; }

        public ForeignKeyAttribute(string foreignTable, string foreignTableKey, string customSetting = "")
        {
            ForeignTable = foreignTable;
            ForeignTableKey = foreignTableKey;
            CustomSetting = customSetting;
        }
    }
}
