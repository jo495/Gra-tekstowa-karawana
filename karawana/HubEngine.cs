using System;
using System.IO;
using System.Collections.Generic;


namespace karawana
{
    class HubEngine
    {
        //Hub Engine odpowiada za menu w pętli i za obsługę zasobów przy rozpoczynaniu i kończeniu wyprawy. Wywołuje też rozpoczęcie wyprawy

        int startResNum;
        int startMerNum;
        public GenerationEngine GenEn { get; private set; }
        public Resources ResInHub { get; private set; }
        public Resources ResSent { get; private set; }
        public Resources ResDelivered { get; private set; }
        public string BegginningScPath { get; private set; }
        public string MenuScPath { get; private set; }
        public string EndScPath { get; private set; }
        public Shop Shop { get; private set; }


        public HubEngine(GenerationEngine genEn, string begginningScPath, string menuScPath, string endScPath, Shop shop, int startResourcesNum, int startMerchantsNum)
        {
            startMerNum = startMerchantsNum;
            startResNum = startResourcesNum;
            GenEn = genEn;
            ResInHub = new(startResNum, startMerNum, 0, 0);
            ResDelivered = new(0, 0, 0, 0);
            BegginningScPath = begginningScPath;
            MenuScPath = menuScPath;
            EndScPath = endScPath;
            Shop = shop;
        }

        public void Start()
        {
            Interface.WriteFile(BegginningScPath);
            Hub();
        }
        public void Hub()
        {
            if (ResInHub.ResourcesNum == 0)
            {
                Interface.Results(ResDelivered);
            }
            while (true)
            {
                if (ResInHub.HintID.Contains(93) & ResInHub.HintID.Contains(91) & ResInHub.HintID.Contains(92) & ResInHub.HintID.Contains(94))
                {
                    Interface.Write("[0] Wiesz, że w wieży istnieje portal i znasz wszystkie cyfry do jego otwarcia. Zrób to.");
                    Interface.GetDecision(0);
                    Interface.Write(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"scenes\", EndScPath + ".txt")));
                    Environment.Exit(0);
                }
                int decision = Interface.PlayHubOptions(MenuScPath);
                switch (decision)
                {
                    case 0:
                        HubReset();
                        break;

                    case 1:
                        Interface.ShowResources(ResInHub);
                        break;

                    case 2:
                        Interface.ShowResources(ResDelivered);
                        break;

                    case 3:
                        Interface.ShowHints(ResInHub);
                        break;

                    case 4:
                        Shop.GoIn(ResInHub);
                        break;

                    case 5:
                        StartAdventure();
                        break;

                }
            }
        }
        public void StartAdventure()
        {
            var resToSend = Interface.PackResources(ResInHub);
            int armedMerchantsToSend;
            if (resToSend["Merchants"] <= ResInHub.ArmedMerchantsNum) armedMerchantsToSend = resToSend["Merchants"];
            else armedMerchantsToSend = ResInHub.ArmedMerchantsNum;
            if (resToSend["Merchants"] != 0)
            {
                Resources ResSent = new Resources(resToSend["Resources"], resToSend["Merchants"], ResInHub.PostalBirdsNum, armedMerchantsToSend, ResInHub.HintID, ResInHub.Hints);
                GenEn.AddResources(ResSent);
                ResInHub.Subtract(ResSent);
                GenEn.PlayScenography(this);
                if (ResSent.MerchantsNum == 0 & ResSent.ArmedMerchantsNum == 0 & ResSent.ResourcesNum == 0 & ResSent.PostalBirdsNum == 0) ResInHub.SumHints(ResSent);   //wszystkie zasoby przepadły, do huba wracają tylko wskazówki
                else //część zasobów dotarła, trzeba je dodać do wyniku
                {
                    Interface.Write("Udało Ci się dostarczyć część zasobów do miasta \n");
                    ResDelivered.Sum(ResSent);
                };
            }
            else Interface.Write("A przynajmniej tak by się stało, bo aby rozpocząć wyprawę, musisz wysłać co najmniej jednego kupca! \n");
            ResSent = new(0, 0, 0, 0);
            Hub();
        }

        public void HubReset() //cofnięcie czasu
        {
            ResInHub = new(startResNum, startMerNum, 0, 0);
            ResInHub.SumHints(GenEn.Resources);
            ResSent = new(0, 0, 0, 0);
            ResDelivered.Clear();
            Hub();
        }

    }
}
