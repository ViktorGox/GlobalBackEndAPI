using CustomConsole;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Text;

namespace GlobalBackEndAPI.Encryption.Binder
{
    public class BodyModelBinder<T> : IModelBinder where T : class
    {
        private readonly JsonSerializer _jsonSerializer;

        public BodyModelBinder(JsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            using (var reader = new StreamReader(bindingContext.HttpContext.Request.Body, Encoding.UTF8))
            {
                var requestBody = await reader.ReadToEndAsync();

                var decryptedBody = new BasicEncryption("AAECAwQFBgcICQoL23222323").Decrypt(requestBody);

                var deserializedData = DeserializeJson<T>(decryptedBody);

                bindingContext.Result = ModelBindingResult.Success(deserializedData);
            }
        }

        private T DeserializeJson<T>(string json)
        {
            using (var stringReader = new StringReader(json))
            {
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    return _jsonSerializer.Deserialize<T>(jsonReader);
                }
            }
        }
    }
}
