using System;
using System.Collections.Generic;

namespace karawana
{
    class Shop
    {
        public string ShopScPath { get; private set; }
        public int BirdPrice { get; private set; }
        public int ArmPrice { get; private set; }

        public Shop(string shopScPath, int birdPrice, int armPrice)
        {
            ShopScPath = shopScPath;
            BirdPrice = birdPrice;
            ArmPrice = armPrice;
        }
        public Resources GoIn(Resources r)
        {

            Interface.PlayShopWelcome(ShopScPath, BirdPrice, ArmPrice);
            while (true)
            {
                int decision = Interface.GetDecision(2);
                switch (decision)
                {
                    case 0:
                        return r;

                    case 1:
                        if(CheckPrice(BirdPrice, r))
                        {
                            r.ResourcesNum -= BirdPrice;
                            r.PostalBirdsNum++;
                            Interface.Write("Kupiłeś sokoła");
                        }
                        else Interface.Write("Nie masz wystarczających środków");
                        break;

                    case 2:
                        Interface.Write("Ilu kupców potrzebujesz uzbroić? ");
                        int decision2 = Interface.GetDecision(100);
                        if (CheckPrice(decision2 * ArmPrice, r) && CheckMerchants(decision2, r))
                        {
                            r.ResourcesNum -= decision2 * ArmPrice;
                            r.ArmedMerchantsNum += decision2;
                            Interface.Write("Dozbroiłeś kupców");
                        }
                        else Interface.Write("Nie masz tylu kryształów, albo kupców do uzbrojenia.");
                        break;


                }
                Interface.ShowResources(r);
                Interface.PlayShopWelcome(ShopScPath, BirdPrice, ArmPrice);
            }
            
        }

        public bool CheckPrice(int price, Resources r)
        {
            if (r.ResourcesNum >= price) return true;
            else return false;
        }

        public bool CheckMerchants (int n, Resources r)
        {
            if (n <= r.MerchantsNum - r.ArmedMerchantsNum) return true;
            else return false;
        }
    }
}
