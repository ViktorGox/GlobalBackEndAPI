using System.Reflection;

namespace GlobalBackEndAPI
{
    public class SetUpManager
    {
        private static ICollection<ISetUp> _systems;

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
