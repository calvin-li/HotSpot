using System;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.Networking.NetworkOperators;

namespace HotSpot
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var profile = NetworkInformation.GetInternetConnectionProfile();
                var tetheringManager = NetworkOperatorTetheringManager.CreateFromConnectionProfile(profile);
                if (tetheringManager.TetheringOperationalState == TetheringOperationalState.Off)
                {
                    TurnOnHotSpot(tetheringManager).Wait();
                }
                System.Threading.Thread.Sleep(5000);
            }

            return;
        }

        private static async Task TurnOnHotSpot(NetworkOperatorTetheringManager tetheringManager)
        {
            await tetheringManager.StartTetheringAsync();
        }
    }
}
