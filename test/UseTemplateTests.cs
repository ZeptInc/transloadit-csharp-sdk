using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using Transloadit;
using Transloadit.Assembly;

namespace Tests
{
    [TestFixture]
    class UseTemplateTests
    {
        [Test]
        public void ExistingTemplate()
        {
            ITransloadit transloadit = TransloaditFactory.CreateInstance();
            IAssemblyBuilder assembly = new AssemblyBuilder();

            assembly.SetTemplateID("YOUR-EXISTING-TEMPLATE-ID");

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
        }

        [Test]
        public void NonExistingTemplate()
        {
            ITransloadit transloadit = TransloaditFactory.CreateInstance();
            IAssemblyBuilder assembly = new AssemblyBuilder();

            assembly.SetTemplateID("YOUR-NON-EXISTING-TEMPLATE-ID");

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.AreEqual("TEMPLATE_NOT_FOUND", (string)(response.Data["error"]));
        }
    }
}
