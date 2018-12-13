using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Data;

namespace Moodify.Model
{
    // Singleton MySQL DB Handler.
    class DBHandler
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="DBHandler"/> class from being created.
        /// </summary>
        private DBHandler()
        {
            // TODO: Place in AppConfig?
            ConnectionString = "server=localhost; uid=root; pwd=123456; database=moodify_schema";
            ConnectionHandler = new MySqlConnection(ConnectionString);
        }

        // TODO: Check Singleton.
        public static DBHandler Instance { get; } = new DBHandler(); // Singleton

        private string ConnectionString { get; set; }
        private MySqlConnection ConnectionHandler { get; set; }

        /// <summary>
        /// Executes the aggregation query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The result of the query. -1 is returned in case of a failed query.</returns>
        public int ExecuteAggregationQuery(string query)
        {
            MySqlCommand command = GetCommand(query);
            command.CommandType = CommandType.Text;
            if (this.OpenConnection())
            {
                object result = null;
                try
                {
                    result = command.ExecuteScalar();
                }
                catch (MySqlException)
                {
                    return -1;
                }
                this.CloseConnection();
                result = (result == DBNull.Value) ? null : result; // null or result value.
                int count = Convert.ToInt32(result); // if null, will become 0.
                return count;
            }
            // failed query.
            return -1;
        }
        /// <summary>
        /// Executes a query with no result expected (i.e: Insert, Update or Delete).
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>true if succeeded, false o.w.</returns>
        public bool ExecuteNoResult(string query)
        {
            MySqlCommand command = GetCommand(query);
            command.CommandType = CommandType.Text;
            if (this.OpenConnection())
            {
                int status;
                try
                {
                    status = command.ExecuteNonQuery();
                }
                catch (MySqlException)
                {
                    // failed query.
                    return false;
                }
                this.CloseConnection();
                if (status < 1)
                {
                    // no rows were affected, error.
                    return false;
                }
            }
            // successful query
            return true;
        }

        /// <summary>
        /// Executes the query and returns the results in a JArray.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A JArray containing the results.</returns>
        public JArray ExecuteWithResults(string query)
        {
            MySqlCommand command = GetCommand(query);
            command.CommandType = CommandType.Text;
            if (this.OpenConnection())
            {
                try
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    JArray results = new JArray();
                    while (reader.Read())
                    {
                        JObject row = new JObject();
                        for (int i = 0; i < reader.FieldCount; ++i)
                        {
                            row[reader.GetName(i).ToString()] = reader[i].ToString();
                        }
                        results.Add(row);
                    }
                    reader.Close();
                    this.CloseConnection();
                    return results;
                }
                catch (MySqlException)
                {
                    return null; // query failed.
                }
            }
            // failed opening a connection.
            return null;
        }

        #region PrivateFunctions

        // generates a MySQLCommand with the given query and the existing connection.
        private MySqlCommand GetCommand(string query)
        {
            MySqlCommand command = new MySqlCommand()
            {
                Connection = ConnectionHandler,
                CommandText = query,
            };
            return command;
        }

        // opens a connection with the db server. 
        // returns true if succeeded, false o.w.
        private bool OpenConnection()
        {
            try
            {
                ConnectionHandler.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password.");
                        break;
                }
                return false;
            }
        }

        // closes the connection to the db.
        private bool CloseConnection()
        {
            try
            {
                ConnectionHandler.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
    #endregion
}
