using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IJSONDataAccess
    {
        string SerializeXmlToJSON(string xml);
        string DeserializeJSON(string json);
    }
}
