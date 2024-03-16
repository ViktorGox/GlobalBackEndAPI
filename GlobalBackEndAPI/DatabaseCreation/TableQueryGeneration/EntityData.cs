using System.Text;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    /// <summary>
    /// Holds information for entities (tables). Contains <see cref="ColumnData"/> and <see cref="ForeignKeyData"/>.
    /// Use <see cref="Attributes.ForeignKeyAttribute"/>, <see cref="Attributes.NullableAttribute"/>, 
    /// <see cref="Attributes.PrimaryKeyAttribute"/> or <see cref="Attributes.UniqueAttribute"/> to specify to the <see cref="DataFetcher"/>
    /// whether a field should be any of those specific things. Fields are not nullable, not unique, not primary key, not foreign key by default.
    /// </summary>
    public class EntityData
    {
        private readonly List<ColumnData> _columns;
        private readonly List<ForeignKeyData> _foreignKeys;
        internal EntityData()
        {
            _columns = [];
            _foreignKeys = [];
        }

        public void AddColumn(ColumnData column)
        {
            _columns.Add(column);
        }

        public void AddForeignKey(ForeignKeyData data)
        {
            _foreignKeys.Add(data);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append("Columns:\n{\n");
            foreach (ColumnData item in _columns)
            {
                stringBuilder.Append(item.ToString()).Append('\n');
            }
            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }

        public IReadOnlyList<ColumnData> GetColumnData()
        {
            return _columns;
        }

        public IReadOnlyList<ForeignKeyData> GetForeignKeys()
        {
            return _foreignKeys;
        }
    }
}
