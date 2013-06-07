using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ImmutableDeserialize
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void Run()
        {
            var context = new Context();
            context.Workspace.SetTasks(new [] { "hello", "world!" });
            Assert.AreEqual(2, context.Workspace.Tasks.Count());

            const string path = @"c:\Temp\Workspace.xml";
            using (var fs = File.OpenWrite(path))
            {
                context.Save(fs);
            }

            context.Workspace.Reset();

            Assert.AreEqual(0, context.Workspace.Tasks.Count());

            using (var fs = File.OpenRead(path))
            {
                context.Reload(fs);
            }

            Assert.AreEqual(2, context.Workspace.Tasks.Count());
        }
    }
}