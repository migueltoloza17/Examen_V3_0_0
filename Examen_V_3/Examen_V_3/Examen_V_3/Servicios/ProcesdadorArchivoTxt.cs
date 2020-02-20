using Examen_V_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3.Servicios
{
    public class ProcesdadorArchivoTxt : ILectorArchivo
    {
        //public string cRuta { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string[] ObtenerArchivo(string _cRuta)
        {
            return System.IO.File.ReadAllLines(_cRuta);
        }
    }
}
