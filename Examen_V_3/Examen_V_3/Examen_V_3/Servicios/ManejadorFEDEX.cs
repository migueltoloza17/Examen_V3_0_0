using Examen_V_3.Entidad;
using Examen_V_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3.Servicios
{
    public class ManejadorFEDEX : IPaqueteria
    {
        private IMedioTransporte svrMedioTransporte;

        public ManejadorFEDEX(IMedioTransporte _svrMedioTransporte)
        {
            this.svrMedioTransporte = _svrMedioTransporte;
        }

        public void CalcularEstatusPaqueteria(PaqueteDTO _paquete)
        {
            int iTiempoTraslado = (int)decimal.Zero;
            decimal dCostoEnvio = 0M;
            DateTime dtPedido;

            iTiempoTraslado = svrMedioTransporte.ObtenerTiempoTraslado(_paquete.iDistancia);
            dCostoEnvio = svrMedioTransporte.ObtenerCostoEnvio(_paquete.iDistancia);
            dtPedido = svrMedioTransporte.ObtenerFechaEntrega(_paquete.dtPedido, iTiempoTraslado);

            svrMedioTransporte.MostrarEstatusPedido("salio", _paquete.cOrigen, "llegara", _paquete.cDestino, dCostoEnvio, _paquete.cPaqueteria);

        }
    }
}
