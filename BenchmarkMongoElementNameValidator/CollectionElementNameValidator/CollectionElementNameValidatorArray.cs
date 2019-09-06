using System;

namespace BenchmarkMongoElementNameValidator.CollectionElementNameValidator
{
    public class CollectionElementNameValidatorArray : IElementNameValidator
    {
        private static readonly string[] __exceptions = new[] { "$db", "$ref", "$id", "$code", "$scope" };
        private static readonly CollectionElementNameValidatorArray __instance = new CollectionElementNameValidatorArray();

        public static CollectionElementNameValidatorArray Instance
        {
            get { return __instance; }
        }

        public IElementNameValidator GetValidatorForChildContent(string elementName)
        {
            return this;
        }

        public bool IsValidElementName(string elementName)
        {
            Ensure.IsNotNull(elementName, nameof(elementName));

            if (elementName.Length == 0)
            {
                // the server seems to allow empty element names, but in 1.x we did not
                return false;
            }

            if (elementName.IndexOf('.') != -1)
            {
                return false;
            }

            if (elementName[0] == '$' && Array.IndexOf(__exceptions, elementName) == -1)
            {
                return false;
            }

            return true;
        }
    }
}
