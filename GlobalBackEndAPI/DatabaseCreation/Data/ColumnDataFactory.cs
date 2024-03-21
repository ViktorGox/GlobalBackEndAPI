namespace GlobalBackEndAPI.DatabaseCreation.Data
{
    /// <summary>
    /// Used to create instance of <see cref="ColumnData"/>. <br></br>
    /// Must provide a <see cref="Name"/> and <see cref="Type"/>. Other settings are optional. Not all are compatible with each other, read comment above methods, to learn more about what are modifiers incompatible. Generate the final <see cref="ColumnData"/> using <see cref="Finalize"/>.
    /// </summary>
    public class ColumnDataFactory
    {
        public string? Name { get; private set; }
        public Type? Type { get; private set; }
        public object? DefaultValue { get; private set; }
        public bool IsNullable { get; private set; }
        public bool IsUnique { get; private set; }
        public bool IsPrimaryKey { get; private set; }
        public bool IsForeignKey { get; private set; }

        /// <summary>
        /// Sets the name of the column. <br></br>
        /// Does not accept null. <br></br>
        /// Throws <see cref="NotSupportedException"/> if already assigned <see cref="IsForeignKey"/>.<br></br>
        /// Does not accept empty, white space only or null value. <br></br>
        /// </summary>
        public void SetName(string name)
        {
            if (IsForeignKey)
            {
                throw new NotSupportedException("Attempting to set name of a column already assigned foreign key.");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NotSupportedException("Attempting to set name with empty or null string!");
            }
            Name = name;
            return;
        }

        /// <summary>
        /// Sets the type. Does not accept null.
        /// </summary>
        public void SetType(Type type)
        {
            ArgumentNullException.ThrowIfNull(type);
            Type = type;
        }

        /// <summary>
        /// Sets a default value. <br></br>
        /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is null.<br></br>
        /// Throws <see cref="NotSupportedException"/> if already assigned <see cref="IsUnique"/>.
        /// </summary>
        public void SetDefault(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (IsUnique)
            {
                throw new NotSupportedException("Attempting to set default when already assigned unique!");
            }
            DefaultValue = value;
        }

        public void Nullable()
        {
            IsNullable = true;
        }

        /// <summary>
        /// Sets unique requirement. <br></br>
        /// Throws <see cref="NotSupportedException"/> if already assigned <see cref="DefaultValue"/>.
        /// </summary>
        public void Unique()
        {
            if (DefaultValue is not null)
            {
                throw new NotSupportedException("Attempting to set unique when already assigned default value!");
            }
            IsUnique = true;
        }

        /// <summary>
        /// Sets as a primary key. <br></br>
        /// Throws <see cref="NotSupportedException"/> if already assigned <see cref="IsForeignKey"/>.
        /// </summary>
        public void PrimaryKey()
        {
            if (IsForeignKey)
            {
                throw new NotSupportedException("Attempting to set a column as primary key when it was already assigned foreign key!");
            }
            IsPrimaryKey = true;
        }

        /// <summary>
        /// Sets as a foreign key. Changes <see cref="Name"/> to <paramref name="foreignTableKey"/>.<br></br>
        /// Throws <see cref="NotSupportedException"/> if already assigned <see cref="IsPrimaryKey"/>.
        /// </summary>
        public void ForeignKey(string foreignTableKey)
        {
            if (IsPrimaryKey)
            {
                throw new NotSupportedException("Attempting to set a column as foreign key when it was already assigned primary key!");
            }
            Name = foreignTableKey;
            IsForeignKey = true;
        }

        /// <summary>
        /// Generates a <see cref="ColumnData"/> entity and resets the factory. Must have a set name and type. <br></br>
        /// Throws <see cref="NotSupportedException"/> if either name or the type is not set.
        /// </summary>
        public ColumnData Finalize()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new NotSupportedException("Cannot finalize with null or white space only name.");
            }
            if (Type is null)
            {
                throw new NotSupportedException("Cannot finalize with null type.");
            }
            ColumnData columnData = new(Name, Type, DefaultValue, IsNullable, IsUnique, IsPrimaryKey, IsForeignKey);
            Reset();
            return columnData;
        }

        private void Reset()
        {
            Name = null;
            Type = null;
            DefaultValue = null;
            IsNullable = false;
            IsUnique = false;
            IsPrimaryKey = false;
            IsForeignKey = false;
        }
    }
}
