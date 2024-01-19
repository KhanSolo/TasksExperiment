
using System.Configuration;
using System.Xml;

namespace ConfigManagerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var conf = new EntraBankConfiguration();
            var pair = ConfigurationManager.GetSection("entraBank");

            Console.WriteLine("");
        }
    }

    [ConfigurationCollection(typeof(KeyValueConfigurationElement))]
    public class EntraBankConfiguration : IConfigurationSectionHandler
    {
        public string InputChannel { get; set; }
        public string MQPort { get; set; }

        public object Create(object parent, object configContext, XmlNode section)
        {
            var result = new EntraBankConfiguration();

            foreach (XmlNode node in section.ChildNodes)
            {
                var key = node.Attributes["key"].Value;
                var value = node.Attributes["value"].Value;

                if (key == "InputChannel")
                {
                    result.InputChannel = value;
                }
                else if (key == "MQPort")
                {
                    result.MQPort = value;
                }
            }

            return result;
        }

    }
}