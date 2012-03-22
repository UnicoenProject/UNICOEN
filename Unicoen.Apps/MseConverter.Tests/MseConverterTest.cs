#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.IO;
using NUnit.Framework;
using Unicoen.TestUtils;
using Unicoen.Tests;

namespace Unicoen.Apps.MseConverter.Tests {
    [TestFixture]
    public class MseConverterTest {
        [Test]
        public void CSharpから変換された共通オブジェクトをmseフォーマットに変換できる() {
            var dirPath = FixtureUtil.GetDownloadPath("java", "junit4.8.2");
            var writer = new StringWriter();
            var converter = new MseConverter(writer);
            converter.Generate(dirPath, writer);
            Console.Write(writer.ToString());
        }

        [Test]
        public void JavaScriptから変換された共通オブジェクトをmseフォーマットに変換できる() {
            var dirPath = FixtureUtil.GetDownloadPath(
                    "JavaScript", "Processing.js-1.2.3");
            var writer = new StringWriter();
            var converter = new MseConverter(writer);
            converter.Generate(dirPath, writer);
            Console.Write(writer.ToString());
        }

        [Test]
        public void Javaから変換された共通オブジェクトをmseフォーマットに変換できる() {
            var dirPath = FixtureUtil.GetDownloadPath("java", "junit4.8.2");
            var writer = new StringWriter();
            var converter = new MseConverter(writer);
            converter.Generate(dirPath, writer);
            Console.Write(writer.ToString());
        }

        [Test]
        public void Pythonから変換された共通オブジェクトをmseフォーマットに変換できる() {
            var dirPath = FixtureUtil.GetDownloadPath("Python2", "django-1.3");
            var writer = new StringWriter();
            var converter = new MseConverter(writer);
            converter.Generate(dirPath, writer);
            Console.Write(writer.ToString());
        }

        [Test]
        public void Tornadeをmseフォーマットに変換できる() {
            var dirPath = FixtureUtil.GetDownloadPath(
                    "Python2", "tornade-2.0.0");
            var writer = new StringWriter();
            var converter = new MseConverter(writer);
            converter.Generate(dirPath, writer);
            Console.Write(writer.ToString());
        }

        [Test]
        public void UNICOENをmseフォーマットに変換できる() {
            var dirPath = @"C:\output\1\UnicoenProject-UNICOEN-2cefbbb";
            var writer = new StringWriter();
            var converter = new MseConverter(writer);
            converter.Generate(dirPath, writer);
            Console.Write(writer.ToString());
        }
    }
}