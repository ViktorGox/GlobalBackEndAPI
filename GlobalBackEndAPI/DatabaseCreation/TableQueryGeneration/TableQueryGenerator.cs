using GlobalBackEndAPI.DatabaseCreation.Adapters;
using GlobalBackEndAPI.DatabaseCreation.Data;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class TableQueryGenerator
    {
        private readonly ICollection<EntityData> _entities;
        private readonly ITypeAdapter _typeAdapter;
        private readonly ICustomInfoAdapter _customInfoAdapter;
        private readonly List<string> _queries;
        public TableQueryGenerator(ICollection<EntityData> entityData, ITypeAdapter typeAdapter, ICustomInfoAdapter customInfoAdapter)
        {
            _entities = entityData;
            _typeAdapter = typeAdapter;
            _customInfoAdapter = customInfoAdapter;
            _queries = new();
        }

        public List<string> GenerateMainTables()
        {
            GenerateTables();
            AlterForeignKeys();
            return _queries;
        }

        private void GenerateTables()
        {
            foreach (EntityData entity in _entities)
            {
                IReadOnlyList<ColumnData> columnDataList = entity.GetColumnData();

                string query = "CREATE TABLE " + entity.Name + " (";

                for (int i = 0; i < columnDataList.Count; i++)
                {
                    ColumnData columnData = columnDataList[i];
                    query += columnData.Name + " " + _typeAdapter.TypeToString(columnData.Type);
                    query += _customInfoAdapter.Adapt(columnData);
                    if (i < columnDataList.Count - 1)
                    {
                        query += ", ";
                    }
                }
                query += ")";
                _queries.Add(query);
            }
        }

        private void AlterForeignKeys()
        {
            foreach (EntityData entity in _entities)
            {
                IReadOnlyList<ForeignKeyData> foreignKeyData = entity.GetForeignKeys();

                for (int i = 0; i < foreignKeyData.Count; i++)
                {
                    ForeignKeyData fd = foreignKeyData[i];
                    string query = "ALTER TABLE " + entity.Name + " ADD FOREIGN KEY (" +
                        fd.DomesticKey + ") REFERENCES " + fd.ForeignTable + "(" + 
                        fd.ForeignKey + ") " + fd.CustomRule + ";";

                    _queries.Add(query);
                }
            }
        }
    }
}
