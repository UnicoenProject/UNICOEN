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
using System.Collections.Generic;

namespace Unicoen.Apps.UniAspect.Cui.AspectElement {
    /// <summary>
    ///   ポイントカットを表します ポイントカットは以下の属性から構成されます
    /// </summary>
    public class Pointcut : IAspectElement {
        //ポイントカットの種類(execution or call)
        //ポイントカットのパラメータ
        private readonly List<Tuple<string, string>> _parameters =
                new List<Tuple<string, string>>();

        //ポイントカット条件における型
        //ポイントカット条件におけるターゲット名
        private readonly List<string> _target = new List<string>();
        private string _currentParameterType;
        private string _name;
        private string _pointcutType;
        private string _type;

        //ポイントカットの種類を指定します

        #region IAspectElement Members

        public void SetElementType(string elementType) {
            _pointcutType = elementType;
        }

        //ポイントカットの名前を指定します
        public void SetName(string name) {
            _name = name;
        }

        //直前のパラメータの型を一時保存します
        public void SetParameterType(string paramType) {
            _currentParameterType = paramType;
        }

        //ポイントカットのパラメータを指定します
        public void SetParameter(string param) {
            _parameters.Add(Tuple.Create(_currentParameterType, param));
        }

        //ポイントカット条件における型を指定します
        public void SetType(string type) {
            _type = type;
        }

        //ポイントカット条件におけるターゲットを指定します
        public void SetTarget(string target) {
            _target.Add(target);
        }

        public string GetProperty() {
            var property = "pointcut type: " + _pointcutType + "\n";
            property += "name: " + _name + "\n";
            property += "parameters: ";
            var splitter = " ";
            foreach (var parameter in _parameters) {
                property += splitter + parameter.Item1 + " " + parameter.Item2;
                splitter = ",";
            }
            property += "\n";
            property += "type: " + _type + "\n";
            splitter = "target: ";
            foreach (var identifier in _target) {
                property += splitter + identifier;
                splitter = ".";
            }
            property += "\n";

            return property;
        }

        #endregion

        #region Un-use Method

        public void SetLanguageType(string language) {
            throw new InvalidOperationException();
        }

        public void SetContents(string content) {
            throw new InvalidOperationException();
        }

        #endregion

        public string GetPointcutType() {
            return _pointcutType;
        }

        public string GetName() {
            return _name;
        }

        public List<Tuple<string, string>> GetParameters() {
            return _parameters;
        }

        public string GetTargetType() {
            return _type;
        }

        public List<string> GetTargetName() {
            return _target;
        }
    }
}