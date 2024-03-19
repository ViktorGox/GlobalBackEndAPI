using GlobalBackEndAPI.DatabaseCreation.Data;

namespace GlobalBackEndAPI.DatabaseCreation.Adapters
{
    /// <summary>
    /// Used to convert data from <see cref="ColumnData"/> into a string to be used for whatever reason.
    /// </summary>
    public interface ICustomInfoAdapter
    {
        string Adapt(ColumnData columnData);
    }
}
