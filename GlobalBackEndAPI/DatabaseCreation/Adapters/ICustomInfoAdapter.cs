using GlobalBackEndAPI.DatabaseCreation.Data;

namespace GlobalBackEndAPI.DatabaseCreation.Adapters
{
    public interface ICustomInfoAdapter
    {
        string Adapt(ColumnData columnData);
    }
}
