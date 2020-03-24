﻿using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IJSONDataAccess
    {
        List<string> SerializeXMLToJSONlist(List<string> xml);
        List<RootObject> DeserializeJSONToList(List<string> json);
    }
}
