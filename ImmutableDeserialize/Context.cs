using System.IO;
using System.Runtime.Serialization;

namespace ImmutableDeserialize
{
    public class Context
    {
        public Context()
        {
            Workspace = new Workspace();
        }

        public Workspace Workspace { get; private set; }

        public void Reload(Stream input)
        {
            var ser = new DataContractSerializer(typeof(Workspace));
            var obj = (Workspace)ser.ReadObject(input);
            Workspace = obj;
        }

        public void Save(Stream output)
        {
            var ser = new DataContractSerializer(typeof(Workspace));
            ser.WriteObject(output, Workspace);
        }
    }
}