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
		
		public void SetTasks(IEnumerable<string> tasks)
		{
			Tasks = tasks.ToArray();
		}

        public void Reset()
        {
            Tasks = new string[0];
        }
    }
}