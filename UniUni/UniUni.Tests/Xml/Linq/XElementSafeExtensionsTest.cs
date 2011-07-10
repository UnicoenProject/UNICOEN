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

using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using UniUni.Xml.Linq;

namespace UniUni.Tests.Xml.Linq {
	[TestFixture]
	public class XElementSafeExtensionsTest {
		private static readonly XElement NullElement;
		private static readonly XElement Root;
		private static readonly XElement A1Element;
		private static readonly XElement A2Element;
		private static readonly XElement B1Element;
		private static readonly XElement C1Element;
		private static readonly XElement D1Element;

		static XElementSafeExtensionsTest() {
			Root = new XElement("e");
			A1Element = new XElement("a") { Value = "a1" };
			A2Element = new XElement("a") { Value = "a2" };
			B1Element = new XElement("b") { Value = "b1" };
			C1Element = new XElement("c") { Value = "c1" };
			D1Element = new XElement("d") { Value = "d1" };
			B1Element.Add(C1Element);
			Root.Add(A1Element, A2Element, B1Element, D1Element);
		}

		[Test]
		public void SafeContainsForNull() {
			NullElement.SafeHasElement("b").Is(false);
		}

		[Test]
		[TestCase("a", Result = true)]
		[TestCase("c", Result = false)]
		public bool SafeContainsForNotNull(string name) {
			return Root.SafeHasElement(name);
		}

		[Test]
		public void SafeElementForNull() {
			NullElement.SafeElement("a").Is((XElement)null);
		}

		[Test]
		[TestCase("a", Result = "a1")]
		[TestCase("c", Result = null)]
		public string SafeElementForNotNull(string name) {
			return Root.SafeElement(name).SafeValue();
		}

		[Test]
		public void SafeElementsForNull() {
			NullElement.SafeElements().Count().Is(0);
		}

		[Test]
		public void SafeElementsForNotNull() {
			Root.SafeElements().Count().Is(4);
		}

		[Test]
		public void SafeElementsForNullWithName() {
			NullElement.SafeElements("a").Count().Is(0);
		}

		[Test]
		[TestCase("a", Result = 2)]
		[TestCase("c", Result = 0)]
		public int SafeElementsForNotNullWithName(string name) {
			return Root.SafeElements(name).Count();
		}

		[Test]
		public void SafeElementsAfterSelfForNull() {
			NullElement.SafeElementsAfterSelf().Count().Is(0);
		}

		[Test]
		public void SafeElementsAfterSelfForNotNull() {
			A1Element.SafeElementsAfterSelf().Count().Is(3);
		}

		[Test]
		public void SafeElementsAfterSelfForNullWithName() {
			NullElement.SafeElementsAfterSelf("a").Count().Is(0);
		}

		[Test]
		[TestCase("a", Result = 1)]
		[TestCase("b", Result = 1)]
		[TestCase("c", Result = 0)]
		public int SafeElementsAfterSelfForNotNullWithName(string name) {
			return A1Element.SafeElementsAfterSelf(name).Count();
		}

		[Test]
		public void SafeElementsBeforeSelfForNull() {
			NullElement.SafeElementsBeforeSelf().Count().Is(0);
		}

		[Test]
		public void SafeElementsBeforeSelfForNotNull() {
			A2Element.SafeElementsBeforeSelf().Count().Is(1);
		}

		[Test]
		public void SafeElementsBeforeSelfForNullWithName() {
			NullElement.SafeElementsBeforeSelf("a").Count().Is(0);
		}

		[Test]
		[TestCase("a", Result = 2)]
		[TestCase("b", Result = 0)]
		[TestCase("c", Result = 0)]
		public int SafeElementsBeforeSelfForNotNullWithName(string name) {
			return B1Element.SafeElementsBeforeSelf(name).Count();
		}

		[Test]
		public void SafeDescendantsForNull() {
			NullElement.SafeDescendants().Count().Is(0);
		}

		[Test]
		public void SafeDescendantsForNotNull() {
			Root.SafeDescendants().Count().Is(5);
		}

		[Test]
		public void SafeDescendantsForNullWithName() {
			NullElement.SafeDescendants("c").Count().Is(0);
		}

		[Test]
		[TestCase("a", Result = 2)]
		[TestCase("b", Result = 1)]
		[TestCase("c", Result = 1)]
		public int SafeDescendantsForNotNullWithName(string name) {
			return Root.SafeDescendants(name).Count();
		}

		[Test]
		public void SafeDescendantsAndSelfForNull() {
			NullElement.SafeDescendantsAndSelf().Count().Is(0);
		}

		[Test]
		public void SafeDescendantsAndSelfForNotNull() {
			Root.SafeDescendantsAndSelf().Count().Is(6);
		}

		[Test]
		public void SafeDescendantsAndSelfForNullWithName() {
			NullElement.SafeDescendantsAndSelf("c").Count().Is(0);
		}

		[Test]
		[TestCase("a", Result = 2)]
		[TestCase("b", Result = 1)]
		[TestCase("c", Result = 1)]
		[TestCase("e", Result = 1)]
		public int SafeDescendantsAndSelfForNotNullWithName(string name) {
			return Root.SafeDescendantsAndSelf(name).Count();
		}

		[Test]
		public void SafeAncestorsForNull() {
			NullElement.SafeAncestors().Count().Is(0);
		}

		[Test]
		public void SafeAncestorsForNotNull() {
			C1Element.SafeAncestors().Count().Is(2);
			C1Element.SafeAncestors().ElementAt(0).Name.Is("b");
			C1Element.SafeAncestors().ElementAt(1).Name.Is("e");
		}

