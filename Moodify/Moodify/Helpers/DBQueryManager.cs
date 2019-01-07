using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace Moodify.Helpers
{
    class DBQueryManager
    {
        public static DBQueryManager Instance { get; } = new DBQueryManager(); // Singleton
        public IDictionary<string, string> QueryDictionary { get; private set; }

        private DBQueryManager()
        {
            QueryDictionary = new Dictionary<string, string>();
            AddSQLStatementsFromFiles();
        }

        /// <summary>
        /// Adds the SQL statements from the resource files to the dictionary.
        /// </summary>
        private void AddSQLStatementsFromFiles()
        {
            ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                string fileName = entry.Key.ToString();
                if (fileName.StartsWith("Sql"))
                {
                    QueryDictionary[fileName] = entry.Value.ToString();
                }
            }
        }
    }
}
