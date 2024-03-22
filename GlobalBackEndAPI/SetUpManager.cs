using System.Reflection;

namespace GlobalBackEndAPI
{
    /// <summary>
    /// Used to start up the main classes for the separate systems. A system main class must inherit from <see cref="ISetUp"/>. <br></br>
    /// Calls <see cref="Configure(WebApplicationBuilder)"/> before the <see cref="WebApplicationBuilder"/> has created the <see cref="WebApplication"/> in the <see cref="Program"/>. Calls <see cref="InitializeDatabases"/> right after the <see cref="WebApplicationBuilder"/> has created the <see cref="WebApplication"/>. System classes must be in a namespace. Database model classes must be placed in a .Model namespace.
    /// </summary>
    public class SetUpManager
    {
        private readonly static ICollection<ISetUp> _systems;

        static SetUpManager()
        {
            _systems = [];
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(ISetUp).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            if(types is null || types.Count() == 0)
            {
                throw new Exception("Failed to find any classes extending ISetUp. No systems to handle. The program will do nothing.");
            }

            foreach (Type type in types)
            {
                if (Activator.CreateInstance(type) is ISetUp startUpInstance)
                {
                    _systems.Add(startUpInstance);
                }
            }
        }

        public static void Configure(WebApplicationBuilder builder)
        {
            foreach (ISetUp system in _systems)
            {
                system.Configure(builder);
            }
        }

        /// <summary>
        /// Calls the <see cref="ISetUp.InitializeDB(string)"/> for the main system classes. The classes must be present in a namespace. The database model classes must be inside the same namespace followed by .Mode. The main class must be present in the parent directory or one directory inner. <code>System.SetUp</code> will be converted to <code>System.Model</code> <br></br>
        /// Throws <see cref="InvalidOperationException"/> if the main system class does not have a namespace. Namespace is mandatory for the method to be able to find the model classes and other.
        /// </summary>
        public static void InitializeDatabases()
        {
            foreach (ISetUp system in _systems)
            {
                string? namespaceName = system.GetType().Namespace;

                if (namespaceName is null) throw new InvalidOperationException("System class does not have a namespace. Program cannot function properly. Type: " + system.GetType());

                if(namespaceName.EndsWith("SetUp"))
                {
                    int lastDotIndex = namespaceName.LastIndexOf('.');
                    if (lastDotIndex != -1)
                    {
                        namespaceName = namespaceName[..lastDotIndex];
                    }
                }
                namespaceName += ".Models";
                system.InitializeDB(namespaceName);
            }
        }
    }
}
