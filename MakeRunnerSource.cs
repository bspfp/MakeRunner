using System;
using System.Diagnostics;
using System.Reflection;

[assembly: AssemblyTitle("개인 오피스")]
[assembly: AssemblyDescription("개인 오피스 웹페이지 열기")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("BSPFP")]
[assembly: AssemblyProduct("개인 오피스")]
[assembly: AssemblyCopyright("BSPFP 2022")]
[assembly: AssemblyTrademark("BSPFP")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

static class Runner {
	static void Main() {
		var psi = RunShellCommand("https://bspfp.pe.kr", "Open");
		// var psi = RunGUIApp("notepad.exe", "");
		// var psi = RunConsoleApp("netstat.exe", "-anp tcp", true);
		// var psi = RunConsoleApp("dir");
		
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
	
	static ProcessStartInfo RunGUIApp(string filename, string arguments = "") {
		return new ProcessStartInfo() {
			FileName = filename,
			Arguments = arguments,
			UseShellExecute = false,
		};
	}
	
	static ProcessStartInfo RunConsoleApp(string filename, string arguments = "", bool keepConsole = false) {
		var cmdOpt = keepConsole ? "/K" : "/C";
		return new ProcessStartInfo() {
			FileName = "cmd.exe",
			Arguments = cmdOpt + " " + filename + " " + arguments,
			UseShellExecute = false,
		};
	}
}
