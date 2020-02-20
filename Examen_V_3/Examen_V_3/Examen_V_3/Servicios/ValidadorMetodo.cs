using Examen_V_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3.Servicios
{
    public class ValidadorMetodo : IMetodoEnvio
    {
        private IMetodoEnvio ImetodoEnvio;
        private string cMetodoEnvio;
        private string cMetodoValidar;
        public string _cDescrpcion;

        public ValidadorMetodo(string _MetodoEnvio, string _Metodovalidar)
        {
            this.cMetodoEnvio = _MetodoEnvio;
            this.cMetodoValidar = _Metodovalidar;
        }

        public string cDescripcion { get => _cDescrpcion; set => _cDescrpcion = value; }

        public void Siguiente(IMetodoEnvio _ImetodoEnvio)
        {
            this.ImetodoEnvio = _ImetodoEnvio;
        }

        public string ValidaMedioTransporte()
        {
            string cMetodo = "";
            cMetodo = this._cDescrpcion;
            if (cMetodoValidar == cMetodoEnvio)
            {
                this._cDescrpcion = cMetodoEnvio;
                ImetodoEnvio = null;
            }    
            else if (ImetodoEnvio != null)
                ImetodoEnvio.ValidaMedioTransporte();
            else
                return this._cDescrpcion;

            return this._cDescrpcion;
        }       
    }
}
