using System.Collections.Generic;

namespace Moodify.DB
{
    internal interface IDBQueryManager
    {
        IDictionary<string, string> QueryDictionary { get; }
    }
}