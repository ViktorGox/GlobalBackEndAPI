using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace GlobalBackEndAPI.Encryption.Binder
{
    public class BodyModelBinderProvider<T> : IModelBinderProvider where T : class
    {
        private readonly JsonSerializer _jsonSerializer;

        public BodyModelBinderProvider(JsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(T))
            {
                return new BodyModelBinder<T>(_jsonSerializer);
            }

            return null;
        }
    }
}
