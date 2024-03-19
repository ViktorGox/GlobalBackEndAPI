namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class TableQueryGenerator
    {
        private readonly ICollection<EntityData> _entities;
        private readonly List<string> _tables;
        public TableQueryGenerator(ICollection<EntityData> entityData)
        {
            _entities = entityData;
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
            }
            return _tables;
        }

        private string GenerateHeader(EntityData entityData)
        {
            return "CREATE TABLE " + entityData.Name + " ( ";
        }

        private string AddColumn(ColumnData columnData)
        {
            return columnData.Name + " " + columnData.Type;
        }
    }
}
