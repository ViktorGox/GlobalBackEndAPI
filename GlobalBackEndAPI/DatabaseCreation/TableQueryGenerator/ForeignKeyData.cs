namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class ForeignKeyData(string domesticKey, string foreignTable, string foreignKey, string customRule = "")
    {
        public string DomesticKey { get; set; } = domesticKey;
        public string ForeignTable { get; set; } = foreignTable;
        public string ForeignKey { get; set; } = foreignKey;
        public string CustomRule { get; set; } = customRule;
    }
}
