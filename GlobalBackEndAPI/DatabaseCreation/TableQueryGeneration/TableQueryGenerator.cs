using GlobalBackEndAPI.DatabaseCreation.Adapters;
using GlobalBackEndAPI.DatabaseCreation.Data;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class TableQueryGenerator
    {
        private readonly ICollection<EntityData> _entities;
        private readonly ITypeAdapter _typeAdapter;
        private readonly ICustomInfoAdapter _customInfoAdapter;
        private readonly List<string> _tables;
        public TableQueryGenerator(ICollection<EntityData> entityData, ITypeAdapter typeAdapter, ICustomInfoAdapter customInfoAdapter)
        {
            _entities = entityData;
            _typeAdapter = typeAdapter;
            _customInfoAdapter = customInfoAdapter;
            _tables = new();
        }

        public List<string> GenerateMainTables()
        {
            foreach (EntityData entity in _entities)
            {
                string query = GenerateHeader(entity);
                IReadOnlyList<ColumnData> columnDataList = entity.GetColumnData();

                for (int i = 0; i < columnDataList.Count; i++)
                {
                    ColumnData columnData = columnDataList[i];
                    query += AddColumn(columnData);
                    query += _customInfoAdapter.Adapt(columnData);
                    if (i < columnDataList.Count - 1)
                    {
                        query += ", ";
                    }
                }
                query += ")";
                _tables.Add(query);
            }
            return _tables;
        }

        private string GenerateHeader(EntityData entityData)
        {
            return "CREATE TABLE " + entityData.Name + " (";
        }

        private string AddColumn(ColumnData columnData)
        {
            return columnData.Name + " " + _typeAdapter.TypeToString(columnData.Type);
        }
    }
}
