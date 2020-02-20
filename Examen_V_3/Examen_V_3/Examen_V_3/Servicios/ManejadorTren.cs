using Examen_V_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3.Servicios
{
    public class ManejadorTren : IMedioTransporte
    {
        public int iVelocidadEntrega = 80;
        public int iCostoPorKm = 80;
        public int iMargenUtilidad = 80;
        public string cDescripcion { set => throw new NotImplementedException(); }

        public string ObtenerCadena()
        {
            throw new NotImplementedException();
        }

        public decimal ObtenerCostoEnvio(int _iDistancia)
        {
            decimal dCostoEnvio = 0M;
            dCostoEnvio = iCostoPorKm * _iDistancia * ((1 + iMargenUtilidad) / 100);
            return dCostoEnvio;
        }

        public DateTime ObtenerFechaEntrega(DateTime _dtPedido, int _iTiempoTraslado)
        {
            return _dtPedido + TimeSpan.FromMinutes(_iTiempoTraslado);
        }

        public int ObtenerTiempoTraslado(int _iDistancia)
        {
            int iTiempoTraslado = (int)decimal.Zero;
            iTiempoTraslado = _iDistancia / iVelocidadEntrega;
            return iTiempoTraslado;
        }

        public void MostrarEstatusPedido(string _cMensajeUno, string _cOrigen, string _cMensajeDos, string _cDestino, decimal _dCosto, string _cPaqueteria)
        {
            Console.WriteLine("Tu paquete {0} de {1} y {2} a {3} y tuvo un costo de ${4}(cualquier reclamación con {5}).", _cMensajeUno, _cOrigen, _cMensajeDos, _cDestino, _dCosto.ToString(), _cPaqueteria);
        }
    }
}
