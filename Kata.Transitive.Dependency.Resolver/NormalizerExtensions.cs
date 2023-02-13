namespace Kata.Transitive.Dependency.Resolver;

/// <summary>
/// Methods to normalize and sanitize the input data
/// </summary>
public static class NormalizerExtensions
{
   internal static string[] NormalizeNode(
      this ( string dependant, IEnumerable<string[]> dempendecies) source
   )
   {
      return source.dempendecies.SelectMany(node => node)
         .Where(dependency => source.dependant != dependency)
         .Distinct()
         .ToArray();
   }

   internal static Dictionary<string, string[]> NormalizeDependencies(
      this string[][] dependencies
   )
   {
      return dependencies
         .Where(node => node.Length > 1)
         .GroupBy(node => node.First())
         .Select(
            group =>
               (Dependant: group.Key, Dependencies: (group.Key, group)
                  .NormalizeNode())
         )
         .Where(item => item.Dependencies.Any())
         .ToDictionary(
            item => item.Dependant,
            item => item.Dependencies
         );
   }
}
