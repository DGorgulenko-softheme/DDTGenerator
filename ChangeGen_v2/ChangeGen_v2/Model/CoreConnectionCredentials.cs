using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    [DataContract(Name = "CoreConnectionCredentialsContract")]
    public sealed class CoreConnectionCredentials
    {
        [DataMember(Name = "HostnameMember")]
        public string Hostname { get; set; }

        [DataMember(Name = "PortMember")]
        public int Port { get; set; }

        [DataMember(Name = "UsernameMember")]
        public string  Username { get; set; }

        [DataMember(Name = "PasswordMember")]
        public string Password { get; set; }

        public void SerizalizeCredsToFile ()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(CoreConnectionCredentials));
            using (var fs = new FileStream("CoreCreds.xml", FileMode.Create))
            {
                dcs.WriteObject(fs, this);
            }
        }

        public static CoreConnectionCredentials DeserializeCredsFromFile()
        {
            CoreConnectionCredentials deserializedCreds = null;
            DataContractSerializer dcs = new DataContractSerializer(typeof(CoreConnectionCredentials));
            try
            {
                using (var fs = new FileStream("CoreCreds.xml", FileMode.Open))
                {
                    deserializedCreds = (CoreConnectionCredentials)dcs.ReadObject(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            
            return deserializedCreds;
        }
    }
}
