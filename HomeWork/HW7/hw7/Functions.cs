    using System.Collections.Generic;

    namespace hw7
    {
        public class Functions
        {
            public static int LargestPerimeter(List<Shape> shapes)
            {
                int largestShapeIndex = -1;
                double value = double.MinValue;
                
                for(int i = 0; i < shapes.Count; i++)
                {
                    if(shapes[i].Perimeter() > value)
                    {
                        largestShapeIndex = i;
                        value = shapes[i].Perimeter();
                    }
                }

                return largestShapeIndex + 1;
            }
        }
    }
