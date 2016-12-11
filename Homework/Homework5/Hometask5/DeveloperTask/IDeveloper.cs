namespace DeveloperTask
{
    public interface IDeveloper
    {
        string Tool { get; set; }
        string Create();
        string Destroy();
    }
}
