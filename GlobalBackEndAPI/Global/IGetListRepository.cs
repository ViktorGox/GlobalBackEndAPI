namespace GlobalBackEndAPI.Global
{
    /// <summary>
    /// Implements Get a collection of elements. Requires model class.
    /// </summary>
    public interface IGetListRepository<T>
    {
        ICollection<T> GetCollection();
    }
}
