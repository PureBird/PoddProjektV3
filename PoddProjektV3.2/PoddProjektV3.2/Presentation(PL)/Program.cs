using System.Diagnostics;

namespace PoddProjektV3._2
{
    internal static class Program
    {

        private static readonly MongoDBServices service = new MongoDBServices();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PodVisaren());
            Debug.WriteLine("hallå");

            Medlem medlem1 = new Medlem("1", "Axel", "Axel@gmail.com", 10);

            service.LaggTillMedlem(medlem1);

            List<Medlem> allaMedlemmar = service.HamtaAllaMedlemmar();

            foreach (Medlem m in allaMedlemmar)
            {
                System.Diagnostics.Debug.WriteLine(m.Namn);
            }
        }
    }
}