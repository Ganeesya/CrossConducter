using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossConducter
{
	public interface CCInputInterface: CCPluginInterface
	{
		void init( TaskAdderInterface taskadder );
	}
}
