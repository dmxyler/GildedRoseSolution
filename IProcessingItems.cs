using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public interface IProcessingItemsFactory  
    {
        IProcessingItemsStrategy Create(string name); // Paduodamas unikalus 
    }

    public interface IProcessingItemsStrategy
    {
        void UpdateQuality(Item item);
    }
}
