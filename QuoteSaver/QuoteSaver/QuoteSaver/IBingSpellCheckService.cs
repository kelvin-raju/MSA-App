using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSaver
{
    public interface IBingSpellCheckService
    {
        Task<SpellCheckResult> SpellChecker(string text);
    }
}
