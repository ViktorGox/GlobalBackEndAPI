using GlobalBackEndAPI.DatabaseCreation.Adapters;
using GlobalBackEndAPI.DatabaseCreation.Data;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class TableQueryGenerator
    {
        private readonly ICollection<EntityData> _entities;
        private readonly ITypeAdapter _typeAdapter;
        private readonly List<string> _tables;
        public TableQueryGenerator(ICollection<EntityData> entityData, ITypeAdapter typeAdapter)
        {
            _entities = entityData;
            _typeAdapter = typeAdapter;
            _tables = new();
        }

        public List<string> GenerateMainTables()
        {
            foreach (EntityData entity in _entities)
            {
                string query = GenerateHeader(entity);
                foreach (ColumnData columnData in entity.GetColumnData())
                {
                    query += AddColumn(columnData);
                }
                _tables.Add(query);
            }
            return _tables;
        }

        private string GenerateHeader(EntityData entityData)
        {
            return "CREATE TABLE " + entityData.Name + " ( ";
        }

        private string AddColumn(ColumnData columnData)
        {
            return columnData.Name + " " + _typeAdapter.TypeToString(columnData.Type) + " ";
        }
    }
}
