using System;
using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;

namespace Zigzag.Common
{
    class XmlUtil
    {

        public static string ExtractString(XmlNode node, string nodeName, string defualtVal, bool isMust)
        {
            string result = defualtVal;

            if (node == null || !node.HasChildNodes || node.SelectSingleNode(nodeName) == null)
            {
                if (isMust)
                {
                    Debug.Assert(false, "ExtactString Error!");
                }

                return result;
            }

            XmlNode childNode = node.SelectSingleNode(nodeName);

            string nodeText = childNode.InnerText;
            if (string.IsNullOrEmpty(nodeText))
            {
                if (isMust)
                {
                    Debug.Assert(false, "ExtactString Error!");
                }
            }
            else
            {
                result = nodeText;
            }

            return result;
        }

        public static bool ExtractBool (XmlNode node, string nodeName, bool defualtVal, bool isMust)
        {
            bool result = defualtVal;

            if (node == null || !node.HasChildNodes || node.SelectSingleNode(nodeName) == null)
            {
                if (isMust)
                {
                    Debug.Assert(false, "ExtactString Error!");
                }

                return result;
            }

            XmlNode childNode = node.SelectSingleNode(nodeName);

            string nodeText = childNode.InnerText;
            if (string.IsNullOrEmpty(nodeText))
            {
                if (isMust)
                {
                    Debug.Assert(false, "ExtactString Error!");
                }
            }
            else
            {
                if (nodeText.Trim().ToLower() == "true" || nodeText.Trim().ToLower() == "1")
                {
                    result = true;
                }

                if (nodeText.Trim().ToLower() == "false" || nodeText.Trim().ToLower() == "0")
                {
                    result = false;
                }
            }

            return result;
        }

        public static T ExtractNumeric<T>(XmlNode node, string nodeName, T defualtVal, bool isMust)
        {
            T result = defualtVal;

            if (node == null || !node.HasChildNodes || node.SelectSingleNode(nodeName) == null)
            {
                if (isMust)
                {
                    Debug.Assert(false, "ExtactString Error!");
                }

                return result;
            }

            XmlNode childNode = node.SelectSingleNode(nodeName);

            string nodeText = childNode.InnerText;
            if (string.IsNullOrEmpty(nodeText))
            {
                if (isMust)
                {
                    Debug.Assert(false, "ExtactString Error!");
                }
            }
            else
            {
                result = (T)Convert.ChangeType(nodeText, typeof(T));
            }

            return result;
        }
    }
}
