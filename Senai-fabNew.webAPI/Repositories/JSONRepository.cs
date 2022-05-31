using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Repositories
{
    public class JSONRepository : IJsonRepository
    {


        public string UpdateJson(Json objNovo)
        {
            var pasta = Path.Combine("StaticFiles", "SalvarJson", "objeto.json");
            var path = Path.Combine(Directory.GetCurrentDirectory(), pasta);
            
            string JsonString = File.ReadAllText(path);

            string response = RegenerateJson();

            JObject rss = JObject.Parse(response);

            JObject Detectedobjects = (JObject)rss["Detectedobjects"];

            Detectedobjects["Chair"] = (objNovo.Chair);
            Detectedobjects["Television"] = (objNovo.Television);
            Detectedobjects["Plant"] = (objNovo.Plant);
            Detectedobjects["Computer"] = (objNovo.Computer);
            Detectedobjects["Laptop"] = (objNovo.Laptop);
            Detectedobjects["Cup"] = (objNovo.Cup);
            Detectedobjects["Person"] = (objNovo.People);
            Detectedobjects["Book"] = (objNovo.Book);
            Detectedobjects["Display"] = (objNovo.Display);
            Detectedobjects["Painting"] = (objNovo.Painting);
            Detectedobjects["Computer Mouse"] = (objNovo.Mouse);
            Detectedobjects["Bottle"] = (objNovo.Bottle);


            string Tjson = JsonConvert.SerializeObject(Detectedobjects);
            File.WriteAllText(path, Tjson);

            return Tjson;
        }

        public string RegenerateJson()
        {
            string json = @"{
    'Detectedobjects' : {
        'Chair' : false,
        'Television' : false,
        'Plant' : false,
        'Computer' : false,
        'Laptop' : false,
        'Cup' : false,
        'Person' : false,
        'Book' : false,
        'Display' : false,
        'Painting' : false,
        'Computer Mouse' : false,
        'Bottle' : false,
                }
            }";

            var pasta = Path.Combine("StaticFiles", "SalvarJson", "objeto.json");
            var path = Path.Combine(Directory.GetCurrentDirectory(), pasta);

            string Tjson = JsonConvert.SerializeObject(json);
            File.WriteAllText(path, Tjson);

            string JsonString = File.ReadAllText(path);


            object json1 = JsonConvert.DeserializeObject(JsonString);

            return json1.ToString();
        }

        public string LerJson()
        {
            var pasta = Path.Combine("StaticFiles", "SalvarJson", "objeto.json");
            var path = Path.Combine(Directory.GetCurrentDirectory(), pasta);

            string JsonString = File.ReadAllText(path);


            object json1 = JsonConvert.DeserializeObject(JsonString);

            return json1.ToString();
        }
    }
}