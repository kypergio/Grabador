using System;
using System.IO;
using System.Net;

namespace Utilidades
{
    public class Peticion
    {
        private HttpWebRequest peticion;
        private string url = "http://hall-rna.com";
        private string metodo;
        private HttpWebResponse respuesta;

        public void PedirComunicacion(string url, string metodo)
        {
            string uri = this.url + url;
            this.metodo = metodo;

            peticion = (HttpWebRequest)HttpWebRequest.Create(uri);
            peticion.ContentType = "application/json; charset=utf-8";
            peticion.Accept = "application/json";
            peticion.Method = metodo;
        }

        public void IncrustarDatos(string json)
        {
            using (var streamWriter = new StreamWriter(peticion.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        public void AgregarHeader(string header,string value)
        {
            peticion.Headers.Add(header,value);
        }

        public string ObtenerJson()
        {
            try
            {
                respuesta = (HttpWebResponse)peticion.GetResponse();
                Stream stream = respuesta.GetResponseStream();
                string json = "";

                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        json += reader.ReadLine();
                    }
                }
                return json;
            }
            catch (Exception ex) 
            {
                return null;
            }

            
        }

        public HttpStatusCode ObtenerEstado()
        {
            return respuesta.StatusCode;
        }
    }
}
