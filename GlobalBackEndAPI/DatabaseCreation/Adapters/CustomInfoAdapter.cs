using GlobalBackEndAPI.DatabaseCreation.Data;
using Microsoft.AspNetCore.HttpLogging;

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
            if (columnData.IsPrimaryKey) return " IDENTITY(1,1) PRIMARY KEY";
            string final = "";

            if (columnData.IsNullable)
            {
                final += " NULL";
            }
            else
            {
                final += " NOT NULL"; // default
            }

            if (columnData.IsUnique)
            {
                final += " UNIQUE";
            }

            if (columnData.DefaultValue is not null)
            {
                final += " DEFAULT ";
                if (columnData.Type == typeof(string) || columnData.Type == typeof(DateTime))
                {
                    final += '\'' + columnData.DefaultValue.ToString() + '\'';
                }
                else
                {
                    final += columnData.DefaultValue.ToString();
                }
            }

            return final;
        }
    }
}
