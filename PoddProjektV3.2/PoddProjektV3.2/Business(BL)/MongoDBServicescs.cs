using MongoDB.Bson;
using MongoDB.Driver;
using PoddProjektV3._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace PoddProjektV3
{
    public class MongoDBServices
    {
        public readonly IMongoCollection<Medlem> medlemKollektion;


        public MongoDBServices()
        {
            var klient = new MongoClient("mongodb+srv://OruMongoDBAdmin:hej@orumongodb.8yb9y4t.mongodb.net/?appName=OruMongoDB");
            var databas = klient.GetDatabase("OruMongoDB");
            medlemKollektion = databas.GetCollection<Medlem>("Medlemmar");
        }


        public bool MedlemFinns(string ID)
        {

            var filter = Builders<Medlem>.Filter.Eq(m => m.Id, ID);

            return medlemKollektion.Find(filter).Any();

        }

        public void LaggTillMedlem(Medlem m)
        {
            if (!MedlemFinns(m.Id))
            {
                medlemKollektion.InsertOne(m);
            }
        }

        public List<Medlem> HamtaAllaMedlemmar()
        {
            var filter = FilterDefinition<Medlem>.Empty;
            List<Medlem> medlemLista = medlemKollektion.Find(filter).ToList();
            return medlemLista;
        }

        public Medlem HamtaMedlem(string id)
        {
            var filter = Builders<Medlem>.Filter.Eq(m => m.Id, id);

            return medlemKollektion.Find(filter).FirstOrDefault();
        }

        public List<Medlem> HamtaMedlemmarMedPoangOver(int minPoang)
        {
            var filter = Builders<Medlem>.Filter.Gte(m => m.TotalPoang, minPoang);
            return medlemKollektion.Find(filter).ToList();

        }

      

        






        public bool UppdateraMedlem(Medlem updateradMedlem)
        {
            var filter = Builders<Medlem>.Filter.Eq(m => m.Id, updateradMedlem.Id);
            var updatering = Builders<Medlem>.Update
                .Set(m => m.Namn, updateradMedlem.Namn)
                .Set(m => m.Epost, updateradMedlem.Epost)
                .Set(m => m.TotalPoang, updateradMedlem.TotalPoang);

            var resultat = medlemKollektion.UpdateOne(filter, updatering);
            return resultat.ModifiedCount > 0;
        }

        public void TaBortMedlem(string id)
        {
            var filter = Builders<Medlem>.Filter.Eq(m => m.Id, id);
            medlemKollektion.DeleteOne(filter);
        }

    }
}
