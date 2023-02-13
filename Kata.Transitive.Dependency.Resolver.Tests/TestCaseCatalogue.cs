namespace Kata.Transitive.Dependency.Resolver.Tests;

public record TestCase
{
   public TestCase(IEnumerable<string> input, IEnumerable<string> output)
   {
      Input = input
         .Select(item => item.Select(c => c.ToString()).ToArray())
         .ToArray();
      Output = output
         .Select(item => item.Select(c => c.ToString()).ToArray())
         .ToArray();
   }

   public string[][] Input { get; }
   public string[][] Output { get; }
};

public static class TestCaseCatalogue
{
   public static readonly TestCase OriginalCase = new(
      new[] { "ABC", "BCE", "CG", "DAF", "EF", "FH" },
      new[] { "ABCEFGH", "BCEFGH", "CG", "DABCEFGH", "EFH", "FH" }
   );

   public static readonly TestCase DenormalizedDuplicatedEntryCase = new(
      new[] { "ABC", "ABC" },
      new[] { "ABC" }
   );

   public static readonly TestCase SingleEntryCase = new(
      new[] { "ABC" },
      new[] { "ABC" }
   );

   public static readonly TestCase SimpleCase = new(
      new[] { "ABC", "BD" },
      new[] { "ABCD", "BD" }
   );

   public static readonly TestCase EmptyCase = new(
      new[] { "A", "B" },
      Array.Empty<string>()
   );

   public static readonly TestCase DifferentLengthCyclicCase = new(
      new[] { "ABCX", "CA" },
      new[] { "ABCX", "CABX" }
   );

   public static readonly TestCase RandomCase = new(
      new[] { "ABC", "CAZ", "MN", "ZBXC" },
      new[] { "ABCXZ", "CABXZ", "MN", "ZABCX" }
   );

   public static readonly TestCase DenormalizedSingleCase = new(
      new[] { "ABC", "ABC", "ACB", "AGHM", "AA" },
      new[] { "ABCGHM" }
   );
   
   public static readonly TestCase DenormalizedCase = new(
      new[] { "ABC", "ABC", "ACB", "AGHM", "AA", "GX", "GXX" },
      new[] { "ABCGHM", "GX" }
   );

   public static readonly TestCase SwingerCycleCase = new(
      new[] { "AB", "BC", "CD", "DE", "EA" },
      new[] { "ABCDE", "BACDE", "CABDE", "DABCE", "EABCD" }
   );
}