		[Test]
		public void SafeAncestorsForNullWithName() {
			NullElement.SafeAncestors("c").Count().Is(0);
		}

		[Test]
		[TestCase("a", Result = 0)]
		[TestCase("b", Result = 1)]
		[TestCase("c", Result = 0)]
		[TestCase("e", Result = 1)]
		public int SafeAncestorsForNotNullWithName(string name) {
			return C1Element.SafeAncestors(name).Count();
		}

		[Test]
		public void SafeAncestorsAndSelfForNull() {
			NullElement.SafeAncestorsAndSelf().Count().Is(0);
		}

		[Test]
		public void SafeAncestorsAndSelfForNotNull() {
			C1Element.SafeAncestorsAndSelf().Count().Is(3);
		}

		[Test]
		public void SafeAncestorsAndSelfForNullWithName() {
			NullElement.SafeAncestorsAndSelf("c").Count().Is(0);
		}

		[Test]
		[TestCase("a", Result = 0)]
		[TestCase("b", Result = 1)]
		[TestCase("c", Result = 1)]
		[TestCase("e", Result = 1)]
		public int SafeAncestorsAndSelfForNotNullWithName(string name) {
			return C1Element.SafeAncestorsAndSelf(name).Count();
		}

		[Test]
		public void SafeNameForNull() {
			NullElement.SafeName().Is((string)null);
		}

		[Test]
		[TestCase("a", Result = "a")]
		[TestCase("b", Result = "b")]
		public string SafeNameForNotNull(string name) {
			return Root.SafeElement(name).SafeName();
		}

		[Test]
		public void SafeValueForNull() {
			NullElement.SafeValue().Is((string)null);
		}

		[Test]
		[TestCase("a", Result = "a1")]
		[TestCase("b", Result = "b1c1")]
		public string SafeValueForNotNull(string name) {
			return Root.SafeElement(name).SafeValue();
		}

		[Test]
		public void SafeParentForNull() {
			NullElement.SafeParent().SafeName().Is((string)null);
		}

		[Test]
		public void SafeParentForNotNull() {
			A2Element.SafeParent().SafeName().Is("e");
		}

		[Test]
		public void SafePreviousElementForNull() {
			NullElement.SafePreviousElement().SafeName().Is((string)null);
		}

		[Test]
		public void SafePreviousElementForNotNull() {
			B1Element.SafePreviousElement().SafeValue().Is("a2");
		}

		[Test]
		public void SafeNextElementForNull() {
			NullElement.SafeNextElement().SafeName().Is((string)null);
		}

		[Test]
		public void SafeNextElementForNotNull() {
			A2Element.SafeNextElement().SafeName().Is("b");
		}

		[Test]
		public void SafeFirstElementForNull() {
			NullElement.SafeFirstElement().SafeValue().Is((string)null);
		}

		[Test]
		public void SafeFirstElementForNotNull() {
			Root.SafeFirstElement().SafeValue().Is("a1");
		}

		[Test]
		public void SafeLastElementForNull() {
			NullElement.SafeLastElement().SafeValue().Is((string)null);
		}

		[Test]
		public void SafeLastElementForNotNull() {
			Root.SafeLastElement().SafeValue().Is("d1");
		}

		[Test]
		public void SafeNthElementForNull() {
			NullElement.SafeNthElement(1).SafeValue().Is((string)null);
		}

		[Test]
		public void SafeNthElementForNotNull() {
			Root.SafeNthElement(1).SafeValue().Is("a2");
		}

		[Test]
		public void SafeFirstElementBeforeSelfForNull() {
			NullElement.SafeFirstElementBeforeSelf().SafeValue().Is((string)null);
		}

		[Test]
		public void SafeFirstElementBeforeSelfForNotNull() {
			B1Element.SafeFirstElementBeforeSelf().SafeValue().Is("a1");
		}

		[Test]
		public void SafeLastElementBeforeSelfForNull() {
			NullElement.SafeLastElementBeforeSelf().SafeValue().Is((string)null);
		}

		[Test]
		public void SafeLastElementBeforeSelfForNotNull() {
			B1Element.SafeLastElementBeforeSelf().SafeValue().Is("a2");
		}

		[Test]
		public void SafeNthElementBeforeSelfForNull() {
			NullElement.SafeNthElementBeforeSelf(1).SafeValue().Is((string)null);
		}

		[Test]
		public void SafeNthElementBeforeSelfForNotNull() {
			B1Element.SafeNthElementBeforeSelf(1).SafeValue().Is("a2");
		}

		[Test]
		public void SafeFirstElementAfterSelfForNull() {
			NullElement.SafeFirstElementAfterSelf().SafeValue().Is((string)null);
		}

		[Test]
		public void SafeFirstElementAfterSelfForNotNull() {
			A1Element.SafeFirstElementAfterSelf().SafeValue().Is("a2");
		}

		[Test]
		public void SafeLastElementAfterSelfForNull() {
			NullElement.SafeLastElementAfterSelf().SafeValue().Is((string)null);
		}

		[Test]
		public void SafeLastElementAfterSelfForNotNull() {
			A1Element.SafeLastElementAfterSelf().SafeValue().Is("d1");
		}

		[Test]
		public void SafeNthElementAfterSelfForNull() {
			NullElement.SafeNthElementAfterSelf(1).SafeValue().Is((string)null);
		}

		[Test]
		public void SafeNthElementAfterSelfForNotNull() {
			A1Element.SafeNthElementAfterSelf(1).SafeValue().Is("b1c1");
		}
	}
}