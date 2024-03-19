namespace GlobalBackEndAPI.DatabaseCreation.Adapters
{
    /// <summary>
    /// Used to convert data from <see cref="Type"/> into a string other than the default nameof(type)
    /// </summary>
    public interface ITypeAdapter
    {
        string TypeToString(Type type);
    }
}
