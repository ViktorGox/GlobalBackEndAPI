namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class TableQueryGenerator
    {
        private readonly ICollection<EntityData> _entities;
        public TableQueryGenerator(ICollection<EntityData> entityData)
        {
            _entities = entityData;
        }
    }
}
