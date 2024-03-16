using System.Text;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
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
