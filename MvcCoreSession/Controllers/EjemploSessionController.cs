using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        int numero = 1;

        public IActionResult Index()
        {
            this.numero += 1;
            ViewData["NUMERO"] = "El valor del número es " + this.numero;
            return View();
        }

        //ACTION PARA VISUALIZAR DATOS EN SESION DE FORMA SIMPLE
        public IActionResult SessionSimple(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //GUARDAMOS DATOS EN SESSION
                    HttpContext.Session.SetString("nombre", "Programeitor");
                    HttpContext.Session.SetString("hora",
                        DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "Datos almacenados correctamente";
                }else if (accion.ToLower() == "mostrar")
                {
                    ViewData["USUARIO"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }

        public IActionResult SessionMascota(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota();
                    mascota.Nombre = "Flounder";
                    mascota.Raza = "Pez";
                    mascota.Edad = 11;
                    //PARA ALMACENAR EL OBJETO EN SESSION DEBEMOS
                    //CONVERTIRLO A byte[]
                    byte[] data =
                        HelperBinarySession.ObjectToByte(mascota);
                    //ALMACENAMOS EL OBJETO byte[] EN SESSION
                    HttpContext.Session.Set("MASCOTA", data);
                    ViewData["MENSAJE"] = "Datos almacenados correctamente";
                }else if (accion.ToLower() == "mostrar")
                {
                    //DEBEMOS RECUPERAR LOS byte[] DE SESSION
                    //QUE REPRESENTAN EL OBJETO MASCOTA
                    byte[] data = HttpContext.Session.Get("MASCOTA");
                    //CONVERTIMOS LOS byte[] A NUESTRO OBJETO MASCOTA
                    Mascota mascota = (Mascota)
                        HelperBinarySession.ByteToObject(data);
                    ViewData["MASCOTA"] = mascota;
                }
            }
            return View();
        }
    }
}
