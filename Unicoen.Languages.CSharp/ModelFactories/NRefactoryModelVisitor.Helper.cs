using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using Unicoen.Core.Model;

namespace Unicoen.Languages.CSharp.ModelFactories {

	partial class NRefactoryModelVisitor {

		#region Lookups

		private static UnifiedClassKind LookupClassKind(ClassType type) {
			switch (type) {
			case ClassType.Class:
				return UnifiedClassKind.Class;
			case ClassType.Struct:
				return UnifiedClassKind.Struct;
			case ClassType.Interface:
				return UnifiedClassKind.Interface;
			}
			throw new InvalidOperationException(type + "には対応していません。");
		}

		private static UnifiedModifierCollection LookupModifier(Modifiers mods) {
			Contract.Ensures(Contract.Result<UnifiedModifierCollection>() != null);

			var pairs = new[] {
					new { Mod = Modifiers.Public, Name = "public" },
					new { Mod = Modifiers.Protected, Name = "protected" },
					new { Mod = Modifiers.Internal, Name = "internal" },
					new { Mod = Modifiers.Abstract, Name = "abstract" },
					new { Mod = Modifiers.Private, Name = "private" },

					new { Mod = Modifiers.Partial, Name = "partial" },
					new { Mod = Modifiers.Static, Name = "static" },
					new { Mod = Modifiers.Sealed, Name = "sealed" },
					new { Mod = Modifiers.Const, Name = "const" },
					new { Mod = Modifiers.Readonly, Name = "readonly" },

					new { Mod = Modifiers.New, Name = "new" },
					new { Mod = Modifiers.Override, Name = "override" },
					new { Mod = Modifiers.Virtual, Name = "virtual" },

					new { Mod = Modifiers.Extern, Name = "extern" },
					new { Mod = Modifiers.Fixed, Name = "fixed" },
					new { Mod = Modifiers.Unsafe, Name = "unsafe" },
					new { Mod = Modifiers.Volatile, Name = "volatile" },
			};
			var uMods =
					from pair in pairs
					where (mods & pair.Mod) != 0
					select UnifiedModifier.Create(pair.Name);
			return UnifiedModifierCollection.Create(uMods);
		}

		private static UnifiedType LookupType(AstType type) {
			Contract.Requires<ArgumentNullException>(type != null);
			Contract.Ensures(Contract.Result<UnifiedType>() != null);

			var prim = type as PrimitiveType;
			if (prim != null) {
				return UnifiedType.CreateUsingString(prim.Keyword);
			}

			throw new NotImplementedException("MethodDeclaration");
		}

		#endregion

	}
}
