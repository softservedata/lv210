namespace HierarchyOfGeometricShapes
{
    /// <summary>
    /// <para>Interface has only to methods - Perimeter() and Area().</para>
    /// <para>These methods will be implemented in classes Circle and Polygon.</para>
    /// </summary>

    interface IShape
    {
        double Perimeter();
        double Area();
    }
}