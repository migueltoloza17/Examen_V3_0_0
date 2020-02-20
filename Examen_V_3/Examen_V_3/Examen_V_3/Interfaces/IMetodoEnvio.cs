using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3.Interfaces
{
    public interface IMetodoEnvio
    {
        string cDescripcion { get; set; }
        void Siguiente(IMetodoEnvio _ImetodoEnvio);
        string ValidaMedioTransporte();

    }
}
