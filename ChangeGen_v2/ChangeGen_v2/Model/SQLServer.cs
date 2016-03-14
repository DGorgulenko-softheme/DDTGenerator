using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    class SQLServer : Server
    {
        public SQLGeneratorParameters SqlGeneratorParameters { get; set; }
        public SQLServer(string ip, string displayname, string repository, string username, string password) : base(ip, displayname, repository, username, password)
        {
            if (SqlGeneratorParameters == null)
                SqlGeneratorParameters = new SQLGeneratorParameters();
        }

        public SQLServer(string ip, string username, string password) : base(ip, username, password)
        {
            if (SqlGeneratorParameters == null)
                SqlGeneratorParameters = new SQLGeneratorParameters();
        }

        public void StartSQLGenerator()
        {
            try
            {
                SqlGenerator.StartGenerator(ServerCredentials, SqlGeneratorParameters, Cts.Token);
            }
            catch (SqlException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
            }
            catch (UnauthorizedAccessException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
            }
            catch (COMException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
            }    
        }
    }
}
