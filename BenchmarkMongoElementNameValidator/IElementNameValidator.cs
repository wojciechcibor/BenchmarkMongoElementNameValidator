namespace BenchmarkMongoElementNameValidator
{
    public interface IElementNameValidator
    {
        IElementNameValidator GetValidatorForChildContent(string elementName);
        bool IsValidElementName(string elementName);
    }
}
