using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ucpf.Applications.Cyclomatic {
	public class Program {
		static void Main(string[] args) {
			foreach (var arg in args) {
				// do a given path indicate directory?
				if (Directory.Exists(arg)) {
					// find .rb files from a given directory path
					//foreach (var path in Directory.GetFiles(arg, "*.rb", SearchOption.AllDirectories)) {
					//    PrintCyclomatic(path);
					//}
				}
				// or do a given path indicate file?
				else if (File.Exists(arg)) {
					// not check the extension
					PrintCyclomatic(arg);
				}
			}
		}

		/// <summary>
		/// Print cyclomatic of give file
		/// </summary>
		/// <param name="filePath">a target file path</param>
		private static void PrintCyclomatic(string filePath) {
			Console.WriteLine("**** Measuring cyclomatic of " + filePath + " ****");

			var result = Cyclomatic.Measure(filePath);

			var tagSet = result.Keys;
			var newTagSet = new SortedSet<string>();

			foreach (var tag in tagSet) {
				HierarchizeTag(tag, newTagSet);
			}

			Console.WriteLine("Cyclomatic");
			Console.WriteLine(filePath);
			foreach (var tag in newTagSet) {
				var count = result.Where(p => p.Key.StartsWith(tag))
					.Aggregate(1, (s, p) => s + p.Value);
				Console.WriteLine(tag + " " + count);
			}
		}

		private static void HierarchizeTag(string tag, ISet<string> newTagSet) {
			var tagElements = tag.Split(new[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
			var newTag = string.Empty;
			foreach (var tagEelment in tagElements) {
				newTag += tagEelment + "::";
				newTagSet.Add(newTag);
			}
		}
	}
}
