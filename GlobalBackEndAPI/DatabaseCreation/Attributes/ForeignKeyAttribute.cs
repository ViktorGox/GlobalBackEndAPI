namespace GlobalBackEndAPI.DatabaseCreation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ForeignKeyAttribute : Attribute
    {
        public string ForeignKey { get; }
        public string ForeignTableKey { get; }
        public string CustomSetting { get; }

        public ForeignKeyAttribute(string foreignTable, string foreignTableKey, string customSetting = "")
        {
            ForeignKey = foreignTable;
            ForeignTableKey = foreignTableKey;
            CustomSetting = customSetting;
        }
    }
}
