using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU.WordCatcher.Application.Interfaces
{
    public interface IWordFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordStream);
    }
}
