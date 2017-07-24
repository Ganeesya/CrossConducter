using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossConducter
{
	public interface TaskAdderInterface
	{
		void addTask(string message, string autherID, string autherName, string autherAddinfo, CCInputInterface adder, string adderAddinfo);
	}

	public interface TaskListDataInterface
	{
		List<CCInputInterface> GetInputList();
		List<CCOutputInterface> GetOutputList();
		List<YomiageTask> GetTaskList();

		void addTaskAfter(string message, string autherID, string autherName, string auAd, string src, string srcAdd, CCOutputInterface outer);
		void addTaskBefore(string message, string autherID, string autherName, string auAd, string src, string srcAdd, CCOutputInterface outer);
	}
}
