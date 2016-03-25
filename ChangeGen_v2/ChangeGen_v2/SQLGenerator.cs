using System;
using System.Data.SqlClient;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    internal static class SqlGenerator
    {
        private static Random _random;

        private static readonly object Lock = new object();
        public static void StartGenerator(SqlServer sqlServer)
        {
            var rowsAdded = 0;
            var instance = GetSqlInstanceNameFromService(sqlServer.ServerCredentials.Ip, sqlServer.ServerCredentials.Username, sqlServer.ServerCredentials.Password);
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = sqlServer.ServerCredentials.Ip +",1433" + "\\" + instance,
                NetworkLibrary = "DBMSSOCN",
                UserID = sqlServer.ServerCredentials.Username,
                Password = sqlServer.ServerCredentials.Password,
                IntegratedSecurity = true,
                InitialCatalog = sqlServer.SqlGeneratorParameters.DbName,
                ConnectTimeout = 300
            };

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch(SqlException e)
                {
                    Logger.LogError("Unable to open SQL connection to instance " + instance + ".", sqlServer.ServerCredentials.Ip,e);
                    throw;
                }
                Logger.Log("Successfully connected to SQL server",Logger.LogLevel.Info, sqlServer.ServerCredentials.Ip);
                try
                {
                    CreateTable(connection);
                }
                catch (SqlException e)
                {
                    if (!e.Message.Contains("There is already an object named"))
                    {
                        Logger.LogError("Unable to create table.", sqlServer.ServerCredentials.Ip, e);
                        throw;
                    }
                }
                try
                {
                    _random = new Random();

                    Parallel.For(0, sqlServer.SqlGeneratorParameters.RowsToInsert, (action, state) =>
                    {
                        if (sqlServer.Cts.IsCancellationRequested)
                        {
                            sqlServer.ServerGeneratorStatus = Server.GeneratorStatus.Stopped;
                            state.Break();
                        }
                        var connection1 = new SqlConnection(builder.ConnectionString);
                        connection1.Open();
                        AddEntries(connection1, _random);
                        connection1.Close();
                        lock (Lock)
                        {
                            rowsAdded++;
                        }

                        UpdateProgress(sqlServer,rowsAdded,sqlServer.SqlGeneratorParameters.RowsToInsert);
                    });
                    sqlServer.Cts.Token.ThrowIfCancellationRequested();
                }
                catch (SqlException e)
                {
                    Logger.LogError("Unable to insert data to the SQL table.", sqlServer.ServerCredentials.Ip,e);
                    throw;
                }

                Logger.Log("Successfully completed SQL generation", Logger.LogLevel.Info, sqlServer.ServerCredentials.Ip);
            }
        }

        private static void UpdateProgress(SqlServer sqlServer, int rowsAdded, int rowsToAdd)
        {
            sqlServer.Progress = rowsAdded*100/rowsToAdd;
        }

        private static string GetSqlInstanceNameFromService(string hostname, string username, string password)
        {
            var instanceName = string.Empty;
            var connection = new ConnectionOptions
            {
                Username = username,
                Password = password,
                Authority = "ntlmdomain:"
            };

            var scope = new ManagementScope(string.Format("\\\\{0}\\root\\CIMV2", hostname), connection);

            var retries = 0;

            while (true)
            {
                try
                {
                    scope.Connect();
                    break;
                }
                catch (ManagementException e)
                {
                    if (e.Message.Contains("local connections"))
                    {
                        scope = new ManagementScope(string.Format("\\\\{0}\\root\\CIMV2", hostname));
                        scope.Connect();
                        break;
                    }
                    else
                    {
                        Logger.LogError("Unable to connect to WMI.", hostname, e);
                        throw;
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    Logger.LogError("Unable to connect to WMI.", hostname, e);
                    throw;
                }
                catch (COMException e)
                {
                    if (retries < 3)
                    {
                        retries++;
                        Logger.LogError("Cannot connect to remote RPC server. Retry in 15 seconds", hostname, e);
                        Thread.Sleep(15000);
                    }
                    else
                    {
                        Logger.LogError("Cannot connect to remote WMI. RPC server is unavailable", hostname, e);
                        throw;
                    }    
                }
            }
            var query = new ObjectQuery("SELECT * FROM Win32_Service");
            var searcher = new ManagementObjectSearcher(scope, query);

            foreach (var o in searcher.Get())
            {
                var wmiObject = (ManagementObject) o;
                if (!wmiObject["Caption"].ToString().Contains("SQL Server (")) continue;
                var servicename = wmiObject["Caption"].ToString();
                instanceName = servicename.Substring(servicename.IndexOf('(') + 1,
                    servicename.Length - servicename.IndexOf('(') - 2);
            }
            return instanceName;
        }

        private static void CreateTable(SqlConnection connection)
        {
            using (
                var command =
                    new SqlCommand(
                        "CREATE TABLE GeneratedTable (Q TEXT, W TEXT, E TEXT, R TEXT, T TEXT, Y TEXT, U TEXT, I TEXT, O TEXT, P TEXT)",
                        connection))
            {
                command.ExecuteNonQuery();
            }        
        }

        private static void AddEntries(SqlConnection connection, Random random1)
        {
            using (
                var command =
                    new SqlCommand(
                        "INSERT INTO GeneratedTable VALUES(@Q, @W, @E, @R, @T, @Y, @U, @I, @O, @P)",
                        connection))
            {
                lock (Lock)
                {
                    command.Parameters.Add(new SqlParameter("Q", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("W", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("E", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("R", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("T", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("Y", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("U", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("I", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("O", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                    command.Parameters.Add(new SqlParameter("P", HelperMethods.RandomString(random1.Next(0, 100), random1)));
                }
                command.ExecuteNonQuery();
            }
        }
    }       
}

