using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PROCOMER.VUI.INS.Entidades;

namespace PROCOMER.VUI.INS
{
    /// <summary>
    /// Summary description for WS_INS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_INS : System.Web.Services.WebService
    {
        //RETORNO ERRONEO FALTA DE DATOS PARA PROBAR
        [WebMethod]
        public string ConsultaPolizas(string pm_TipoProceso, string pm_FechaDesde, string pm_NumeroPoliza, string pm_CodigoTipoIdentificacion, string pm_Identificación)
        {
            string json;
            try
            {
                WS_INS_ConsultaPolizas_Pruebas.Param param = new WS_INS_ConsultaPolizas_Pruebas.Param();
                param.TipoProceso = pm_TipoProceso;
                param.FechaDesde = pm_FechaDesde;
                param.NumeroPoliza = pm_NumeroPoliza;
                param.CodigoTipoIdentificacion = pm_CodigoTipoIdentificacion;
                param.Identificacion = pm_Identificación;

                WS_INS_ConsultaPolizas_Pruebas.IConsultaPolizas cons = new WS_INS_ConsultaPolizas_Pruebas.ConsultaPolizasClient();
                WS_INS_ConsultaPolizas_Pruebas.Respuesta response = new WS_INS_ConsultaPolizas_Pruebas.Respuesta();

                response = cons.ConsultaPoliza(param);
                json = JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return json;
        }
        //RETORNO EXITOSO
        [WebMethod]
        public string ConsultaCertificación(string pm_TipoProceso, string pm_NumeroPoliza, string pm_NumeroCertificacion)
        {
            string json;
            try
            {
                WS_INS_ConsultaCertificaciones_Pruebas.Param param = new WS_INS_ConsultaCertificaciones_Pruebas.Param();
                param.TipoProceso = pm_TipoProceso;
                param.NumeroPoliza = pm_NumeroPoliza;
                param.NumeroCertificacion = pm_NumeroCertificacion;

                WS_INS_ConsultaCertificaciones_Pruebas.ICertificacionPolizas request = new WS_INS_ConsultaCertificaciones_Pruebas.CertificacionPolizasClient();
                WS_INS_ConsultaCertificaciones_Pruebas.Respuesta response = new WS_INS_ConsultaCertificaciones_Pruebas.Respuesta();

                response = request.ConsultaCertificacion(param);
                json = JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return json;//NESESITO VER SI QUIEREN QUE RETORNE UN JSON
        }
        [WebMethod]
        public string Catalogos(string pm_entrada)
        {
            try
            {
                WS_INS_Catalogos_Pruebas.ICatalogos request = new WS_INS_Catalogos_Pruebas.CatalogosClient();
                switch (pm_entrada)
                {
                    case "TipoIdentificaciones":
                        return request.TipoIdentificacionesJson();
                        break;
                    case "TipoPolizas":
                        return request.TipoPolizasJson();
                        break;
                    case "FormaPagos":
                        return request.FormaPagosJson();
                        break;
                    case "EstadoPolizas":
                        return request.EstadoPolizasJson();
                        break;
                    case "Ocupaciones":
                        return request.OcupacionesJson();
                        break;
                    default:
                        return "Error";
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [WebMethod]
        public string CotizacionEmisionPoliza(string jsonData)
        {
            string json;
            try
            {
                WS_INS_CotizacionEmisionPoliza_Pruebas.ICotizacionEmisionPolizas response = new WS_INS_CotizacionEmisionPoliza_Pruebas.CotizacionEmisionPolizasClient();
                json = JsonConvert.SerializeObject(response.CotizacionEmisionPoliza(jsonData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return json;
        }
    }
}
