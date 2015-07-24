using SandwichShop.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SandwichShop.MetroUI
{
    public class AssemblyLoader
    {
        public static List<Type> LoadFromAssembly(string assemblyPath)
        {
            var listOfTypes = new List<Type>();

            if (!Directory.Exists(assemblyPath))
                return listOfTypes;

            IEnumerable<string> assemblyFiles = Directory.EnumerateFiles(
                assemblyPath, "*.dll", SearchOption.TopDirectoryOnly);

            foreach (string assemblyFile in assemblyFiles)
            {
                Assembly assembly = Assembly.LoadFrom(assemblyFile);
                foreach (Type type in assembly.ExportedTypes)
                {
                    if (type.IsClass && typeof(Sandwich).IsAssignableFrom(type))
                    {
                        listOfTypes.Add(type);
                    }
                }
            }

            return listOfTypes;
        }

    }
}
