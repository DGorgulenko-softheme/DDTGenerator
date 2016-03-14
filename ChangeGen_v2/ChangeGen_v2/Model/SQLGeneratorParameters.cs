using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    [DataContract(Name = "SQLParametersContract")]
    class SQLGeneratorParameters
    {
        [DataMember(Name = "RowsToInsertMember")]
        public int RowsToInsert { get; set; }

        [DataMember(Name = "DBNameMember")]
        public string DBName { get; set; }

        public void SerizalizeSQLParamsToFile()
        {
            var dcs = new DataContractSerializer(typeof(SQLGeneratorParameters));
            using (var fs = new FileStream("SQLParams.xml", FileMode.Create))
            {
                dcs.WriteObject(fs, this);
            }
        }

        public static SQLGeneratorParameters DeserializeSQLParamsFromFile()
        {
            SQLGeneratorParameters deserializedSQLParams = null;
            var dcs = new DataContractSerializer(typeof(SQLGeneratorParameters));
            try
            {
                using (var fs = new FileStream("SQLParams.xml", FileMode.Open))
                {
                    deserializedSQLParams = (SQLGeneratorParameters)dcs.ReadObject(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            return deserializedSQLParams;
        }
    }
}
