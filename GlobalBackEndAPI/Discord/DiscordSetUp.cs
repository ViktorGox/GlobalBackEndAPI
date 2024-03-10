using CustomConsole;

namespace GlobalBackEndAPI.Discord
{
    public class DiscordSetUp : ISetUp
    {
        public void Configure(WebApplicationBuilder builder)
        {
            CConsole.WriteSuccess(this, " was created!");
        }

        public void InitializeDB()
        {
        }
    }
}
