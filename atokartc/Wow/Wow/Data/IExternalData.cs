using System.Collections.Generic;

namespace Wow.Data
{
    public interface IExternalData
    {
        IList<IList<string>> GetAllCells(string path);
    }
}
