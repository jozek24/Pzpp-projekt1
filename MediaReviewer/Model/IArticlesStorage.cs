using System.Collections.Generic;

namespace MediaReviewer.Model
{
    public interface IArticlesStorage
    {
        /// <summary>
        /// This method give you a List of passed objects from database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        List<T> LoadRecords<T>(string table);
    }
}