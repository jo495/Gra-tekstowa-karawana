using System;
using System.Collections.Generic;

namespace karawana
{
    class GenerationEngine
    {
        //GenerationEngine odpowiada za odczytywanie scenografii, w tym tych zagnieżdżonych i losowanie scen z pul w konkretnych momentach
        public GenerationEngine Father { get; private set; } //zastosowanie elemantów drzewa do mechanizmu zagnieżdżania scenografii
        public List<Scene> Scenography { get; private set; }
        public List<List<Scene>> Pools { get; private set; }
        public HubEngine HubEn { get; private set; }
        public Resources Resources { get; set; }
        public GenerationEngine(List<Scene> scenography, List<List<Scene>> pools)
        {
            Scenography = scenography;
            Pools = pools;
        }
        public void AddResources(Resources resources)
        {
            Resources = resources;
        }

        public void PlayScenography(HubEngine hubEn)
        {
            HubEn = hubEn;
            for (int i = 0; i <= Scenography.Count-1; i++)
            {
                Scene scene = Scenography[i];
                if (scene.IsUsed) continue;
                int sceneType = scene.TypeNum;
                if (sceneType == 0) StartScene(scene);
                else
                {
                    Random rnd = new Random();
                    int number = rnd.Next(0, Pools[sceneType-1].Count);
                    scene = Pools[sceneType - 1][number];
                    if (scene.IsUsed) continue;
                    StartScene(scene);
                }

                if (Resources.MerchantsNum <= 0) //zginąłeś
                {
                    Interface.Write("Wszyscy z kupców, których wysłałeś zginęli, a paczki, które mieli przy sobie przepadły w piasku");
                    Resources.Clear();
                    return;
                }
            }

            if (Father != null) Father.Resources = Resources;

        }

        public void StartScene(Scene scene)
        {
            scene.Play(Resources, HubEn);
            if (scene.Scenography != null)
            {
                GenerationEngine tempGenEN = new(scene.Scenography, Pools);
                tempGenEN.Father = this;
                tempGenEN.AddResources(Resources);
                tempGenEN.PlayScenography(HubEn);
            }
        }

        
        
    }
}
