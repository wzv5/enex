using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private EnexFile.EnexFile enex;

        [TestInitialize]
        public void Init()
        {
            enex = new EnexFile.EnexFile();
            enex.Load(@"D:\User\Desktop\测试导出.enex");
        }

        [TestMethod]
        public void TestMethod1()
        {
            var obj = enex.Result;
            Assert.IsNotNull(obj.ExportDate);
        }

        [TestMethod]
        public void TestMethod2()
        {
            enex.DumpAll("z:/111", new EnexFile.MarkdownConfig() { InlineImage = true, InsertTitle = true, UUIDFilename = true });
        }
    }
}
