using System;
using System.Reflection;
using System.Runtime.Versioning;

namespace NpiRelay.Configuration
{
	/// <summary>
	///		General application information.
	/// </summary>
	public class ApplicationProperties
	{
		private const string ValueUnknown = "UNKNOWN";
		public static ApplicationProperties Instance { get; }

		public string AssemblyName { get; }
		public string BuildHash { get; }
		public string BuildDate { get; }
		public string Version { get; }
		public string Host { get; }

		public string TargetFrameWork { get; }


		private ApplicationProperties(string assembly, string version, string buildHash, string targetFrameWork, string machineName, string buildDate)
		{
			AssemblyName = assembly;
			BuildHash = buildHash;
			Version = version;
			Host = machineName;
			BuildDate = buildDate;
			TargetFrameWork = targetFrameWork;
		}

		private static ApplicationProperties EmptyProperties =>
			new ApplicationProperties(
				assembly: ValueUnknown,
				version: ValueUnknown,
				targetFrameWork: ValueUnknown,
				buildHash: null,
				buildDate: null,
				machineName: null
				);

		static ApplicationProperties()
		{
			Instance = InitializeAppProps();
		}

		private static ApplicationProperties InitializeAppProps()
		{
			try
			{
				var assembly = Assembly.GetEntryAssembly();
				var assemblyName = assembly.GetName();
				var assemblyDescription = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>();
				var infoVersion = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
				var buildHashDate = TryParseBuildHashAndDate(assemblyDescription?.Description);
				var targetFrameWork = assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

				return new ApplicationProperties(
					assembly: assemblyName.Name,
					version: infoVersion.InformationalVersion,
					targetFrameWork: targetFrameWork,
					buildHash: buildHashDate.Item1,
					buildDate: buildHashDate.Item2,
					machineName: TryGetMachineName()
				);
			}
			catch
			{
				return EmptyProperties;
			}
		}

		private static Tuple<string, string> TryParseBuildHashAndDate(string description)
		{
			// Format looks like abt4d924|18.01.2018 16:35:01

			if (string.IsNullOrEmpty(description) == false)
			{
				var parts = description.Split('|');
				if (parts.Length > 1)
				{
					return new Tuple<string, string>(parts[0], parts[1]);
				}
			}

			return new Tuple<string, string>(string.Empty, string.Empty);
		}

		private static string TryGetMachineName()
		{
			try
			{
				return Environment.MachineName;
			}
			catch
			{
				return ValueUnknown;
			}
		}
	}
}
