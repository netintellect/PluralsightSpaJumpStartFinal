namespace ProjectFilesListGenerator
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class ExamplesXMLValidator
    {
        /// <summary>
        /// Validates a document using a default schema.
        /// </summary>
        /// <param name="document">The document to validate.</param>
        /// <param name="validationFailedCallback">Callback when the validation has failed.</param>
        public static void Validate(XDocument document, Action<string> validationFailedCallback)
        {
            ExamplesXMLValidator.Validate(document, "/Application;component/ExamplesSchema.xsd", validationFailedCallback);
        }

        /// <summary>
        /// Validates a document using a given schema, built from an uri.
        /// </summary>
        /// <param name="document">The document to validate.</param>
        /// <param name="schemaUri">Uri for the schema. Usually something like "/Application;component/Schema.xsd".</param>
        /// <param name="validationFailedCallback">Callback when the validation has failed.</param>
        public static void Validate(XDocument document, string schemaUri, Action<string> validationFailedCallback)
        {
            ExamplesXMLValidator.AssertInputParamsAreValid(document, schemaUri, validationFailedCallback);
            
            ValidationEventHandler handler = (obj, args) =>
            {
                validationFailedCallback(args.Message);
            };

            var schema = XmlSchema.Read(XmlReader.Create(schemaUri), handler);

            ExamplesXMLValidator.Validate(document, schema, validationFailedCallback);
        }

        /// <summary>
        /// Validates a document using a given schema.
        /// </summary>
        /// <param name="document">The document to validate.</param>
        /// <param name="schemaUri">The schema to validate with.</param>
        /// <param name="validationFailedCallback">Callback when the validation has failed.</param>
        public static void Validate(XDocument document, XmlSchema schema, Action<string> validationFailedCallback)
        {
            ExamplesXMLValidator.AssertInputParamsAreValid(document, schema, validationFailedCallback);

            ValidationEventHandler handler = (obj, args) =>
            {
                validationFailedCallback(args.Message);
            };

            XmlSchemaSet set = new XmlSchemaSet();
            set.Add(schema);

            document.Validate(set, handler);
        }

        private static void AssertInputParamsAreValid(XDocument document, XmlSchema schema, Action<string> validationFailedCallback)
        {
            if (document == null || schema == null || validationFailedCallback == null)
            {
                throw new ArgumentException("Document, schema and callback must not be null or empty.");
            }
        }        
        
        private static void AssertInputParamsAreValid(XDocument document, string schemaUri, Action<string> validationFailedCallback)
        {
            if (document == null || string.IsNullOrEmpty(schemaUri) || string.IsNullOrWhiteSpace(schemaUri) || validationFailedCallback == null)
            {
                throw new ArgumentException("Document, schema and callback must not be null or empty.");
            }
        }
    }
}
