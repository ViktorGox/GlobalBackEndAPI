﻿
namespace GlobalBackEndAPI.DatabaseCreation.Adapters
{
    /// <summary>
    /// Used to convert <see cref="Type"/> into a string to be used for table query generation. Uses singleton pattern, call <see cref="Instance"/>
    /// to use the <see cref="TypeToString(Type)"/>.
    /// </summary>
    public class TypeAdapter : ITypeAdapter
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static TypeAdapter _instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static TypeAdapter Instance
        {
            get
            {
                _instance ??= new TypeAdapter();
                return _instance;
            }
        }

        private TypeAdapter() { }

        /// <summary>
        /// Converts a type into a string version accepted by Microsoft SQL Server. Only supports: <see cref="string"/>, <see cref="int"/>, <see cref=" bool"/>and <see cref="DateTime"/> currently. Can be easily expanded if needed. Throws <see cref="ArgumentOutOfRangeException"/> if type is not supported.
        /// </summary>
        public string TypeToString(Type type) => type switch
        {
            { } when type == typeof(string) => "NVARCHAR(255)",
            { } when type == typeof(int) => "INT",
            { } when type == typeof(bool) => "BOOLEAN",
            { } when type == typeof(DateTime) => "DATE",
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected type: {type}")
        };
    }
}
