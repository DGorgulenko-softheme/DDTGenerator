using System;
using System.Data.SqlClient;
using System.Management;
using System.Runtime.InteropServices;

namespace ChangeGen_v2
{
    internal class SqlServer : Server
    {
        public SqlGeneratorParameters SqlGeneratorParameters { get; }

        public int Progress { get; set; }
        public SqlServer(string ip, string displayname, string repository, string username, string password) : base(ip, displayname, repository, username, password)
        {
            if (SqlGeneratorParameters == null)
                SqlGeneratorParameters = new SqlGeneratorParameters();
        }

        public SqlServer(string ip, string username, string password) : base(ip, username, password)
        {
            if (SqlGeneratorParameters == null)
                SqlGeneratorParameters = new SqlGeneratorParameters();
        }

        public void StartSqlGenerator()
        {
            try
            {
                SqlGenerator.StartGenerator(this);
            }
            catch (SqlException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
                return;
            }
            catch (UnauthorizedAccessException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
                return;
            }
            catch (COMException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
                return;
            }
            catch (ManagementException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
                return;
            }
            catch (OperationCanceledException)
            {
                ServerGeneratorStatus = GeneratorStatus.Stopped;
                return;
            }
            ServerGeneratorStatus = GeneratorStatus.Completed;
                   
        }
    }
}
