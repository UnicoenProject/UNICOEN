using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Apps.RefactoringDSL.Java;
using Unicoen.Apps.RefactoringDSL.Util;
using Unicoen.Languages.Java;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.Tests {
	public class EncapsulateCollectionHelperTest : EncapsulateCollectionTest{
		[Test]
		public void TestForGenerateRemoveMethod() {
			var list = FindUtil.FindGenericsField(_model, "List").First();
			var removingProcedure = EncapsulateCollectionHelperForJava.GenerateRemovingProcedureForList((UnifiedVariableDefinition)list);
			var removeMethod = EncapsulateCollectionHelper.GenerateRemoveMethod(list, "removeItem", removingProcedure);
			
			Console.WriteLine(JavaFactory.GenerateCode(removeMethod));
		}



		[Test]
		public void TestForGenerateAddMethod() {
			var list = FindUtil.FindGenericsField(_model, "List").First();
			var addingProcedure = EncapsulateCollectionHelperForJava.GenerateAddingProcedureForList((UnifiedVariableDefinition)list);
			var addMethod = EncapsulateCollectionHelper.GenerateAddMethod(list, "addItem", addingProcedure);
			
			Console.WriteLine(JavaFactory.GenerateCode(addMethod));
			
			
		}

		
		[Test]
		public void TestForGenerateClonedField() {
			var variable = _model.Descendants<UnifiedVariableDefinition>().First();
			var cloned = EncapsulateCollectionHelper.GenerateClonedField(variable, "clone");
			var code = JavaFactory.GenerateCode(cloned);
			Console.WriteLine(code);

		}

		[Test]
		public void TestForGenerateClonedFieldGetter() {
			var variable = _model.Descendants<UnifiedVariableDefinition>().First();
			var getter = EncapsulateCollectionHelper.GenerateClonedFieldGetter(variable);
			var code = JavaFactory.GenerateCode(getter);
			Console.WriteLine(code);

		}

		// @TODO 下は本当は FindUtil のテスト．
		[Test]
		public void TestForSearchArrayField() {
			var className = "Foo";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();

			Console.WriteLine(FindUtil.FindArrayField(targetClass).Count());
		}

		[Test]
		public void TestForGetTypeParameterAsType() {
			var className = "Bar";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();
			var genericField = FindUtil.FindGenericsField(targetClass, "List", "*").First();

			var type = FindUtil.GetTypeParameterAsType(
					(UnifiedGenericType)((UnifiedVariableDefinition)genericField).Type);

			Assert.That((type.BasicTypeName as UnifiedIdentifier).Name, Is.EqualTo("Integer"));		
			// Console.WriteLine((type.BasicTypeName as UnifiedIdentifier).Name);
		}

		[Test]
		public void TestForSearchGenericsField() {
			var className = "Bar";
			var targetClass = FindUtil.FindClassByClassName(_model, className).First();
			var genericFields = FindUtil.FindGenericsField(targetClass, "List", "*");

			Assert.That(genericFields.Count(), Is.EqualTo(1));

			/*
			Console.WriteLine(((UnifiedVariableIdentifier)(genericFields.First().Descendants<UnifiedGenericType>().First().Type.BasicTypeName)).Name); // => List
			foreach(var arg in (genericFields.First().Descendants<UnifiedGenericType>().First().Arguments)) {
				var typeString = arg.Descendants<UnifiedIdentifier>().First().Name;
				Console.WriteLine(typeString);
			}// => Integer 
			 * */
		}
	}
}
