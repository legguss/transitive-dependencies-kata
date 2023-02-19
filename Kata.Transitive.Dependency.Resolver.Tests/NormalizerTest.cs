using static Kata.Transitive.Dependency.Resolver.Tests.NormalizerTestCaseCatalogue;

namespace Kata.Transitive.Dependency.Resolver.Tests;

public class NormalizerTest
{
   private static TestCase[] Cases =
   {
      DenormalizedDuplicatedEntryCase,
      DenormalizedSingleCase,
      EmptyCase,
      SingleEntryCase,
      DenormalizedCase
   };

   [Test, TestCaseSource(nameof(Cases))]
   public void NormalizeTest(TestCase testCase)
   {
      var output = testCase.Input.NormalizeInput()
         .Select(
            item => new[] { item.Key }.Concat(item.Value)
         ).ToArray();

      Assert.That(output, Is.EqualTo(testCase.Expected));
   }
}
