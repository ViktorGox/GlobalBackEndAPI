using CustomConsole;
using GlobalBackEndAPI.DatabaseCreation.Attributes;
using GlobalBackEndAPI.DatabaseCreation.Data;
using System.Reflection;

namespace GlobalBackEndAPI.DatabaseCreation.TableQueryGenerator
{
    /// <summary>
    /// Used to gather data from model classes, to be used for creating a table query.
    /// </summary>
    public static class DataFetcher
    {
        /// <summary>
        /// Looks through a specified Model directory, and fetches the data about fields and properties. Targeted namespace must contain Models in 
        /// the name. All classes within the Model namespace must be instantiatable. Returns a collection of <see cref="EntityData"/>, an element for 
        /// each class within the Model namespace.
        /// </summary>
        public static ICollection<EntityData> FetchData(string targetNamespace)
        {
            if (string.IsNullOrWhiteSpace(targetNamespace) || !targetNamespace.ToLower().Contains("models"))
            {
                throw new ArgumentException("Possibly wrong target namespace. Namespaces which contain entity templates must include" +
                    " \"Models\". Provided namespace: " + targetNamespace);
            }

            List<EntityData> data = [];

            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> modelTypes = assembly.GetTypes().Where(t => t.Namespace == targetNamespace && !t.IsInterface && !t.IsAbstract);

            foreach (Type type in modelTypes)
            {
                EntityData entityData = new();
                entityData.Name = type.Name;
                FetchPropertyInfo(type, entityData);
                FetchFieldInfo(type, entityData);
                data.Add(entityData);
            }

            return data;
        }

        private static void FetchPropertyInfo(Type type, EntityData entityData)
        {
            ColumnDataFactory columnDataFactory = new();
            foreach (PropertyInfo property in type.GetProperties())
            {
                HandleForeignKey(property, columnDataFactory, entityData);
                HandleDefault(property, columnDataFactory);
                if (Attribute.IsDefined(property, typeof(NullableAttribute))) columnDataFactory.Nullable();
                if (Attribute.IsDefined(property, typeof(PrimaryKeyAttribute))) columnDataFactory.PrimaryKey();
                if (Attribute.IsDefined(property, typeof(UniqueAttribute))) columnDataFactory.Unique();
                entityData.AddColumn(columnDataFactory.Finalize());
            }
        }

        private static void HandleForeignKey(PropertyInfo property, ColumnDataFactory columnDataFactory, EntityData entityData)
        {
            ForeignKeyAttribute? attribute = (ForeignKeyAttribute?)property.GetCustomAttribute(typeof(ForeignKeyAttribute));

            if (attribute is not null)
            {
                columnDataFactory.ForeignKey(attribute.ForeignTableKey);
                if (columnDataFactory.Name is not null)
                {
                    entityData.AddForeignKey(new ForeignKeyData(columnDataFactory.Name, attribute.ForeignTable, attribute.ForeignTableKey, attribute.CustomSetting));
                }
                columnDataFactory.SetType(typeof(int));
            }
            else
            {
                columnDataFactory.SetName(property.Name);
                columnDataFactory.SetType(property.PropertyType);
            }
        }

        private static void HandleDefault(PropertyInfo property, ColumnDataFactory columnDataFactory)
        {
            DefaultValueAttribute? attribute = (DefaultValueAttribute?)property.GetCustomAttribute(typeof(DefaultValueAttribute));

            if (attribute is not null)
            {
                if (columnDataFactory.DefaultValue is string s && s.ToLower().Equals("now"))
                {
                    columnDataFactory.SetDefault("CURRENT_TIMESTAMP");
                }
                columnDataFactory.SetDefault(attribute.DefaultValue);
            }
        }

        private static void FetchFieldInfo(Type type, EntityData entityData)
        {
            //// Get all public fields of the class
            //FieldInfo[] fields = type.GetFields();

            //// Print information about each field
            //foreach (FieldInfo field in fields)
            //{
            //    Console.WriteLine($"{type} ->  Field Name: {field.Name}");
            //    Console.WriteLine($"{type} ->  Field Type: {field.FieldType}");
            //    //Console.WriteLine($"Field Value: {field.GetValue(-)}");
            //}
        }
    }
}
