using System.Text;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class EntityData
    {
        private List<ColumnData> _columns;
        private List<string> _foreignKeys;
        internal EntityData()
        {
            _columns = [];
            _foreignKeys = [];
        }

        public void AddColumn(ColumnData column)
        {
            _columns.Add(column);
        }

        public void AddForeignKey(string name)
        {
            _foreignKeys.Add(name);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Columns:\n{\n");
            foreach (ColumnData item in _columns)
            {
                stringBuilder.Append(item.ToString()).Append("\n");
            }
            stringBuilder.Append('}');

            return stringBuilder.ToString();
        }
    }
}
