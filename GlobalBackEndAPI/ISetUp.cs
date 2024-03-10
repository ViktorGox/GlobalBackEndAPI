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
        /// Called before the app has been built.
        /// </summary>
        void Configure(WebApplicationBuilder builder);
        /// <summary>
        /// Called after the app has been built.
        /// </summary>
        void InitializeDB();
    }
}
