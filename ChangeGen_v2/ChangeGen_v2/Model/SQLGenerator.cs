using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    internal static class SqlGenerator
    {
        public static void StartGenerator(ServerConnectionCredentials serverCreds, SQLGeneratorParameters sqlGenParams,
            CancellationToken cancelToken)
        {
            var instance = GetSqlInstanceNameFromService(serverCreds.Ip, serverCreds.Username, serverCreds.Password);

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = serverCreds.Ip + "\\" + instance,
                UserID = serverCreds.Username,
                Password = serverCreds.Password,
                IntegratedSecurity = true
            };

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                CreateDatabase(connection);
                CreateTable(connection);
            }
        }

        private static string GetSqlInstanceNameFromService(string hostname, string username, string password)
        {
            var instanceName = string.Empty;
            try
            {
                var connection = new ConnectionOptions
                {
                    Username = username,
                    Password = password,
                    //Authority = "ntlmdomain:";
                };

                var scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", hostname), connection);

                scope.Connect();

                var query = new ObjectQuery("SELECT * FROM Win32_Service");
                var searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject wmiObject in searcher.Get())
                {
                    if (wmiObject["Name"].ToString().Contains("MSSQL"))
                    {
                        instanceName = GetInstanceNameFromServiceName(wmiObject["Name"].ToString());
                    }

                }
            }
            catch (Exception e)
            {
                Logger.LogError("SQL Service not found on the server.", hostname, e);
            }

            return instanceName;
        }

        private static string GetInstanceNameFromServiceName(string serviceName)
        {
            if (!string.IsNullOrEmpty(serviceName))
            {
                return string.Equals(serviceName, "MSSQLSERVER", StringComparison.OrdinalIgnoreCase)
                    ? serviceName
                    : serviceName.Substring(serviceName.IndexOf('$') + 1,
                        serviceName.Length - serviceName.IndexOf('$') - 1);
            }
            return string.Empty;
        }

        private static void CreateDatabase(SqlConnection connection)
        {
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = hostname + "\\" + instance;
            //builder.UserID = username;
            //builder.Password = password;

            //builder.IntegratedSecurity = true;

            //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //{
            //    connection.Open();

            //try
            //{
            using (var command = new SqlCommand("CREATE DATABASE GenerationDB", connection))
            {
                command.ExecuteNonQuery();
            }
            //}
            //catch (SqlException e)
            //{
            //    Logger.LogError("Creation of database failed.",);
            //}
            //}
        }

        static void CreateTable(SqlConnection connection)
        {
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = hostname + "\\" + instance;
            //builder.UserID = username;
            //builder.Password = password;
            //builder.InitialCatalog = "GenerationDB";
            //builder.IntegratedSecurity = true;


            //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //{
            //    connection.Open();

            //try
            //{
            using (
                var command =
                    new SqlCommand(
                        "CREATE TABLE GenerationDB.GeneratedTable (Q TEXT, W TEXT, E TEXT, R TEXT, T TEXT, Y TEXT, U TEXT, I TEXT, O TEXT, P TEXT)",
                        connection))
            {
                command.ExecuteNonQuery();
            }
            //}
            //catch
            //{
            //    Console.WriteLine("Table not created.");
            //}
            //}
        }

        static void AddEntries(SqlConnection connection, int rowsToAdd, CancellationToken token)
        {
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = hostname + "\\" + instance;
            //builder.UserID = username;
            //builder.Password = password;
            //builder.InitialCatalog = "GenerationDB";
            //builder.IntegratedSecurity = true;


            //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            //{
            //    connection.Open();

            var stringLength = new Random();
            for (int i = 0; i < rowsToAdd; i++)
            {
                //try
                //{
                    using (
                        SqlCommand command =
                            new SqlCommand(
                                "INSERT INTO GenerationDB.GeneratedTable VALUES(@Q, @W, @E, @R, @T, @Y, @U, @I, @O, @P)",
                                connection))
                    {
                        command.Parameters.Add(new SqlParameter("Q", HelperMethods.RandomString(stringLength.Next(0,1000))));
                        command.Parameters.Add(new SqlParameter("W", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.Parameters.Add(new SqlParameter("E", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.Parameters.Add(new SqlParameter("R", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.Parameters.Add(new SqlParameter("T", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.Parameters.Add(new SqlParameter("Y", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.Parameters.Add(new SqlParameter("U", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.Parameters.Add(new SqlParameter("I", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.Parameters.Add(new SqlParameter("O", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.Parameters.Add(new SqlParameter("P", HelperMethods.RandomString(stringLength.Next(0, 1000))));
                        command.ExecuteNonQuery();
                    }
                //}
                //catch
                //{
                //    Console.WriteLine("Count not insert.");
                //}
                if (token.IsCancellationRequested)
                    break;
            }
        }


        static void GetDBList()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "10.23.10.20\\SQLEXPRESS";
            builder.UserID = "administrator";
            builder.Password = "raid4us!";
            //builder.InitialCatalog = "DB1";
            builder.IntegratedSecurity = true;

            List<string> dbList = new List<string>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", connection))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dbList.Add(dr[0].ToString());
                        }

                    }
                }
            }

            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }

        

        

        }

        
}

