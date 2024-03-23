using CustomConsole;
using GlobalBackEndAPI.DatabaseCreation.Adapters;
using GlobalBackEndAPI.DatabaseCreation.Data;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    /// <summary>
    /// Takes in <see cref="EntityData"/> and converts it into queries which can be used to generate tables. Requires a <see cref="ITypeAdapter"/>
    /// and <see cref="ICustomInfoAdapter"/>.
    /// </summary>
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

        /// <summary>
        /// Generates queries based on the provided <see cref="EntityData"/> to the constructor. Does not include foreign keys. To generate foreign keys 
        /// look into <see cref="TableAlterQueries"/>.
        /// </summary>
        /// <returns></returns>
        public List<string> TableMainQueries()
        {
            List<string> _queries = [];

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

        /// <summary>
        /// Generates queries which alter tables. To generate the query for a table look at <see cref="TableMainQueries"/>. Currently supports:
        /// Foreign Key alterations.
        /// </summary>
        public List<string> TableAlterQueries()
        {
            List<string> _queries = [];

            foreach (EntityData entity in _entities)
            {
                IReadOnlyList<ForeignKeyData> foreignKeyData = entity.GetForeignKeys();

                for (int i = 0; i < foreignKeyData.Count; i++)
                {
                    ForeignKeyData fd = foreignKeyData[i];
                    string query = GenerateAlterTableFKCheck(AddName(entity.Name), GenerateConstraintName(entity.Name, fd));
                    query += GenerateAlterTableFK(fd, entity.Name);

                    _queries.Add(query);
                }
            }

            return _queries;
        }

        private string GenerateAlterTableFKCheck(string tableName, string constraintName)
        {
            return "IF NOT EXISTS ( SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'FOREIGN KEY'" +
                "AND TABLE_NAME = '" + tableName + "' AND CONSTRAINT_NAME = '" + constraintName + "')";
        }

        private string GenerateAlterTableFK(ForeignKeyData fd, string entityName)
        {
            return "BEGIN ALTER TABLE " + AddName(entityName)
                  + " ADD CONSTRAINT " + GenerateConstraintName(entityName, fd)
                  + " FOREIGN KEY (" + fd.DomesticKey + ") "
                  + "REFERENCES " + AddName(fd.ForeignTable) + "(" + fd.ForeignKey + ") " + fd.CustomRule + "; END";
        }

        private string GenerateConstraintName(string entityName, ForeignKeyData fd)
        {
            return "FK_" + entityName + "_" + fd.DomesticKey + "_" + fd.ForeignTable + "_" + fd.ForeignKey;
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
