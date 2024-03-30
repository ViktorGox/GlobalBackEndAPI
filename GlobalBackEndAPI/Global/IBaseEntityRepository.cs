namespace GlobalBackEndAPI.Global
{
    /// <summary>
    /// Gathers most basic entity options. Get by id, create, update and delete. Requires model class.
    /// </summary>
    public interface IBaseEntityRepository<T>
    {
        T? Get(Guid id);
        bool Create(T t);
        bool Update(T t);
        bool Delete(T t);
        bool Save();
    }
}
