using System.IO;
using System.Runtime.Serialization;

namespace ChangeGen_v2
{
    [DataContract(Name = "DDTParametersContract")]
    internal class DdtParameters
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

        public void SerizalizeDdtParamsToFile()
        {
            var dcs = new DataContractSerializer(typeof(DdtParameters));
            using (var fs = new FileStream("DDTParams.xml", FileMode.Create))
            {
                dcs.WriteObject(fs, this);
            }
        }

        public static DdtParameters DeserializeDdtParamsFromFile()
        {
            DdtParameters deserializedDdTparams;
            var dcs = new DataContractSerializer(typeof(DdtParameters));
            try
            {
                using (var fs = new FileStream("DDTParams.xml", FileMode.Open))
                {
                    deserializedDdTparams = (DdtParameters)dcs.ReadObject(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }

            return deserializedDdTparams;
        }
    }
}
