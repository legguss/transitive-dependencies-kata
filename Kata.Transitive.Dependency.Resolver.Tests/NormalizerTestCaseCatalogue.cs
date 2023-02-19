namespace Kata.Transitive.Dependency.Resolver.Tests;

public static class NormalizerTestCaseCatalogue
{
   public static readonly TestCase DenormalizedDuplicatedEntryCase = new(
      new[] { "ABC", "ABC" },
      new[] { "ABC" }
   );

   public static readonly TestCase DenormalizedCase = new(
      new[] { "ABC", "ABC", "ACB", "AGHM", "AA", "GX", "GXX" },
      new[] { "ABCGHM", "GX" }
   );

   public static readonly TestCase EmptyCase = new(
      new[] { "A", "B", "" },
      Array.Empty<string>()
   );

   public static readonly TestCase SingleEntryCase = new(
      new[] { "ABC" },
      new[] { "ABC" }
   );

   public static readonly TestCase DenormalizedSingleCase = new(
      new[] { "ABC", "ABC", "ACB", "AGHM", "AA" },
      new[] { "ABCGHM" }
   );
}
