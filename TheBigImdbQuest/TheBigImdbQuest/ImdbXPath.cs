using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBigImdbQuest
{
    public static class ImdbXPath
    {
        public static readonly Dictionary<string, string> XPaths = new Dictionary<string, string>()
        {
            ["selectTitles"] = "//tbody//tr//td[@class='titleColumn']//a",
            ["selectLinks"] = "//tbody//tr//td[@class='titleColumn']//a",
            ["selectRate"] = "//tbody//tr//td[@class='posterColumn']//span[@name='ir']",
            ["selectVotes"] = "//tbody//tr//td[@class='posterColumn']//span[@name='nv']",
            ["selectOscars"] = "//li[@data-testid='award_information']//a",
        };
    }
}
