    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace hw7
    {
        public class Functions
        {
            public static int LargestPerimeter(List<Shape> shapes)
            {
                int LargestShapeIndex = -1;
                double value = double.MinValue;
                
                for(int i = 0; i < shapes.Count; i++)
                {
                    if(shapes[i].Perimeter() > value)
                    {
                        LargestShapeIndex = i;
                        value = shapes[i].Perimeter();
                    }
                }
                return LargestShapeIndex + 1;
            }
        }
    }
