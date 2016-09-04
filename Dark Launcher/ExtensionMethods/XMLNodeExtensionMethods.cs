using System;
using System.Xml;

namespace Dark_Launcher.ExtensionMethods
{
    public static class XMLNodeExtension
    {
        public static int ParseIntAttribute(this XmlNode node, string attributeName)
        {
            return int.Parse(node.Attributes[attributeName].Value);
        }

        public static float ParseFloatAttribute(this XmlNode node, string attributeName)
        {
            return float.Parse(node.Attributes[attributeName].Value);
        }

        public static string ParseStringAttribute(this XmlNode node, string attributeName)
        {
            return node.Attributes[attributeName].Value;
        }

        public static T ParseEnumAttribute<T>(this XmlNode node, string attributeName)
        {
            return (T)Enum.Parse(typeof(T), node.Attributes[attributeName].Value, true);
        }

        public static bool HasAttribute(this XmlNode node, string attributeName)
        {
            return node.Attributes[attributeName] != null;
        }

        public static string[] ParseSplittedAttribute(this XmlNode node, string attributeName, char splitChar)
        {
            return node.Attributes[attributeName].Value.Split(splitChar);
        }

        public static int[] ParseSplittedIntAttribute(this XmlNode node, string attributeName, char splitChar)
        {
            return Array.ConvertAll(node.ParseSplittedAttribute(attributeName, splitChar), new Converter<string, int>((s) => { return Convert.ToInt32(s); }));
        }

        public static bool ParseBoolAttribute(this XmlNode node, string attributeName, string trueValue = null)
        {
            string attributeValue = node.Attributes[attributeName].Value;

            if (trueValue != null)
            {
                return attributeValue == trueValue;
            }
            else
            {
                return bool.Parse(attributeValue);
            }
        }

        public static byte ParseByteAttribute(this XmlNode node, string attributeName)
        {
            return byte.Parse(node.Attributes[attributeName].Value);
        }
    }
}
