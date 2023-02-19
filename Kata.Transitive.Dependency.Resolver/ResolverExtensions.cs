namespace Kata.Transitive.Dependency.Resolver;

public static class DependencyResolverExtensions
{
   /// <summary>
   /// Main entry point to resolve the dependencies, just a wrapper around the internal methods
   /// </summary>
   public static string[][] ResolveDependencies(this string[][] resolvableDependencies)
   {
      return resolvableDependencies
         .NormalizeInput()
         .CreateResolverContext()
         .ResolveDependencies()
         .FinalizeResults();
   }

   /// <summary>
   /// This method iterates over the dependant nodes until all of dependencies resolved for every dependantNode 
   /// </summary>
   internal static Dictionary<string, NodeDependencies> ResolveDependencies(
      this Dictionary<string, NodeDependencies> dependantNodes
   )
   {
      while (true)
      {
         var allResolved = dependantNodes.Values
            .Where(dependantNode => dependantNode.IsResolved is false)
            .All(dependantNode =>
               dependantNode.TryResolveTransitiveDependencies(dependantNodes)
            );

         if (allResolved)
            break;
      }

      return dependantNodes;
   }

   /// <summary>
   /// Lets try to resolve the transitive dependencies for the dependant node.
   /// </summary>
   internal static bool TryResolveTransitiveDependencies(
      this NodeDependencies dependantNode, Dictionary<string, NodeDependencies> dependantNodes
   )
   {
      return dependantNode.Dependencies.Keys
         .ToList()
         .All(dependency =>
            dependantNode.AddNewTransientDependencies(dependency, dependantNodes) is false
         );
   }

   /// <summary>
   /// It adds new transient dependencies to the dependant node if there is any.
   /// If there is no new transient dependencies, we can say that the dependant node is resolved. 
   /// </summary>
   internal static bool AddNewTransientDependencies(
      this NodeDependencies dependantNode, string dependency, Dictionary<string, NodeDependencies> dependantNodes
   )
   {
      return dependantNode.DetermineDependencyNode(dependency, dependantNodes)
         .Dependencies
         .Any(item => dependantNode.Dependencies.TryAdd(item.Key, item.Value));
   }

   internal static NodeDependencies IndependentNode(string dependency)
      => new(dependency, Array.Empty<string>()) { IsResolved = true };

   /// <summary>
   /// This method determines the dependency dependantNode for the single dependency.
   /// If we found the dependency in the dependant nodes, then it can be source of new transient dependencies 
   /// </summary>
   internal static NodeDependencies DetermineDependencyNode(
      this NodeDependencies node, string dependency, Dictionary<string, NodeDependencies> dependantNodes
   )
   {
      return dependantNodes.TryGetValue(dependency, out var dependantNode)
         ? node.Dependencies[dependency] = dependantNode
         : node.Dependencies[dependency] = IndependentNode(dependency);
   }
}
