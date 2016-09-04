using System.Xml;

namespace Dark_Launcher.Management
{
    public sealed class XMLManager
    {
        public static XMLManager CreateXML()
        {
            return new XMLManager();
        }

        private XmlDocument doc;

        public void InitializeFromFile(string fileName)
        {
            doc = new XmlDocument();
            doc.Load(fileName);
        }

        public void InitializeFromString(string xml)
        {
            doc = new XmlDocument();
            doc.LoadXml(xml);
        }

        public XmlNode GetNode(string nodePath)
        {
            return doc.SelectSingleNode(nodePath);
        }

        public XmlNodeList GetNodes(string nodePath)
        {
            return doc.SelectNodes(nodePath);
        }

    }
}
