using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkMongoElementNameValidator.CollectionElementNameValidator;

namespace BenchmarkMongoElementNameValidator
{
    public class IsValidElementNameBenchmark
    {
        private readonly IElementNameValidator elementNameValidator = CollectionElementNameValidator.CollectionElementNameValidator.Instance;
        private readonly IElementNameValidator elementNameValidatorHashSet = CollectionElementNameValidatorHashSet.Instance;
        private readonly IElementNameValidator elementNameValidatorArray = CollectionElementNameValidatorArray.Instance;

        [Params("$db", "$ref", "$id", "$code", "$scope", "$notInExceptionList")]
        public string elementName;

        [Benchmark]
        public bool IsValidElementNameOriginal() => elementNameValidator.IsValidElementName(elementName);

        [Benchmark]
        public bool IsValidElementNameArray() => elementNameValidatorArray.IsValidElementName(elementName);

        [Benchmark]
        public bool IsValidElementNameHashSet() => elementNameValidatorHashSet.IsValidElementName(elementName);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<IsValidElementNameBenchmark>();
        }
    }
}