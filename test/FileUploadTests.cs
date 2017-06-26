﻿using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using Transloadit;
using Transloadit.Assembly;

namespace Tests
{
    [TestFixture]
    class FileUploadTests
    {
        [Test]
        public void ResizeImageExistingFile()
        {
            ITransloadit transloadit = TransloaditFactory.CreateInstance();
            IAssemblyBuilder assembly = new AssemblyBuilder();

            assembly.AddFile(System.IO.Path.GetFullPath("test.jpg"));

            IStep step = new Step();
            step.SetOption("robot", "/image/resize");
            step.SetOption("width", 75);
            step.SetOption("height", 75);
            step.SetOption("resize_strategy", "pad");
            step.SetOption("background", "#000000");

            assembly.AddStep("thumb", step);

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
            Assert.IsTrue(response.Data["uploads"].ToObject<List<Dictionary<string, object>>>().Count > 0);
        }

        [Test]
        public void ResizeImageNonExistingFile()
        {
            ITransloadit transloadit = TransloaditFactory.CreateInstance();
            IAssemblyBuilder assembly = new AssemblyBuilder();

            assembly.AddFile(@"test_non_existing.jpg");

            IStep step = new Step();
            step.SetOption("robot", "/image/resize");
            step.SetOption("width", 75);
            step.SetOption("height", 75);
            step.SetOption("resize_strategy", "pad");
            step.SetOption("background", "#000000");

            assembly.AddStep("thumb", step);

            TransloaditResponse response = transloadit.InvokeAssembly(assembly);

            Assert.IsTrue((string)response.Data["ok"] == "ASSEMBLY_COMPLETED" || (string)response.Data["ok"] == "ASSEMBLY_EXECUTING");
            Assert.IsTrue(response.Data["uploads"].ToObject<List<Dictionary<string, object>>>().Count == 0);
        }
    }
}
