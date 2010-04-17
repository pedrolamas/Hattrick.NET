using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Hattrick.CodeSmithHelpers
{
    public static class ResponseHelpers
    {
        public static string GetClassName(string filename)
        {
            return filename + "ResponseInfo";
        }

        public static IEnumerable<String> GetComplexChildNodeNames(XElement elm)
        {
            return GetComplexChildNodeNames(elm, false);
        }

        public static IEnumerable<String> GetComplexChildNodeNames(XElement elm, bool recursive)
        {
            return GetComplexChildElements(elm, recursive).Select(e => e.Name.ToString());
        }

        public static IEnumerable<XElement> GetComplexChildElements(XElement elm)
        {
            return GetComplexChildElements(elm, false);
        }

        public static IEnumerable<XElement> GetComplexChildElements(XElement elm, bool recursive)
        {
            var complexElms = elm.Elements().Where(e => e.HasElements == true);

            if (recursive)
            {
                foreach (XElement complexElm in complexElms)
                {
                    var childs = GetComplexChildElements(complexElm, true);
                    complexElms = complexElms.Concat(childs);
                }
            }

            return complexElms;
        }

        public static IEnumerable<String> GetSimpleChildNodeNames(XElement elm)
        {
            var names = GetSimpleChildElements(elm).Select(e => e.Name.ToString());

            return names;
        }

        public static IEnumerable<XElement> GetSimpleChildElements(XElement elm)
        {
            var SimpleElms = elm.Elements().Where(e => e.HasElements == false);

            return SimpleElms;
        }

        public static string GetPropertyTypeByNameValue(string name, string value)
        {
            if (name.EndsWith("ID", false, null))
            {
                return "int";
            }
            if (name.EndsWith("Date", false, null))
            {
                return "DateTime";
            }
            int dummyInt;
            if (int.TryParse(value, out dummyInt) == true)
            {
                return "int";
            }
            DateTime dummyDate;
            if (DateTime.TryParse(value, out dummyDate) == true)
            {
                return "DateTime";
            }
            if (name.EndsWith("Capacity", false, null))
            {
                return "int";
            }

            if(value == "True" || value == "False")
            {
                return "Boolean";
            }
            // OTherwise...
            return "string";
        }
    }
}
