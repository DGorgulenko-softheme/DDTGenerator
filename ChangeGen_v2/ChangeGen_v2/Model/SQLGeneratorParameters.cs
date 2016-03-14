using System.IO;
using System.Runtime.Serialization;

namespace ChangeGen_v2
{
    [DataContract(Name = "SQLParametersContract")]
    internal class SqlGeneratorParameters
    {
        [DataMember(Name = "RowsToInsertMember")]
        public int RowsToInsert { get; set; }

        [DataMember(Name = "DBNameMember")]
        public string DbName { get; set; }

        public void SerizalizeSqlParamsToFile()
        {
            var dcs = new DataContractSerializer(typeof(SqlGeneratorParameters));
            using (var fs = new FileStream("SQLParams.xml", FileMode.Create))
            {
                dcs.WriteObject(fs, this);
            }
        }

        public static SqlGeneratorParameters DeserializeSqlParamsFromFile()
        {
            SqlGeneratorParameters deserializedSqlParams = null;
            var dcs = new DataContractSerializer(typeof(SqlGeneratorParameters));
            try
            {
                using (var fs = new FileStream("SQLParams.xml", FileMode.Open))
                {
                    deserializedSqlParams = (SqlGeneratorParameters)dcs.ReadObject(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            return deserializedSqlParams;
        }
    }
}
