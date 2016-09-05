using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossConducter
{
	public interface TaskAdderInterface
	{
		void addTask(string message,string autherID,string autherName, CCInputInterface adder);
	}

	public interface TaskListDataInterface
	{
		List<CCInputInterface> GetInputList();
		List<CCOutputInterface> GetOutputList();
		List<YomiageTask> GetTaskList();
	}
}
