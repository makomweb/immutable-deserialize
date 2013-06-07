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

            using (var stream = new MemoryStream())
            {
                context.Save(stream);

                context.Workspace.Reset();
                stream.Seek(0, SeekOrigin.Begin);

                Assert.AreEqual(0, context.Workspace.Tasks.Count());

                context.Reload(stream);
            }

            Assert.AreEqual(2, context.Workspace.Tasks.Count());
        }
    }
}