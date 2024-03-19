
namespace GlobalBackEndAPI.DatabaseCreation.Adapters
{
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
