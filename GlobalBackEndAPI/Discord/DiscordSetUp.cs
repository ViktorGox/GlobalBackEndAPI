using CustomConsole;
using GlobalBackEndAPI.SetUp;

namespace GlobalBackEndAPI.Discord
{
    public class DiscordSetUp : ISetUp
    {
        public void Configure(WebApplicationBuilder builder)
        {
            CConsole.WriteSuccess("was created!");
        }

        public void InitializeDB(string targetNamespace)
        {
        }
    }
}
