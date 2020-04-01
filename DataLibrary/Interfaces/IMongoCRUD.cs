using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Interfaces
{
    public interface IMongoCRUD
    {

        void InsertRecord<T>(string table, List<T> record);
        Task<List<T>> LoadRecords<T>(string table);

    }
}
