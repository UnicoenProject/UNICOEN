using System.Collections.Generic;
using System.IO;
using Paraiba.Core;

namespace Code2Xml
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string parserName = null;
			string outputPath = null;
			var outputType = OutputType.DefaultStream;
			var isCodeGeneration = false;
			var filePaths = new List<string>();
			for (int i = 0; i < args.Length; i++) {
				var arg = args[i].ToLower();
				if (arg == "-d") {
					outputType = OutputType.Directory;
					outputPath = args.AtOrDefault(i + 1);
					if (Directory.Exists(outputPath)) {
						i++;
					}
					else {
						outputPath = null;
					}
				}
				else if (arg == "-f") {
					outputType = OutputType.File;
					outputPath = args.AtOrDefault(i + 1);
					i++;
				}
				else if (arg == "-code") {
					isCodeGeneration = true;
				}
				else if (arg.StartsWith("-")) {
					parserName = parserName ?? arg.Substring(1);
				}
				else {
					filePaths.Add(arg);
				}
			}

			if (!isCodeGeneration) {
				Parser.ParseCodeToXml(filePaths, parserName, outputType, outputPath);
			}
			else {
				Parser.ParseXmlToCode(filePaths, parserName, outputType, outputPath);
			}
		}
	}
}

