using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    [DataContract(Name = "DDTParametersContract")]
    class DDTParameters
    {
        [DataMember(Name ="filepathMember")]
        private string _filepath;

        [DataMember(Name = "FilesizeMember")]
        public int Filesize { get; set; }

        [DataMember(Name = "CompressionMember")]
        public int Compression { get; set; }

        [DataMember(Name = "IntervalMember")]
        public int Interval { get; set; }

        public string Filepath
        {
            get
            {
                return _filepath;
            }
            set
            {
                if (!value.EndsWith("\\"))  // Check if value in tb_Path is end with '\' symbol
                {
                    value += "\\";
                }
                _filepath = value;
            }
        }

        public void SerizalizeDDTParamsToFile()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(DDTParameters));
            using (var fs = new FileStream("DDTParams.xml", FileMode.Create))
            {
                dcs.WriteObject(fs, this);
            }
        }

        public static DDTParameters DeserializeDDTParamsFromFile()
        {
            DDTParameters deserializedDDTparams = null;
            DataContractSerializer dcs = new DataContractSerializer(typeof(DDTParameters));
            try
            {
                using (var fs = new FileStream("DDTParams.xml", FileMode.Open))
                {
                    deserializedDDTparams = (DDTParameters)dcs.ReadObject(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }

            return deserializedDDTparams;
        }
    }
}
