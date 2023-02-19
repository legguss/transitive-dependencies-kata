using static Kata.Transitive.Dependency.Resolver.Tests.ResolverTestCaseCatalogue;

namespace Kata.Transitive.Dependency.Resolver.Tests;

public class ResolverTest
{
   [SetUp]
   public void Setup()
   {
   }

   private static readonly TestCase[] Cases =
   {
      OriginalCase,
      DenormalizedDuplicatedEntryCase,
      SimpleCase,
      EmptyCase,
      DifferentLengthCyclicCase,
      RandomCase,
      DenormalizedSingleCase,
      SwingerCycleCase,
      SingleEntryCase,
      DenormalizedCase
      
   };

   [Test, TestCaseSource(nameof(Cases))]
   public void Resolve(TestCase testCase)
   {
      var output = testCase.Input.ResolveDependencies();
      Assert.That(output, Is.EqualTo(testCase.Expected));
   }
}
