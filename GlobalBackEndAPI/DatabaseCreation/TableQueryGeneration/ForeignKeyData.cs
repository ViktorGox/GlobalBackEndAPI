namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    /// <summary>
    /// Data class which holds information about foreign keys. Intended to be used in combination with <see cref="Attributes.ForeignKeyAttribute"/>
    /// Takes in the name of the current's table id column. The other tables name. The column name which contains the key in the other table. And
    /// custom rules field, which can be anything.
    /// </summary>
    public class ForeignKeyData(string domesticKey, string foreignTable, string foreignKey, string customRule = "")
    {
        public string DomesticKey { get; set; } = domesticKey;
        public string ForeignTable { get; set; } = foreignTable;
        public string ForeignKey { get; set; } = foreignKey;
        public string CustomRule { get; set; } = customRule;
    }
}
