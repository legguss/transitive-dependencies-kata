namespace Kata.Transitive.Dependency.Resolver;

/// <summary>
/// Misc helper extension methods not related to the main logic
/// </summary>
internal static class HelperExtensions
{
   /// <summary>
   /// Just a method to pack the results
   /// </summary>
   /// <param name="node"></param>
   /// <returns></returns>
   internal static string[] AsStringArray(this NodeDependencies node)
   {
      return new[] { node.Dependant }
         .Concat(node.Dependencies.Keys
            .Where(item => item != node.Dependant)
            .OrderBy(item => item))
         .ToArray();
   }

   internal static string[][] FinalizeResults(this Dictionary<string, NodeDependencies> context)
   {
      return context
         .OrderBy(node => node.Key)
         .Select(node => node.Value.AsStringArray())
         .ToArray();
   }

   internal static Dictionary<string, NodeDependencies> CreateResolverContext(this Dictionary<string, string[]> normalizedInput)
   {
      return normalizedInput
         .Select(
            node => new NodeDependencies(
               node.Key,
               node.Value
            )
         )
         .ToDictionary(
            node => node.Dependant,
            node => node
         );
   }
}
