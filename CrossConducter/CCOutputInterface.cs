using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossConducter
{
	public interface CCOutputInterface: CCPluginInterface
	{
		void init();
		bool isBusy();
		bool isEnable();
		void output(string mes,int speed);
	}
}
