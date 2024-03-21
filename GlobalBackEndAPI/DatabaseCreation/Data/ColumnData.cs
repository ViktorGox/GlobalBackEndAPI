namespace GlobalBackEndAPI.DatabaseCreation.Data
{
    /// <summary>
    /// Holds the data for a single column for an entity for database table. Does not perform any checks. <br></br>
    /// Use <see cref="ColumnDataFactory"/> to create a proper instance.
    /// </summary>
    public readonly struct ColumnData(string name, Type type, object? defaultValue, bool isNullable, bool isUnique, bool isPrimaryKey, bool isForeignKey)
    {
        public string Name { get; } = name;
        public Type Type { get; } = type;
        public object? DefaultValue { get; } = defaultValue;
        public bool IsNullable { get; } = isNullable;
        public bool IsUnique { get; } = isUnique;
        public bool IsPrimaryKey { get; } = isPrimaryKey;
        public bool IsForeignKey { get; } = isForeignKey;
    }
}
