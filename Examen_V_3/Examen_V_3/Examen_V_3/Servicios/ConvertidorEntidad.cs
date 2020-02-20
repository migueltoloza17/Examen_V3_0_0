using Examen_V_3.Entidad;
using Examen_V_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3.Servicios
{
    public class ConvertidorEntidad
    {
        private ILectorArchivo _svrILectorArchivo;

        public ConvertidorEntidad(ILectorArchivo svrILectorArchivo)
        {
            this._svrILectorArchivo = svrILectorArchivo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entEvento"></param>
        /// <returns></returns>
        public List<PaqueteDTO> ObtenerPedidos(string _cRuta,string _cSeparador)
        {
            string[] aRegistros;
            List<PaqueteDTO> lstEventosFecha = new List<PaqueteDTO>();
            aRegistros = _svrILectorArchivo.ObtenerArchivo(_cRuta);

            foreach (string item in aRegistros)
            {
                ValidarRegistro(item, _cSeparador);
                AgregarRegistro(lstEventosFecha, item, _cSeparador);
            }
            return lstEventosFecha;
        }

        /// <summary>
        /// Método que se encarga de validar si el registro contiene la cadena 
        /// para separa el evento y fecha
        /// </summary>
        /// <param name="_cRegistro">Registro a validar(cadena)</param>
        private void ValidarRegistro(string _cRegistro, string _cSeparador)
        {
            if (!_cRegistro.Contains(_cSeparador))
                throw new Exception("No se cuenta con el formato correcto");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_lstEventosFecha"></param>
        /// <param name="_item"></param>
        private void AgregarRegistro(List<PaqueteDTO> _lstEventosFecha, string _item, string _cSeparador)
        {
            string[] aCampos = ObtenerCampos(_item, _cSeparador);
            PaqueteDTO entEvento = new PaqueteDTO();
            ObtenerRegistro(entEvento, aCampos);
            _lstEventosFecha.Add(entEvento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        private string[] ObtenerCampos(string _item, string _cSeparador)
        {
            return _item.Split(_cSeparador[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entEvento"></param>
        /// <param name="_aCampos"></param>
        private void ObtenerRegistro(PaqueteDTO _entEvento, string[] _aCampos)
        {
            _entEvento.cOrigen = _aCampos[0];
            _entEvento.cDestino = _aCampos[1];
            _entEvento.iDistancia = Convert.ToInt32(_aCampos[2]);
            _entEvento.cPaqueteria = _aCampos[3];
            _entEvento.cMedioTransporte = _aCampos[4];
            _entEvento.dtPedido = DateTime.Parse(_aCampos[5]);
        }
    }
}
