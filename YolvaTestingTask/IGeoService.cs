using System;
using System.Collections.Generic;
using System.Text;

namespace YolvaTestingTask
{
    public interface IGeoService
    {
        public IList<Place> GetPlaces(string address);
    }
}
