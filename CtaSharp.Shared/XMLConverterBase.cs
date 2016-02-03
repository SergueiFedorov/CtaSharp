using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CtaSharp.Shared
{
    public abstract class XMLConverterBase<T>
    {
        protected string _elementName { get; set; }

        protected XMLConverterBase(string baseElementName)
        {
            this._elementName = baseElementName;
        }

        protected abstract T ConvertItem(XElement XMLElement);

        public virtual IEnumerable<T> Convert(string XML, string parentNodeName)
        {
            if (string.IsNullOrEmpty(XML) || string.IsNullOrEmpty(parentNodeName))
            {
                throw new ArgumentNullException();
            }

            var parsedXML = XDocument.Parse(XML);
            var parentNode = parsedXML.Descendants().Where(x => x.Name == parentNodeName);
            var items = parentNode.SelectMany(x => x.Descendants().Where(y => y.Name == _elementName));

            List<T> returnList = new List<T>();
            foreach (var item in items)
            {
                returnList.Add(this.ConvertItem(item));
            }

            return returnList;
        }
    }
}
