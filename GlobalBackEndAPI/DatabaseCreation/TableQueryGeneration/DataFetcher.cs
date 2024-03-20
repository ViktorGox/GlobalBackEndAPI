﻿using CustomConsole;
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
            foreach (PropertyInfo property in type.GetProperties())
            {
                ColumnData columnData = new();

              
                HandleForeignKey(property, columnData, entityData);
                HandleDefault(property, columnData);
                if (Attribute.IsDefined(property, typeof(NullableAttribute))) columnData.Nullable();
                if (Attribute.IsDefined(property, typeof(PrimaryKeyAttribute))) columnData.PrimaryKey();
                if (Attribute.IsDefined(property, typeof(UniqueAttribute))) columnData.Unique();
                entityData.AddColumn(columnData);
            }
        }

        private static void HandleForeignKey(PropertyInfo property, ColumnData columnData, EntityData entityData)
        {
            ForeignKeyAttribute? attribute = (ForeignKeyAttribute?)property.GetCustomAttribute(typeof(ForeignKeyAttribute));

            if (attribute is not null)
            {
                columnData.ForeignKey(attribute.ForeignTableKey);
                if (columnData.Name is not null)
                {
                    entityData.AddForeignKey(new ForeignKeyData(columnData.Name, attribute.ForeignTable, attribute.ForeignTableKey, attribute.CustomSetting));
                }
                columnData.SetType(typeof(int));
            }
            else
            {
                columnData.SetName(property.Name);
                columnData.SetType(property.PropertyType);
            }
        }

        private static void HandleDefault(PropertyInfo property, ColumnData columnData)
        {
            DefaultValueAttribute? attribute = (DefaultValueAttribute?)property.GetCustomAttribute(typeof(DefaultValueAttribute));

            if(attribute is not null) 
            {
                if (columnData.DefaultValue is string s && s.ToLower().Equals("now"))
                {
                    columnData.SetDefault("CURRENT_TIMESTAMP");
                }
                columnData.SetDefault(attribute.DefaultValue);
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
