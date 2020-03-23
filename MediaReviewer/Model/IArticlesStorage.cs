using System.Collections.Generic;

namespace MediaReviewer.Model
{
    public interface IArticlesStorage
    {
        List<T> LoadRecords<T>(string table);
    }
}