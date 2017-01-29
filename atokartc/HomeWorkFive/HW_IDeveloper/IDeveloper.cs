namespace HwFive
{
    public interface IDeveloper
    {
        string Tool { get; set; }

        void Create();
        void Destroy();
    }
}