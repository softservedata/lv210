namespace DevelopersTask
{
    public interface IDeveloper
    {
        string Tool { get; }

        void Create();

        void Destroy();
    }
}