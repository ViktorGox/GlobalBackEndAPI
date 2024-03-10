namespace GlobalBackEndAPI
{
    public interface ISetUp
    {
        void Configure(WebApplicationBuilder builder);
        void InitializeDB();
    }
}
