namespace Kata.Transitive.Dependency.Resolver;

/// <summary>
/// Methods to normalize and sanitize the input data
/// </summary>
public static class NormalizerExtensions
{
   internal static string[] GetNormalizedDependencies(
      this IEnumerable<string[]> dependencies, string dependant
   )
   {
      return dependencies.SelectMany(node => node)
         .Where(dependency => dependant != dependency)
         .Distinct()
         .ToArray();
   }

   internal static bool IsDependOn(this string dependant, string dependency)
   {
      return dependency is not "" && dependency != dependant;
   }

   internal static bool IsNodeWithDependencies(this string[] node)
   {
      return node.Length > 1
             && node.Any(
                dependency =>
                   node.First().IsDependOn(dependency)
             );
   }

   /// <summary>
   /// Returns a dictionary of normalized node dependencies.
   /// Removes empty nodes, nodes with only one element, and nodes with self-dependencies.
   /// Deduplicates the dependencies.
   /// </summary> 
   internal static Dictionary<string, string[]> NormalizeInput(
      this string[][] input
   )
   {
      return input
         .Where(node => node.IsNodeWithDependencies())
         .GroupBy(node => node.First())
         .ToDictionary(
            nodes => nodes.Key,
            nodes => nodes.GetNormalizedDependencies(nodes.Key)
         );
   }
}
