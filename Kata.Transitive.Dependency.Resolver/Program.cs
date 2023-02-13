using Kata.Transitive.Dependency.Resolver;

if (args.Length != 1)
{
   Console.WriteLine("Usage: resolver <filename>");
   Console.WriteLine("filename - path to the file containing the list of dependencies");
   Console.WriteLine("Example content: ");
   Console.WriteLine("A B C");
   Console.WriteLine("B X");
   Console.WriteLine("C Y");
   return;
}

var fileName = args.First();

if (!File.Exists(fileName))
{
   Console.WriteLine($"File {fileName} does not exist");
   return;
}

var result = File.ReadAllLines(fileName)
   .Select(line => line.Split(' '))
   .ToArray()
   .ResolveDependencies();

if (result.Any())
{
   Console
      .WriteLine("Resolved dependencies:");

   foreach (var item in result)
      Console.WriteLine(string.Join(' ', item));

   return;
}

Console.WriteLine("No dependencies found");
