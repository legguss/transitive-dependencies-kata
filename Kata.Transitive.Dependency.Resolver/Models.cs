namespace Kata.Transitive.Dependency.Resolver;

internal record NodeDependencies(
   string Dependant,
   string[] DirectDependencies
)
{
   internal Dictionary<string, NodeDependencies?> Dependencies { get; }
      = DirectDependencies
         .ToDictionary(
            dependency => dependency,
            dependency => dependency == Dependant
               ? new NodeDependencies(dependency, Array.Empty<string>())
               : null
         );

   internal bool IsResolved { get; set; }
}
