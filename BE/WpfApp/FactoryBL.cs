using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace WpfApp
{
    public class FactoryBL
    {
        public static IBL GetBL()
        {
            IBL ibl = new BLL_XML();

            return ibl;
        }
    }
}
