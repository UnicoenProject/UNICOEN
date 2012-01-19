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

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
    /// <summary>
    ///   新しい名前区間を作成し得る要素の種類を列挙します
    /// </summary>
    public enum NamespaceType {
        Package,
        Class,
        Function,
        Variable,
        TemporaryScope,
    }
}