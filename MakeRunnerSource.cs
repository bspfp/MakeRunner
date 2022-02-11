using System;
using System.Diagnostics;
using System.Reflection;

[assembly: AssemblyTitle("MakeRunner GitHub")]
[assembly: AssemblyDescription("여기를 열기")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("BSPFP")]
[assembly: AssemblyProduct("MakeRunner")]
[assembly: AssemblyCopyright("BSPFP 2022")]
[assembly: AssemblyTrademark("BSPFP")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

static class Runner {
	static string appArgs;
	
	static void Main() {
		InitAppArgs();
		
		// var psi = RunShellCommand("https://github.com/bspfp/MakeRunner", "Open");
		// var psi = RunGUIApp("notepad.exe", bypass: true);
		// var psi = RunConsoleApp("\"D:\\RunSome.cmd\"", noWindow: true);
		var psi = RunConsoleApp("dir", keepConsole: true, bypass: true);
		
		// psi.WorkingDirectory = "<시작 폴더>";
		Process.Start(psi);
	}
	
	static ProcessStartInfo RunShellCommand(string filename, string verb = "Open") {
		return new ProcessStartInfo() {
			FileName = filename,
			UseShellExecute = true,
			Verb = verb,
		};
	}
	
	static ProcessStartInfo RunGUIApp(string filename, string arguments = "", bool bypass = false) {
		return new ProcessStartInfo() {
			FileName = filename,
			Arguments = arguments + (bypass ? appArgs : ""),
			UseShellExecute = false,
		};
	}
	
	static ProcessStartInfo RunConsoleApp(string filename, string arguments = "", bool bypass = false, bool keepConsole = false, bool noWindow = false) {
		var cmdOpt = keepConsole ? "/K" : "/C";
		return new ProcessStartInfo() {
			FileName = "cmd.exe",
			Arguments = cmdOpt + " " + filename + " " + arguments + (bypass ? appArgs : ""),
			UseShellExecute = false,
			CreateNoWindow = !keepConsole && noWindow
		};
	}
	
	static void InitAppArgs() {
		appArgs = Environment.CommandLine;
		var startIndex = -1;
		if (appArgs.StartsWith("\"")) {
			var endName = appArgs.Substring(1).IndexOf('"');
			if (endName != -1)
				startIndex = endName + 2;
		}
		else {
			for (var i = 1; i < appArgs.Length; i++) {
				if (char.IsWhiteSpace(appArgs[i])) {
					startIndex = i;
					break;
				}
			}
		}
		if (startIndex != -1)
			appArgs = appArgs.Substring(startIndex);
		else
			appArgs = "";
	}
}
