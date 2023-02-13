using static Kata.Transitive.Dependency.Resolver.Tests.TestCaseCatalogue;

namespace Kata.Transitive.Dependency.Resolver.Tests;

public class NormalizerTest
{
   private static TestCase[] Cases =
   {
      DenormalizedDuplicatedEntryCase,
      DenormalizedSingleCase,
      EmptyCase
   };

   [Test, TestCaseSource(nameof(Cases))]
   public void NormalizeTest(TestCase testCase)
   {
      var output = testCase.Input.NormalizeDependencies()
         .Select(
            item => new[] { item.Key }.Concat(item.Value)
         ).ToArray();

      Assert.That(output, Is.EqualTo(testCase.Output));
   }
}
