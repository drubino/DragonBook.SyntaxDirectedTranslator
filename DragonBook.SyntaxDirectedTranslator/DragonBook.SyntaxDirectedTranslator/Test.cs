using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonBook.SyntaxDirectedTranslator
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void PostfixTranslatorTest()
        {
            var translator = new PostfixTranslator();
            var result1 = translator.Translate("1");
            var result2 = translator.Translate("1+2");
            var result3 = translator.Translate("1+2-3");
        }
    }
}
