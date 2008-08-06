using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hattrick.Service
{
    public static class ExtensionMethods
    {
        public static XDocument GetXmlDocument(this Stream inputStream)
        {
            string s = new System.IO.StreamReader(inputStream).ReadToEnd();

            XDocument cXDocument = XDocument.Parse(s);

            return cXDocument;
        }
    }
}