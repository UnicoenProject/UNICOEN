using Unicoen.Apps.Findbug;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unicoen.Model;
using System.Collections.Generic;

namespace TestProject1
{
    
    
    /// <summary>
    ///DefUseAnalyzerTest のテスト クラスです。すべての
    ///DefUseAnalyzerTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class DefUseAnalyzerTest {


        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region 追加のテスト属性
        // 
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///FindDefines のテスト
        ///</summary>
        [TestMethod()]
        public void FindDefinesTest() {
            IEnumerable<IUnifiedElement> expected = null; // TODO: 適切な値に初期化してください
            IEnumerable<IUnifiedElement> actual;
            actual = DefUseAnalyzer.FindDefines();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///FindUses のテスト
        ///</summary>
        [TestMethod()]
        public void FindUsesTest() {
            IEnumerable<IUnifiedElement> expected = null; // TODO: 適切な値に初期化してください
            IEnumerable<IUnifiedElement> actual;
            actual = DefUseAnalyzer.FindUses();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }
    }
}
