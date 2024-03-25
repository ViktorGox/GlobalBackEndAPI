namespace GlobalBackEndAPI.DatabaseCreation.Seeding
{
    public interface ISeed
    {
        // For future seeding implementation.
        ICollection<object> Seed(); 
    }
}
