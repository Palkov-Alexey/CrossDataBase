using System.Reflection;

namespace CrossDataBase.Server.Infrastructure.DependencyInjection
{
    internal static class AssemblyExtensions
    {
        private static readonly string dirSeparator = Path.DirectorySeparatorChar.ToString();

        internal static Assembly[] GetAssemblyByPattern(string appDomainAppPath, string searchPattern)
        {
            var nameList = GetAssemblyNameListByPattern(appDomainAppPath, searchPattern);
            var assemblyList = GetAssemblyByName(nameList);

            return assemblyList;
        }

        internal static Assembly[] GetAssemblyByName(IReadOnlyCollection<string> assemblyNameList)
        {
            return assemblyNameList.Select(Assembly.Load).ToArray();
        }

        internal static string[] GetAssemblyNameListByPattern(string appDomainAppPath, string searchPattern)
        {
            var assemblyList = Directory
                .GetFiles(appDomainAppPath, $@"{searchPattern}.dll", SearchOption.TopDirectoryOnly)
                .Select(f =>
                    f.Replace(appDomainAppPath, string.Empty)
                     .Replace(".dll", string.Empty)
                     .Replace(dirSeparator, string.Empty))
                .ToArray();

            return assemblyList;
        }
    }
}