using System.Reflection;

namespace GlobalBackEndAPI
{
    /// <summary>
    /// Finds system base classes. They must inherit <see cref="ISetUp"/>. 
    /// </summary>
    public class SetUpManager
    {
        private static ICollection<ISetUp> _systems;

        /// <summary>
        /// Finds the classes which inherit <see cref="ISetUp"/> and saves them in a list, so they can be called later for the
        /// <see cref="ISetUp.Configure(WebApplicationBuilder)"/> and <see cref="ISetUp.InitializeDB"/>
        /// </summary>
        static SetUpManager()
        {
            _systems = new List<ISetUp>();
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

        public static void InitializeDatabases()
        {
            foreach (ISetUp system in _systems)
            {
                system.InitializeDB();
            }
        }
    }
}
