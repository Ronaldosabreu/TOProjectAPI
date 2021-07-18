using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using ToProject.DTO;
using ToProject.Entityes;

namespace TesteUnitario
{
    [TestClass]
    public class UnitTest1
    {
        protected readonly HttpClient _client;

        [TestMethod]
        public void Get_Login()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.gooogle.com/");
            webRequest.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            //Returns "MovedPermanently", not 301 which is what I want.
            var teste= response.StatusCode.ToString();
            Assert.AreEqual("Moved", response.StatusCode.ToString());
        }

        [TestMethod]
        public void Insere_Login()
        {
            DTOTestUsuario insert = new DTOTestUsuario();
            insert.nome = "b";
            insert.email = "b";
            insert.senha = "b";
            List<DTOProfile> lista = new List<DTOProfile>();
            for (int i = 0; i < 5; i++)
            {              
                DTOProfile item2 = new DTOProfile();
                item2.Nivel = "nivel" + i.ToString(); ;
                lista.Add(item2);
            }   
            insert.Profiles_User = lista;
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:36469/api/Usuarios/Inserir_Usuario");
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                //usando o Json Serialize
                string json = JsonConvert.SerializeObject(insert, Formatting.Indented);
                streamWriter.Write(json);

            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            Assert.AreEqual("OK", response.StatusCode.ToString());

            Get_LoginAPI();

        }

        //[TestMethod]
        public void Get_LoginAPI()
        {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:36469/api/Usuarios/Login");
                request.ContentType = "application/json";
                request.Method = "POST";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {

                    //usando nancy
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        email = "b",
                        senha = "b"
                    });

                    streamWriter.Write(json);
                }
            
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                Assert.AreEqual("OK", response.StatusCode.ToString());
        }
    }
}
