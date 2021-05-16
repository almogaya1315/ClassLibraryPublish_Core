using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ClassLibraryPublish_Core
{
    public class Publish
    {
        public static void Pack<T>()
        {
            var settings = Settings.Default;
            var lib = Assembly.GetAssembly(typeof(T));
            var nugetApiKey = settings.NugetApiKey; 

            var libName = lib.GetName();
            var packagePath = libName.CodeBase; //@"D:\Development\SquadModels\bin\Release\netstandard2.0\publish";
            var source = settings.NugetUrl;

            var cmdCommand = $@"dotnet nuget push {packagePath} --api-key {nugetApiKey} --source {source}";
            //$@"dotnet nuget push {packagePath}\SquadModels.{libName.Version.ToString(3)}.nupkg --api-key {nugetApiKey} --source {source}";
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            process.StandardInput.WriteLine(cmdCommand);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());

            Console.ReadKey();
        }
    }
}
