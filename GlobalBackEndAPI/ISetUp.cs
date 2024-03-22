namespace GlobalBackEndAPI
{
    /// <summary>
    /// Inherited by classes which set up individual system and related database.
    /// <para>
    /// Called from <see cref="SetUpManager"/>.
    /// </para>
    /// </summary>
    public interface ISetUp
    {
        /// <summary>
        /// Called before the app has been built. Should set up scopes and DataContext. Provide connection string to the DataContext.
        /// </summary>
        void Configure(WebApplicationBuilder builder);
        /// <summary>
        /// Called after the app has been built.
        /// </summary>
        void InitializeDB(string targetNamespace);
    }
}
