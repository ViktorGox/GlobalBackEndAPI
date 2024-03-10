namespace GlobalBackEndAPI.DatabaseCreation
{
    // Currently uses raw query, but will be better if it uses some query generator.
    // https://github.com/ViktorGox/GlobalBackEndAPI/issues/1
    /// <summary>
    /// Inherited by classes which will have a table in one of the databases.
    /// </summary>
    public interface ITableGeneration
    {
        /// <summary>
        /// Raw query which will be executed and a table will be created from it.
        /// </summary>
        string TableGenerationQuery();
    }
}
