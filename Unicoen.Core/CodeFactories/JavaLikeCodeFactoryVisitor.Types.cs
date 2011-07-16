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
using System.Linq;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.CodeFactories {
	public partial class JavaLikeCodeFactoryVisitor {
		public override bool Visit(UnifiedBasicType element, VisitorArgument arg) {
			element.BasicTypeName.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedConstType element, VisitorArgument arg) {
			Writer.Write("final ");
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedPointerType element, VisitorArgument arg) {
			Writer.Write("/* * */");
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedReferenceType element, VisitorArgument arg) {
			Writer.Write("/* & */");
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedVolatileType element, VisitorArgument arg) {
			Writer.Write("volatile ");
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedStructType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedUnionType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedGenericType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedArrayType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			Writer.Write("[");
			element.Arguments.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write("]");
			return false;
		}
	}
}