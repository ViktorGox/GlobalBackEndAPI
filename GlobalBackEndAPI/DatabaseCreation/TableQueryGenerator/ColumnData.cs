﻿using CustomConsole;
using System.Text;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    public class ColumnData
    {
        public string? Name { get; private set; }
        public Type? Type { get; private set; }
        public object? DefaultValue { get; private set; }
        public bool IsNullable { get; private set; }
        public bool IsUnique { get; private set; }
        public bool IsPrimaryKey { get; private set; }
        public bool IsForeignKey { get; private set; }

        public void SetName(string name)
        {
            if (IsForeignKey)
            {
                CConsole.WriteWarning("Attempting to set name of a column already assigned foreign key!");
                return;
            }
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Name cannot be empty!");
            Name = name;
        }

        public void SetType(Type type)
        {
            ArgumentNullException.ThrowIfNull(type);
            Type = type;
        }

        public void SetDefault(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            DefaultValue = value;
        }

        public void Nullable()
        {
            IsNullable = true;
        }

        public void Unique()
        {
            IsUnique = true;
        }

        public void PrimaryKey()
        {
            if(IsForeignKey)
            {
                CConsole.WriteWarning("Attempting to set a column as primary key when it was already assigned foreign key!");
                return;
            }
            IsPrimaryKey = true;
        }

        public void ForeignKey(string foreignTableKey)
        {
            if (IsPrimaryKey)
            {
                CConsole.WriteWarning("Attempting to set a column as foreign key when it was already assigned primary key!");
                return;
            }
            Name = foreignTableKey + "Id";
            IsForeignKey = true;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Name: ").Append(Name);
            stringBuilder.Append(" Type: ").Append(Type?.ToString());
            stringBuilder.Append(" Default: ").Append(DefaultValue);
            stringBuilder.Append(" IsNullable: ").Append(IsNullable);
            stringBuilder.Append(" IsUnique: ").Append(IsUnique);
            stringBuilder.Append(" IsPrimary: ").Append(IsPrimaryKey);
            return stringBuilder.ToString();
        }
    }
}