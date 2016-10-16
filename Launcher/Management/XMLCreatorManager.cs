using System;
using System.Xml;
namespace Launcher.Management
{
    public class XMLCreatorManager
    {
        protected XmlDocument doc;
        public XmlDocument Doc
        {
            get { return doc; }
            set { doc = value; }
        }

        private XmlElement _element;
        public XmlElement XElement => _element;

        public void CreateDocument(string elementRootName)
        {
            doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement rootDoc = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, rootDoc);
            _element = doc.CreateElement(elementRootName);
            CreateCreditsComment(elementRootName, rootDoc);

        }

        private void CreateCreditsComment(string name, XmlElement element)
        {
            var comment = doc.CreateComment("\n    " + name + " Configurations. \n    Copyright © " + DateTime.Now.Year + " - DarkHero. \n");
            doc.InsertBefore(comment, element);
        }

        public void CreateComment(string comment, XmlElement element)
        {
            XmlComment Xmlcomment;
            Xmlcomment = doc.CreateComment(comment);
            doc.InsertBefore(Xmlcomment, element);
        }

        public void CreateAttribute(XmlElement element, string attributeName, dynamic attributeText)
        {
            if (attributeText == null)
                return;
            XmlAttribute attribute = doc.CreateAttribute(attributeName);
            attribute.Value = attributeText.ToString();
            element.Attributes.Append(attribute);
        }
        public XmlElement CreateElement(string elementName)
        {
            XmlElement element = doc.CreateElement(elementName);
            _element.AppendChild(element);
            doc.AppendChild(_element);
            return element;
        }

        public XmlElement CreateElementInChild(string elementName, XmlElement elementChild)
        {
            XmlElement element = doc.CreateElement(elementName);
            elementChild.AppendChild(element);
            doc.AppendChild(_element);
            return element;
        }

        public void SaveXml(string path)
        {
            doc.Save(path);
        }
    }
}
