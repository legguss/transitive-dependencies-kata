namespace Kata.Transitive.Dependency.Resolver;

internal record DependencyNode(
   string Dependant,
   string[] DirectDependencies
)
{
   internal Dictionary<string, DependencyNode?> Dependencies { get; }
      = DirectDependencies
         .ToDictionary(
            dependency => dependency,
            dependency => dependency == Dependant
               ? new DependencyNode(dependency, Array.Empty<string>())
               : null
         );

   internal bool IsResolved { get; set; }
}

/// <summary>
/// Context of resolving dependencies
/// </summary>
/// <param name="NormalizedInput"></param>
internal record DependencyResolverContext(
   Dictionary<string, string[]> NormalizedInput
)
{
   internal Dictionary<string, DependencyNode> Output { get; }
      = NormalizedInput
         .ToDictionary(
            item => item.Key,
            item => new DependencyNode(item.Key, item.Value)
         );
}
