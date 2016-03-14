using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    internal static class Csv
    {
        public static void ServersToCsv(this List<Server> serverList, string filePath)
        {
            var sb = new StringBuilder();

            sb.Append("IP,Username,Password");

            sb.AppendLine();
            if (serverList == null)
            {
                MessageBox.Show("There are no servers to export!", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var server in serverList)
            {
                sb.Append(server.ServerCredentials.Ip + "," + server.ServerCredentials.Username + "," +
                          server.ServerCredentials.Password);
               
                sb.AppendLine();
            }
            try
            {
                File.WriteAllText(filePath, sb.ToString());
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public static void SqlServersToCsv(this List<SqlServer> serverList, string filePath)
        {
            var sb = new StringBuilder();

            sb.Append("IP,Username,Password");

            sb.AppendLine();
            if (serverList == null)
            {
                MessageBox.Show("There are no servers to export!", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var server in serverList)
            {
                sb.Append(server.ServerCredentials.Ip + "," + server.ServerCredentials.Username + "," +
                          server.ServerCredentials.Password);

                sb.AppendLine();
            }
            try
            {
                File.WriteAllText(filePath, sb.ToString());
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void ExchangeServersToCsv(this List<ExchangeServer> serverList, string filePath)
        {
            var sb = new StringBuilder();
 
            sb.Append("IP,Username,Password,Domain");

            sb.AppendLine();

            if (serverList == null)
            {
                MessageBox.Show("There are no servers to export!", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var server in serverList)
            {
                sb.Append(server.ServerCredentials.Ip + "," + server.ServerCredentials.Username + "," +
                           server.ServerCredentials.Password + ","+ server.ServerCredentials.Domain);

                sb.AppendLine();
            }

            try
            {
                File.WriteAllText(filePath, sb.ToString());
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CsVtoServersList(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                sr.ReadLine(); // to skip the line with headers
                try
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line != null)
                        {
                            var values = line.Split(',');

                            ServerWrapper.AddServerManually(values[0], values[1], values[2]);
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Incorrect format of CSV File.\nPlease make sure that it has following format:\n{Ip,Userame,Password}", "CSV Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void CsVtoSqlServersList(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                sr.ReadLine(); // to skip the line with headers
                try
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line != null)
                        {
                            var values = line.Split(',');

                            ServerWrapper.AddSqlServerManually(values[0], values[1], values[2]);
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Incorrect format of CSV File.\nPlease make sure that it has following format:\n{Ip,Userame,Password}", "CSV Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void CsVtoExchangeServersList(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                sr.ReadLine(); // to skip the line with headers
                try
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line != null)
                        {
                            var values = line.Split(',');

                            ServerWrapper.AddExchangeServerManually(values[0], values[3], values[1], values[2]);
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Incorrect format of CSV File.\nPlease make sure that it has following format:\n{Ip,Userame,Password,Domain}", "CSV Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
