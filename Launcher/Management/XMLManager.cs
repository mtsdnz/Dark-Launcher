using System;
using System.Xml;

namespace Launcher.Management
{
    public class XmlManager : IDisposable
    {
        private XmlDocument _doc;
        private bool _disposed;

        public void InitializeFromFile(string fileName)
        {
            _doc = new XmlDocument();
            _doc.Load(fileName);
        }

        public void InitializeFromString(string xml)
        {
            _doc = new XmlDocument();
            _doc.LoadXml(xml);
        }

        public XmlNode GetNode(string nodePath)
        {
            return _doc.SelectSingleNode(nodePath);
        }

        public XmlNodeList GetNodes(string nodePath)
        {
            return _doc.SelectNodes(nodePath);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(_disposed) return;

            if (disposing)
                _doc = null;

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
