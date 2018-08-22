using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using Unity.RegistrationByConvention;

namespace Unity.RegistrationByConvention
{
    public class PKIAllClasses
    {

        private static readonly string NetFrameworkProductName = GetNetFrameworkProductName();
        private static readonly string UnityProductName = GetUnityProductName();

        private static string GetNetFrameworkProductName()
        {
            var productAttribute = typeof(object).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyProductAttribute>();
            return productAttribute?.Product;
        }

        private static string GetUnityProductName()
        {
            var productAttribute = typeof(AllClasses).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyProductAttribute>();
            return productAttribute?.Product;
        }

        private static IEnumerable<Type> FromCheckedAssemblies(IEnumerable<Assembly> assemblies, bool skipOnError)
        {
            var result = assemblies
                    .SelectMany(a =>
                    {
                        IEnumerable<TypeInfo> types;

                        try
                        {
                            types = a.DefinedTypes;
                        }
                        catch (ReflectionTypeLoadException e)
                        {
                            if (!skipOnError)
                            {
                                throw;
                            }

                            types = e.Types.TakeWhile(t => t != null).Select(t => t.GetTypeInfo());
                        }

                        return types.Where(ti => ti.IsClass & !ti.IsAbstract && !ti.IsValueType && ti.IsVisible).Select(ti => ti.AsType());
                    });
            return result;
        }

        /// <summary>
        /// Returns all visible, non-abstract classes from all assemblies that are located in the base folder of the current application domain.
        /// </summary>
        /// <param name="includeSystemAssemblies"><see langword="false" /> to include system assemblies; otherwise, <see langword="false" />. Defaults to <see langword="false" />.</param>
        /// <param name="includeUnityAssemblies"><see langword="false" /> to include the Unity assemblies; otherwise, <see langword="false" />. Defaults to <see langword="false" />.</param>
        /// <param name="skipOnError"><see langword="true"/> to skip errors; otherwise, <see langword="true"/>.</param>
        /// <returns>
        /// All visible, non-abstract classes.
        /// </returns>
        /// <remarks>
        /// If <paramref name="skipOnError" /> is <see langword="true" />, all exceptions thrown while loading assemblies or getting types from the assemblies are ignored, and the types
        /// that can be retrieved are returned; otherwise, the original exception is thrown.
        /// </remarks>
        public static IEnumerable<Type> FromAssembliesInBasePath(bool includeSystemAssemblies = false, bool includeUnityAssemblies = false, bool skipOnError = true)
        {
            return FromCheckedAssemblies(GetAssembliesInBasePath(includeSystemAssemblies, includeUnityAssemblies, skipOnError), skipOnError);
        }

        private static IEnumerable<Assembly> GetAssembliesInBasePath(bool includeSystemAssemblies, bool includeUnityAssemblies, bool skipOnError)
        {
            string basePath;

            try
            {
                basePath = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            }
            catch (SecurityException)
            {
                if (!skipOnError)
                {
                    throw;
                }

                return new Assembly[0];
            }

            var result = GetAssemblyNames(basePath, skipOnError)
                    .Select(an => LoadAssembly(Path.GetFileNameWithoutExtension(an), skipOnError))
                    .Where(a => a != null && (includeSystemAssemblies || !IsSystemAssembly(a)) && (includeUnityAssemblies || !IsUnityAssembly(a)));
            return result;
        }

        private static IEnumerable<string> GetAssemblyNames(string path, bool skipOnError)
        {
            try
            {
                return Directory.EnumerateFiles(path, "*.dll").Concat(Directory.EnumerateFiles(path, "*.exe"));
            }
            catch (Exception e)
            {
                if (!(skipOnError && (e is DirectoryNotFoundException || e is IOException || e is SecurityException || e is UnauthorizedAccessException)))
                {
                    throw;
                }

                return new string[0];
            }
        }

        private static bool IsUnityAssembly(Assembly a)
        {
            if (UnityProductName == null) return false;
            var productAttribute = a.GetCustomAttribute<AssemblyProductAttribute>();
            return productAttribute != null && string.Compare(UnityProductName, productAttribute.Product, StringComparison.Ordinal) == 0;
        }


        private static Assembly LoadAssembly(string assemblyName, bool skipOnError)
        {
            try
            {
                return Assembly.Load(assemblyName);
            }
            catch (Exception e)
            {
                if (!(skipOnError && (e is FileNotFoundException || e is FileLoadException || e is BadImageFormatException)))
                {
                    throw;
                }

                return null;
            }
        }

        private static IEnumerable<Assembly> GetLoadedAssemblies(bool includeSystemAssemblies, bool includeUnityAssemblies, bool includeDynamicAssemblies)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            if (includeSystemAssemblies && includeDynamicAssemblies)
            {
                return assemblies;
            }

            return assemblies.Where(a => (includeDynamicAssemblies || !a.IsDynamic) && (includeSystemAssemblies || !IsSystemAssembly(a)) && (includeUnityAssemblies || !IsUnityAssembly(a)));
        }

        private static bool IsSystemAssembly(Assembly a)
        {
            if (NetFrameworkProductName != null)
            {
                var productAttribute = a.GetCustomAttribute<AssemblyProductAttribute>();
                return productAttribute != null && string.Compare(NetFrameworkProductName, productAttribute.Product, StringComparison.Ordinal) == 0;
            }
            return false;
        }
    }
}