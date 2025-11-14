using MongoDB.Bson;
using MongoDB.Driver;
using PoddProjektV3._2;
using PoddProjektV3._2.Models;
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
        public readonly IMongoCollection<Podcast> podcastKollektion;


        public MongoDBServices()
        {
            var klient = new MongoClient("mongodb+srv://OruMongoDBAdmin:hej@orumongodb.8yb9y4t.mongodb.net/?appName=OruMongoDB");
            var databas = klient.GetDatabase("OruMongoDB");
            podcastKollektion = databas.GetCollection<Podcast>("Poddar");
        }


        public bool PodcastFinns(string titel)
        {

            var filter = Builders<Podcast>.Filter.Eq(p => p.Titel, titel);

            return podcastKollektion.Find(filter).Any();

        }

        public void LaggTillPodcast(Podcast p)
        {
            if (!PodcastFinns(p.Titel))
            {
                podcastKollektion.InsertOne(p);
            }
        }

        public List<Podcast> HamtaAllaPodcasts()
        {
            var filter = FilterDefinition<Podcast>.Empty;
            List<Podcast> PodcastLista = podcastKollektion.Find(filter).ToList();
            return PodcastLista;
        }

        public Podcast HamtaPodcast(string titel)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.Titel, titel);

            return podcastKollektion.Find(filter).FirstOrDefault();
        }




        public bool UppdateraPodcast(Podcast updateradPodcast)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.Titel, updateradPodcast.Titel);
            var updatering = Builders<Podcast>.Update
                .Set(p => p.Titel, updateradPodcast.Titel)
                .Set(p => p.Beskrivning, updateradPodcast.Beskrivning)
                .Set(p => p.Kategori, updateradPodcast.Kategori)
                .Set(p => p.PoddAvsnitt, updateradPodcast.PoddAvsnitt);

            var resultat = podcastKollektion.UpdateOne(filter, updatering);
            return resultat.ModifiedCount > 0;
        }

        public void TaBortPodcast(string titel)
        {
            var filter = Builders<Podcast>.Filter.Eq(p => p.Titel, titel);
            podcastKollektion.DeleteOne(filter);
        }

    }
}
