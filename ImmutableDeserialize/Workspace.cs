using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ImmutableDeserialize
{
    [DataContract]
    public class Workspace
    {
        [DataMember]
        public string[] Tasks { get; private set; }

        [DataMember]
        private string Dummy { get; set; }
		
		public void SetTasks(IEnumerable<string> tasks)
		{
			Tasks = tasks.ToArray();
		}

        public void SetDummy(string value)
        {
            Dummy = value;
        }

        public string GetDummy()
        {
            return Dummy;
        }

        public void Reset()
        {
            Tasks = new string[0];
            Dummy = null;
        }
    }
}