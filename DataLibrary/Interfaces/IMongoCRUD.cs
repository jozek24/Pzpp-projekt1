using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Interfaces
{
    interface IMongoCRUD
    {

        void InsertRecord<T>(string table, List<T> record);
        List<T> LoadRecords<T>(string table);

    }
}
