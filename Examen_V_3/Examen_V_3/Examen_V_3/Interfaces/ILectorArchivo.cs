using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3.Interfaces
{
    public interface ILectorArchivo
    {
        //string cRuta { get; set; }
        string[] ObtenerArchivo(string cRuta);
    }
}
