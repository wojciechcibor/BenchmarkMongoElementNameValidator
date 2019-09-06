using System.Collections.Generic;

namespace BenchmarkMongoElementNameValidator.CollectionElementNameValidator
{
    public class CollectionElementNameValidatorHashSet : IElementNameValidator
    {
        private static readonly HashSet<string> __exceptions = new HashSet<string> { "$db", "$ref", "$id", "$code", "$scope" };
        private static readonly CollectionElementNameValidatorHashSet __instance = new CollectionElementNameValidatorHashSet();

        public static CollectionElementNameValidatorHashSet Instance
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

            if (elementName[0] == '$' && !__exceptions.Contains(elementName))
            {
                return false;
            }

            return true;
        }
    }
}
