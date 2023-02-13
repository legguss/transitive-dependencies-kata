namespace Kata.Transitive.Dependency.Resolver;

public static class DependencyResolverExtensions
{
   internal static bool ResolveDependencies(
      this DependencyResolverContext context, DependencyNode node
   )
   {
      return node.IsResolved
             || node.Dependencies.Keys
                .ToList()
                .All(dependency =>
                   context.UpdateDependencyNodes(node, dependency
                   )
                );
   }

   internal static bool UpdateDependencyNodes(
      this DependencyResolverContext context, DependencyNode node, string dependency)
   {
      return !context.DetermineDependencyNode(node, dependency)
         .Dependencies
         .Any(item => node.Dependencies.TryAdd(item.Key, item.Value));
   }

   internal static DependencyNode DetermineDependencyNode(
      this DependencyResolverContext context, DependencyNode node, string dependency
   )
   {
      return context.Output.TryGetValue(dependency, out var subGroup)
         ? node.Dependencies[dependency] = subGroup
         : node.Dependencies[dependency] =
            new(dependency, Array.Empty<string>()) { IsResolved = true };
   }

   /// <summary>
   /// Main entry point to resolve the dependencies
   /// </summary>
   public static string[][] ResolveDependencies(this string[][] input)
   {
      var context = new DependencyResolverContext(
         input.NormalizeDependencies()
      );

      while (true)
      {
         if (context.Output.Values.All(node => context.ResolveDependencies(node)))
            break;
      }

      return context.FinalizeResults();
   }
}
