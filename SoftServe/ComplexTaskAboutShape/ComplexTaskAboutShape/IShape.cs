namespace ComplexTaskAboutShape
{
    interface IShape
    {
        double GetPerimetr();
        double GetArea();
        bool IsValid { get; }

    }
}
