using GlobalBackEndAPI.DatabaseCreation.Adapters;
using GlobalBackEndAPI.DatabaseCreation.Data;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class TableQueryGenerator
    {
        private readonly ICollection<EntityData> _entities;
        private readonly ITypeAdapter _typeAdapter;
        private readonly ICustomInfoAdapter _customInfoAdapter;
        public TableQueryGenerator(ICollection<EntityData> entityData, ITypeAdapter typeAdapter, ICustomInfoAdapter customInfoAdapter)
        {
            _entities = entityData;
            _typeAdapter = typeAdapter;
            _customInfoAdapter = customInfoAdapter;
        }

        public List<string> TableMainQueries()
        {
            return GenerateTables();
        }

        public List<string> TableAlterQueries()
        {
            return AlterForeignKeys();
        }

        private List<string> GenerateTables()
        {
            List<string> _queries = new();

            foreach (EntityData entity in _entities)
            {
                IReadOnlyList<ColumnData> columnDataList = entity.GetColumnData();

                string query = "CREATE TABLE " + AddName(entity.Name) + " (";

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

            return _queries;
        }

        private List<string> AlterForeignKeys()
        {
            List<string> _queries = new();

            foreach (EntityData entity in _entities)
            {
                IReadOnlyList<ForeignKeyData> foreignKeyData = entity.GetForeignKeys();

                for (int i = 0; i < foreignKeyData.Count; i++)
                {
                    ForeignKeyData fd = foreignKeyData[i];
                    string query = "ALTER TABLE " + AddName(entity.Name) + " ADD FOREIGN KEY (" +
                        fd.DomesticKey + ") REFERENCES " + fd.ForeignTable + "(" +
                        fd.ForeignKey + ") " + fd.CustomRule + ";";

                    _queries.Add(query);
                }
            }

            return _queries;
        }

        /// <summary>
        /// Some names are not accepted, and this method fixes that.
        /// List of edited names (1): User -> Users
        /// </summary>
        private static string AddName(string name)
        {
            if (name.ToLower() == "user")
            {
                return name + "s";
            }
            return name;
        }
    }
}
