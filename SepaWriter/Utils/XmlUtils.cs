using System.Xml;

namespace SepaWriter.Utils
{
    /// <summary>
    ///     Some Utilities to manage XML
    /// </summary>
    public static class XmlUtils
    {
        /// <summary>
        ///     Find First element in the Xml document with provided name
        /// </summary>
        /// <param name="document">The Xml Document</param>
        /// <param name="nodeName">The name of the node</param>
        /// <returns></returns>
        public static XmlElement GetFirstElement(XmlNode document, string nodeName)
        {
            return document.SelectSingleNode("//" + nodeName) as XmlElement; 
        }
        /// <summary>
        ///     Create a BIC, using the "BIC" element name (schemas up to pain.001.001.04 / pain.008.001.03)
        /// </summary>
        /// <param name="element">The Xml element</param>
        /// <param name="iban">The iban</param>
        /// <returns></returns>
        public static void CreateBic(XmlElement element, SepaIbanData iban)
        {
            CreateBic(element, iban, SepaSchema.Pain00100103);
        }

        /// <summary>
        ///     Create a BIC using the element name expected by the provided schema
        ///     ("BICFI" since pain.001.001.09 / pain.008.001.08, "BIC" before)
        /// </summary>
        /// <param name="element">The Xml element</param>
        /// <param name="iban">The iban</param>
        /// <param name="schema">The schema of the generated file</param>
        /// <returns></returns>
        public static void CreateBic(XmlElement element, SepaIbanData iban, SepaSchema schema)
        {
            if (iban.UnknownBic)
            {
                element.NewElement("FinInstnId").NewElement("Othr").NewElement("Id", "NOTPROVIDED");
            }
            else
            {
                element.NewElement("FinInstnId").NewElement(SepaSchemaUtils.BicElementName(schema), iban.Bic);
            }
        }
    }
}
