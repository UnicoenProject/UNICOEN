﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;


namespace Unicoen.Apps.Loc.Util
{
    public class DifferentialLoc
    {
        // measure differential between two files
        public static DiffCounter Count(string originalFile, string modifiedFile)
        {
            string original = File.ReadAllText(@originalFile);
            string modified = File.ReadAllText(@modifiedFile);
            
            var d = new Differ();
            var counter = new DiffCounter();
            var side = new SideBySideDiffBuilder(d);
            var result = side.BuildDiffModel(original, modified);

            // added, modified, and unmodified at modified file
            foreach (var line in result.NewText.Lines)
            {
                if (line.Type == ChangeType.Inserted)  counter.AddedCount++;
                if (line.Type == ChangeType.Modified)  counter.ModifiedCount++;
                if (line.Type == ChangeType.Unchanged) counter.EqualCount++;
            }

            // deleted from original file
            foreach (var line in result.OldText.Lines)
            {
                if (line.Type == ChangeType.Deleted)   counter.DeletedCount++;
            }

            return counter;
        }
    }
}
