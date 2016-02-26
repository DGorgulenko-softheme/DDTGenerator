using System.Runtime.Serialization;
using System.IO;

namespace ChangeGen_v2
{
    [DataContract(Name = "ExchangeParametersContract")]
    public class ExchangeGeneratorParameters
    {
        public string Recipient { get; set; }

        [DataMember(Name = "MessageSizeMember")]
        public MailSize MessageSize { get; set; }

        public void SerizalizeExchangeParamsToFile()
        {
            var dcs = new DataContractSerializer(typeof(ExchangeGeneratorParameters));
            using (var fs = new FileStream("ExchangeParams.xml", FileMode.Create))
            {
                dcs.WriteObject(fs, this);
            }
        }

        public static ExchangeGeneratorParameters DeserializeExchangeParamsFromFile()
        {
            ExchangeGeneratorParameters deserializedExchangeParams = null;
            var dcs = new DataContractSerializer(typeof(ExchangeGeneratorParameters));
            try
            {
                using (var fs = new FileStream("ExchangeParams.xml", FileMode.Open))
                {
                    deserializedExchangeParams = (ExchangeGeneratorParameters)dcs.ReadObject(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            return deserializedExchangeParams;
        }

        public enum MailSize
        {
            Tiny = 1800,
            Small = 18400,
            Medium = 95200,
            Large = 504800,
            VeryLarge = 1041400,
            Huge = 5235700,
            Enormous = 10480000
        }
    }
}