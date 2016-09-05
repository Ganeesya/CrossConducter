using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossConducter
{
	public interface CCTaskControllInterface: CCPluginInterface
	{
		void init(TaskListDataInterface tasker );
		void TaskCheck(YomiageTask ntask);
	}
}
