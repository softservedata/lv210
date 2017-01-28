using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    public interface IExternalData
    {
        IList<IList<string>> GetAllValues(string path);
    }
}
