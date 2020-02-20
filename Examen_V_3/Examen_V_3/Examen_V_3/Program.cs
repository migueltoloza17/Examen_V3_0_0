using Examen_V_3.Entidad;
using Examen_V_3.Interfaces;
using Examen_V_3.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_V_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PaqueteDTO> lstPaquete = new List<PaqueteDTO>();
            ILectorArchivo svrLectorArchivo = new ProcesdadorArchivoTxt();
            IPaqueteria svrPaqueteria;
            IMedioTransporte svrMedioTransporte = new ManejadorBarco();
            ConvertidorEntidad convertidorEntidad = new ConvertidorEntidad(svrLectorArchivo);
            lstPaquete = convertidorEntidad.ObtenerPedidos(@"D:\Examen\Examen_V_3\Rastreo_Paquetes.txt", ",");

            foreach (PaqueteDTO item in lstPaquete)
            {
                switch (item.cPaqueteria)
                {
                    case "Estafeta":
                        ObtenerMedioTransporteEstafeta(item.cMedioTransporte, svrMedioTransporte);
                        svrPaqueteria = new ManejadorEstafeta(svrMedioTransporte);
                        svrPaqueteria.CalcularEstatusPaqueteria(item);
                        break;
                    case "FEDEX":
                        svrMedioTransporte = new ManejadorBarco();
                        svrPaqueteria = new ManejadorFEDEX(svrMedioTransporte);
                        svrPaqueteria.CalcularEstatusPaqueteria(item);
                        break;
                    case "DHL":
                        ObtenerMedioTransporteDHL(item.cMedioTransporte, svrMedioTransporte);

                        svrPaqueteria = new ManejadorDHL(svrMedioTransporte);
                        svrPaqueteria.CalcularEstatusPaqueteria(item);

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine((string.Format("La  Paquetería: {0} no se encuentra registrada en nuestra red de distribución.", item.cPaqueteria)));
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }


        static void ObtenerMedioTransporteDHL(string _cMedioTransporte, IMedioTransporte svrMedioTransporte)
        {
            string cMedioTransporte = string.Empty;
            IMetodoEnvio metodoUno = new ValidadorMetodo("Avión", _cMedioTransporte);
            IMetodoEnvio metodoDos = new ValidadorMetodo("Barco", _cMedioTransporte);
            metodoDos.Siguiente(metodoUno);
            cMedioTransporte = metodoDos.ValidaMedioTransporte();

            if (cMedioTransporte == "Avión")
                svrMedioTransporte = new ManejadorAvion();
            else
                svrMedioTransporte = new ManejadorBarco();
        }

        static void ObtenerMedioTransporteEstafeta(string _cMedioTransporte, IMedioTransporte svrMedioTransporte)
        {
            string cMedioTransporte = string.Empty;
            IMetodoEnvio metodoUno = new ValidadorMetodo("Barco", _cMedioTransporte);
            IMetodoEnvio metodoDos = new ValidadorMetodo("tren", _cMedioTransporte);

            metodoUno.Siguiente(metodoDos);
            cMedioTransporte = metodoUno.ValidaMedioTransporte();

            if (cMedioTransporte == "Tren")
                svrMedioTransporte = new ManejadorTren();
            else
                svrMedioTransporte = new ManejadorBarco();
        }
    }
}
