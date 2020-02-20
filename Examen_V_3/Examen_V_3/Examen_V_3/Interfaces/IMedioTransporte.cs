using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3.Interfaces
{
    public interface IMedioTransporte
    {
        string cDescripcion { set; }

        int ObtenerTiempoTraslado(int _iDistancia);
        DateTime ObtenerFechaEntrega(DateTime _dtPedido, int _iTiempoTraslado);

        decimal ObtenerCostoEnvio(int _iDistancia);

        void MostrarEstatusPedido(string _cMensajeUno, string cOrigen, string _cMensajeDos, string _cDestino, decimal _dCosto, string _cPaqueteria);
    }
}
