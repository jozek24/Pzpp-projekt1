using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLibrary
{
    interface IHTMLDataAccess
    {
        string GetHTML(string url);
        List<string> GetListOfXMLURL(string html);
        MatchCollection GetMatchCollection(string html);
        List<string> AddNewURLForXML(MatchCollection match);
    }
}
