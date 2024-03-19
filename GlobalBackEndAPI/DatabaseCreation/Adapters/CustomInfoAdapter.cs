using GlobalBackEndAPI.DatabaseCreation.Data;
using Microsoft.AspNetCore.HttpLogging;

namespace GlobalBackEndAPI.DatabaseCreation.Adapters
{
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
