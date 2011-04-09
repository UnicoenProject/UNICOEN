using System;
using System.Collections.Generic;

namespace Ucpf.Applications.Metrics.Utils
{
	public static class TagProcessor
	{
		public static SortedSet<string> HierarchizeTags(IEnumerable<string> tagSet)
		{
			var newTagSet = new SortedSet<string>();
			foreach (var tag in tagSet) {
				HierarchizeTag(tag, newTagSet);
			}
			return newTagSet;
		}

		public static void HierarchizeTag(string tag, ISet<string> newTagSet)
		{
			var tagElements = tag.Split(new[] { "::" },
				StringSplitOptions.RemoveEmptyEntries);
			var newTag = string.Empty;
			foreach (var tagEelment in tagElements) {
				newTag += tagEelment + "::";
				newTagSet.Add(newTag);
			}
		}
	}
}