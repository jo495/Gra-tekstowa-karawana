using System;
using System.IO;
using System.Collections.Generic;

namespace karawana
{
    class Program
    {
        static void Main(string[] args)
        {
            // Modułowe dodawanie scen z wyborami warunkami, efektami i dodatkowymi scenografiami
            List<Scene> scenography = new();
            List<Scene> poolA = new();
            List<Scene> poolB = new();

            Scene randomA = new Scene(1);   //sceny wskaźnikowe, kiedy są w scenografii, ma losować z danej puli
            Scene randomB = new Scene(2);

            Effect zeroe = new Effect();
            Choice zero = new("zero", zeroe);

            //----------

            Effect spiders1e = new(0, 4, 0);
            Choice spiders1 = new("spiders1", spiders1e);
            spiders1.AddCondition(0, 99, 0, 99, 5, 99, 0, 99);

            Effect spiders2e = new(0, 20, 0);
            Choice spiders2 = new("spiders2", spiders2e);

            Choice spiders3 = new("spiders3");
            spiders3.AddCondition(1);

            List<Choice> spidersC = new();
            spidersC.Add(zero);
            spidersC.Add(spiders1);
            spidersC.Add(spiders2);
            spidersC.Add(spiders3);

            Scene spiders = new(false, "spiders", spidersC);

            //----------

            Effect fire1e = new(1, "Ogień odstrasza pająki");
            Choice fire1 = new("fire1", fire1e);

            List<Choice> fireC = new();
            fireC.Add(zero);
            fireC.Add(fire1);

            Scene fire = new(true, "fire", fireC);

            //----------

            List<Scene> scenographyCity = new();
            scenographyCity.Add(randomA);
            scenographyCity.Add(randomA);

            //+++

            List<Scene> scenographyCave = new();

            Effect cave1e = new(94, "W jaskini były wyryte 4 cyfry związane z otwarciem portalu. Ostatnia to 4");
            Choice cave1 = new("next", cave1e);
            List < Choice > caveC = new();
            caveC.Add(zero);
            caveC.Add(cave1);
            Scene cave = new(true, "cave", caveC);

            scenographyCave.Add(cave);

            //+++

            Choice exitCity1 = new("next", zeroe);
            List<Choice> exitCityC = new();
            exitCityC.Add(zero);
            exitCityC.Add(exitCity1);
            Scene exitCity = new(false, "exitCity", exitCityC);
            scenographyCity.Add(exitCity);

            Choice city1 = new("city1", zeroe, scenographyCity);
            Choice city2 = new("city2", zeroe);
            Choice city3 = new("city3", zeroe, scenographyCave);
            city3.AddCondition(5);

            List<Choice> cityC = new();
            cityC.Add(zero);
            cityC.Add(city1);
            cityC.Add(city2);
            cityC.Add(city3);

            Scene city = new(false, "city", cityC);

            //----------

            List<Scene> scenographyGuide = new();

            Effect guide1e = new(3, 0, 0);
            Choice guide1 = new("guide1", guide1e, scenographyGuide);
            guide1.AddCondition(3, 99, 0, 99, 0, 99, 0, 99);

            Choice guide2 = new("guide2", zeroe);

            List<Choice> guideC = new();
            guideC.Add(zero);
            guideC.Add(guide1);
            guideC.Add(guide2);

            Scene guide = new(false, "guide", guideC);

            Effect guideStory1e = new(160, "Usłyszałeś legendę o starożytnym portalu");
            Choice guideStory1 = new("next", guideStory1e);
            List<Choice> guideStoryC = new();
            guideStoryC.Add(zero);
            guideStoryC.Add(guideStory1);
            Scene guideStory = new(true, "guideStory", guideStoryC);

            scenographyGuide.Add(guideStory);

            Effect guideDisappear1e = new();
            Choice guideDisappear1 = new("next",  guideDisappear1e);
            List < Choice >  guideDisappearC = new();
            guideDisappearC.Add(zero);
            guideDisappearC.Add( guideDisappear1);
            Scene guideDisappear = new(false, "guideDisappear",  guideDisappearC);

            scenographyGuide.Add(guideDisappear);

            //----------

            List<Scene> scenographyTribe = new();

            Choice friends1 = new("friends1", zeroe);

            Effect friends2e = new(3, 0, 0, true, 4, "Wiesz już jak chodzić po ciemnym piasku, żeby nie zginąć");
            Choice friends2 = new("friends2", friends2e);
            friends1.AddCondition(3, 99, 0, 99, 0, 99, 0, 99);

            List<Choice> friendsC = new();
            friendsC.Add(zero);
            friendsC.Add(friends1);
            friendsC.Add(friends2);

            Scene friends = new(false, "friends", friendsC);

            scenographyTribe.Add(friends);

            Effect tribe1e = new(0, 2, 0);
            Choice tribe1 = new("tribe1", tribe1e);
            tribe1.AddCondition(0, 99, 0, 99, 7, 99, 0, 99);

            Effect tribe2e = new(0, 20, 0);
            Choice tribe2 = new("tribe2", tribe2e);
            tribe2.AddCondition(0, 99, 0, 99, 0, 6, 0, 99);

            Choice tribe3 = new("tribe3", zeroe, scenographyTribe);
            tribe3.AddCondition(3);

            List<Choice> tribeC = new();
            tribeC.Add(zero);
            tribeC.Add(tribe1);
            tribeC.Add(tribe2);
            tribeC.Add(tribe3);

            Scene tribe = new(false, "tribe", tribeC);

            //----------

            Effect sands1e = new(0, 20, 0);
            Choice sands1 = new("sands1", sands1e);

            Choice sands2 = new("sands2", zeroe);
            sands2.AddCondition(4);

            List<Choice> sandsC = new();
            sandsC.Add(zero);
            sandsC.Add(sands1);
            sandsC.Add(sands2);

            Scene sands = new(false, "sands", sandsC);

            //----------

            Effect crystal1e = new(5, "Ptak pocztowy przyniósł Ci kryształ do otwarcia jaskini");
            Choice crystal1 = new("crystal1", crystal1e);
            crystal1.AddCondition(0, 99, 0, 99, 0, 99, 1, 99);

            Effect crystal2e = new(185, "Na środku ciemnego piasku znajdują się kule do otwarcia jaskini");
            Choice crystal2 = new("crystal2", crystal2e);
            crystal2.AddCondition(0, 99, 0, 99, 0, 99, 0, 0);

            List<Choice> crystalC = new();
            crystalC.Add(zero);
            crystalC.Add(crystal1);
            crystalC.Add(crystal2);

            Scene crystal = new(false, "crystal", crystalC);

            //----------

            Effect madman1e = new(92, "Drugiejestosiemdrugiejestosiem");
            Choice madman1 = new("next", madman1e);

            List<Choice> madmanC = new();
            madmanC.Add(zero);
            madmanC.Add(madman1);

            Scene madman = new(true, "madman", madmanC);

            //----------

            Effect toll1e = new(25, 0, 0);
            Choice toll1 = new("toll1", toll1e);

            Effect toll2e = new(50, 50, 0);
            Choice toll2 = new("toll2", toll2e);
            
            Effect toll3e = new(20, 5, 0);
            Choice toll3 = new("toll3", toll3e);
            toll3.AddCondition(0, 99, 0, 99, 7, 99, 0, 99);

            List<Choice> tollC = new();
            tollC.Add(zero);
            tollC.Add(toll1);
            tollC.Add(toll2);
            tollC.Add(toll3);

            Scene toll = new(false, "toll", tollC);

            //-----------

            List<Scene> scenographyOasis = new();

            Choice exitOasis1 = new("next", zeroe);
            List<Choice> exitOasisC = new();
            exitOasisC.Add(zero);
            exitOasisC.Add(exitOasis1);
            Scene exitOasis = new(false, "exitOasis", exitOasisC);


            Effect oasisHint1e = new(93, "Usłyszałeś że brakuje Ci cyfry 4");
            Choice oasisHint1 = new("next",  oasisHint1e);
            List < Choice >  oasisHintC = new();
            oasisHintC.Add(zero);
            oasisHintC.Add(oasisHint1);
            Scene oasisHint = new(true, "oasisHint",  oasisHintC);

            Effect oasisDance1e = new(3, "Poznałeś taniec wojownika");
            Choice oasisDance1 = new("next", oasisDance1e);
            List<Choice> oasisDanceC = new();
            oasisDanceC.Add(zero);
            oasisDanceC.Add(oasisDance1);
            Scene oasisDance = new(true, "oasisDance", oasisDanceC);


            scenographyOasis.Add(oasisHint);
            scenographyOasis.Add(oasisDance);
            scenographyOasis.Add(randomB);
            scenographyOasis.Add(exitOasis);

            Choice oasis1 = new("oasis1", zeroe, scenographyOasis);
            Choice oasis2 = new("oasis2", zeroe);

            List<Choice> oasisC = new();
            oasisC.Add(zero);
            oasisC.Add(oasis1);
            oasisC.Add(oasis2);

            Scene oasis = new(false, "oasis", oasisC);

            //----------

            //---------- Pula losowa A - miasto


            Effect Aa1e = new(91, "Pierwsza cyfra to 6");
            Choice Aa1 = new("next", Aa1e);

            List<Choice> AaC = new();
            AaC.Add(zero);
            AaC.Add(Aa1);

            Scene Aa = new(true, "Aa", AaC);
            poolA.Add(Aa);

            //----------

            Effect Ab1e = new(-12, 0, 0);
            Choice Ab1 = new("Ab1", Ab1e);
            Ab1.AddCondition(0, 99, 7, 99, 0, 99, 0, 99);

            Effect Ab2e = new(-3, 0, 0);
            Choice Ab2 = new("Ab2", Ab2e);
            Ab2.AddCondition(0, 99, 0, 6, 0, 99, 0, 99);

            Effect Ab3e = new(-20, 0, 0);
            Choice Ab3 = new("Ab3", Ab3e);
            Ab3.AddCondition(2);

            List<Choice> AbC = new();
            AbC.Add(zero);
            AbC.Add(Ab1);
            AbC.Add(Ab2);
            AbC.Add(Ab3);

            Scene Ab = new(false, "Ab", AbC);
            poolA.Add(Ab);

            //----------

            Effect Ac2e = new(1, 0, 0);
            Choice Ac1 = new("Ac1", zeroe);
            Ac1.AddCondition(0, 0, 0, 99, 0, 99, 0, 99);

            Choice Ac2 = new("next", Ac2e);
            Ac2.AddCondition(1, 99, 0, 99, 0, 99, 0, 99);

            List<Choice> AcC = new();
            AcC.Add(zero);
            AcC.Add(Ac1);
            AcC.Add(Ac2);

            Scene Ac = new(false, "Ac", AcC);
            poolA.Add(Ac);

            //----------

            Effect Ad1e = new(2, 0, 0, 2, "Poznałeś imiona kilku mieszkańców miasta");
            Choice Ad1 = new("Ad1", Ad1e);
            Ad1.AddCondition(2, 99, 0, 99, 0, 99, 0, 99);

            Choice Ad2 = new("Ad2", zeroe);

            List<Choice> AdC = new();
            AdC.Add(zero);
            AdC.Add(Ad1);
            AdC.Add(Ad2);

            Scene Ad = new(false, "Ad", AdC);
            poolA.Add(Ad);

            //----------

            //---------- Pula losowa B
            //----------

            //----------

            Effect Ba1e = new(-1, 0, 0);
            Choice Ba1 = new("next", Ba1e);

            List<Choice> BaC = new();
            BaC.Add(zero);
            BaC.Add(Ba1);

            Scene Ba = new(false, "Ba", BaC);
            poolB.Add(Ba);

            //----------

            Effect Bb1e = new(0, 3, 0);
            Choice Bb1 = new("Bb1", Bb1e);

            Effect Bb2e = new(0, 2, 0);
            Choice Bb2 = new("Bb2", Bb2e);

            List<Choice> BbC = new();
            BbC.Add(zero);
            BbC.Add(Bb1);
            BbC.Add(Bb2);

            Scene Bb = new(false, "Bb", BbC);
            poolB.Add(Bb);

            //----------

            Choice Bc2 = new("next", zeroe);

            List<Choice> BcC = new();
            BcC.Add(zero);
            BcC.Add(Bc2);

            Scene Bc = new(false, "Bc", BcC);
            poolB.Add(Bc);

            //----------


            Effect Bd1e = new(6, "Kiedy widzisz na niebie czerwoną łunę, zagwiżdż, a strażnicy ześlą Ci swojego posłańca");
            Choice Bd1 = new("next", Bd1e);

            List<Choice> BdC = new();
            BdC.Add(zero);
            BdC.Add(Bd1);

            Scene Bd = new(true, "Bd", BdC);
            poolB.Add(Bd);

            //----------
            
            Choice Be2 = new("next", zeroe);

            Effect Be1e = new(0, 0, -1);
            Choice Be1 = new("Be1", Be1e);
            Be1.AddCondition(6);

            List<Choice> BeC = new();
            BeC.Add(zero);
            BeC.Add(Be1);
            BeC.Add(Be2);

            Scene Be = new(false, "Be", BeC);
            poolB.Add(Be);

            //-----------

            Choice Bf2 = new("next", zeroe);
            Bf2.AddCondition(0, 99, 0, 99, 0, 99, 0, 0);

            Effect Bf1e = new(-1, 0, 0);
            Choice Bf1 = new("Bf1", Bf1e);
            Bf1.AddCondition(0, 99, 0, 99, 0, 99, 1, 99);

            List<Choice> BfC = new();
            BfC.Add(zero);
            BfC.Add(Bf2);
            BfC.Add(Bf1);

            Scene Bf = new(false, "Bf", BfC);
            poolB.Add(Bf);

            //----------

            scenography.Add(spiders);
            scenography.Add(fire);
            scenography.Add(randomB);
            scenography.Add(city);
            scenography.Add(randomB);
            scenography.Add(guide);
            scenography.Add(tribe);
            scenography.Add(randomB);
            scenography.Add(oasis);
            scenography.Add(sands);
            scenography.Add(crystal);
            scenography.Add(madman);
            scenography.Add(randomB);
            scenography.Add(toll);


            List<List<Scene>> pools = new();
            pools.Add(poolA);
            pools.Add(poolB);

            //Wywołanie gry z maina
            Shop shop = new("ZZshop", 20, 6);
            GenerationEngine genEn = new(scenography, pools);
            HubEngine hubEn = new(genEn, "ZZpoczatek", "ZZmenu", "ZZkoniec", shop, 50, 10);
            hubEn.Start();


            
        }
    }
}
