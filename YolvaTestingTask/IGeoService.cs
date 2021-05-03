using System;
using System.Collections.Generic;
using System.Text;

namespace YolvaTestingTask
{
    public interface IGeoService<T>
    {
        public IList<T> GetPlaces(string address);
    }
}
