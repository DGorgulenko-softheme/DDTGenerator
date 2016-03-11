using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    class SQLServer : Server
    {
        public SQLGeneratorParameters SqlGeneratorParameters { get; set; }
        public SQLServer(string ip, string displayname, string repository, string username, string password) : base(ip, displayname, repository, username, password)
        {
        }

        public SQLServer(string ip, string username, string password) : base(ip, username, password)
        {
        }

        public void StartSQLGenerator()
        {
            SqlGenerator.StartGenerator(ServerCredentials, SqlGeneratorParameters, Cts.Token);           
        }
    }
}
