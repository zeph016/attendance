using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.domain.clsFilterParameter
{
    public class FilterParameter
    {
      public FilterParameter()
      {
          year = 0;
          IsLookup = true;
          IsName = true;
      }
      public long year {get;set;}
      public bool IsActive { get; set; }

      public bool IsLookup { get; set; }
      public bool IsName { get; set; } 
      public string Name { get; set; } = string.Empty;
    }
}
