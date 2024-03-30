using GlobalBackEndAPI.DatabaseCreation.Data;
using System.Text;

namespace GlobalBackEndAPI.DatabaseCreation.Adapters
{
    /// <summary>
    /// Used to convert the <see cref="ColumnData"/> extra settings, anything other than name and type, into a string to be used for a query.
    /// Uses singleton pattern, call <see cref="Instance"/> to use the <see cref="Adapt(ColumnData)"/>
    /// </summary>
    public class CustomInfoAdapter : ICustomInfoAdapter
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static CustomInfoAdapter _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static CustomInfoAdapter Instance
        {
            get
            {
                _instance ??= new CustomInfoAdapter();
                return _instance;
            }
        }

        private CustomInfoAdapter() { }

        public string Adapt(ColumnData columnData)
        {
            // If it's a primary key, we do not care about other modifiers, even if they are enabled, they should not be applied.
            if (columnData.IsPrimaryKey) return " PRIMARY KEY DEFAULT NEWID()";

            StringBuilder sb = new StringBuilder();

            sb.Append(HandleNullable(columnData));
            sb.Append(HandleUnique(columnData));
            sb.Append(HandleDefaultValue(columnData));

            return sb.ToString();
        }

        private string HandleNullable(ColumnData columnData)
        {
            if (columnData.IsNullable)
            {
                return " NULL";
            }
            else
            {
                return " NOT NULL"; // default
            }
        }

        private string HandleUnique(ColumnData columnData)
        {
            if (columnData.IsUnique)
            {
                return " UNIQUE";
            }
            return "";
        }

        private string HandleDefaultValue(ColumnData columnData)
        {
            StringBuilder sb = new StringBuilder();
            if (columnData.DefaultValue is not null)
            {
                sb.Append(" DEFAULT ");
                if (columnData.Type == typeof(string))
                {
                    sb.Append('\'').Append(columnData.DefaultValue.ToString()).Append('\'');
                }
                else if (columnData.Type == typeof(DateTime))
                {
                    sb.Append(" CURRENT_TIMESTAMP ");
                }
                else if (columnData.Type == typeof(bool))
                {
                    int value = (bool) columnData.DefaultValue ? 1 : 0;
                    sb.Append(value + " ");
                }
                else
                {
                    sb.Append(columnData.DefaultValue.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
