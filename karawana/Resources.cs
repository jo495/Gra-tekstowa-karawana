using System;
using System.Collections.Generic;

namespace karawana
{
    class Resources
    {
        public int ResourcesNum { get;  set; }
        public int MerchantsNum { get;  set; }
        public int ArmedMerchantsNum { get;  set; }
        public int PostalBirdsNum { get;  set; }
        public List<string> Hints { get; private set; }
        public List<int> HintID { get; private set; }

        public Resources(int resources, int merchants, int postalBirds, int armedMerchantsNum)
        {
            ResourcesNum = resources;
            MerchantsNum = merchants;
            PostalBirdsNum = postalBirds;
            ArmedMerchantsNum = armedMerchantsNum;
            Hints = new();
            HintID = new();
        }

        public Resources(int resources, int merchants, int postalBirds, int armedMerchantsNum, List<int> hintID, List<string> hints)
        {
            ResourcesNum = resources;
            MerchantsNum = merchants;
            PostalBirdsNum = postalBirds;
            ArmedMerchantsNum = armedMerchantsNum;
            Hints = hints;
            HintID = hintID;
        }

        public void Clear()
        {
            ResourcesNum = 0;
            MerchantsNum = 0;
            PostalBirdsNum = 0;
            ArmedMerchantsNum = 0;
        }

        public void AddHint(string hint, int hintID)
        {
            Hints.Add(hint);
            HintID.Add(hintID);
        }

        public void AddEffect(Effect effect)
        {
            if (effect.Hint != null)
            {
                AddHint(effect.Hint, effect.HintID);
            }

            ResourcesNum -= effect.ResourcesDmg;
            if (effect.MerchantsDmg <= MerchantsNum - ArmedMerchantsNum) MerchantsNum -= effect.MerchantsDmg;
            else
            {
                ArmedMerchantsNum -= (effect.MerchantsDmg - (MerchantsNum - ArmedMerchantsNum));
                MerchantsNum -= effect.MerchantsDmg;
            }
            PostalBirdsNum -= effect.PostalBirdDmg;

            if (MerchantsNum < 0) MerchantsNum = 0;
            if (ArmedMerchantsNum < 0) ArmedMerchantsNum = 0;
            if (ResourcesNum < 0) ResourcesNum = 0;
            if (PostalBirdsNum < 0) PostalBirdsNum = 0;

            if (effect.Arm) ArmedMerchantsNum = MerchantsNum;
            

        }

        public void Sum (Resources r)
        {
            ResourcesNum += r.ResourcesNum;
            MerchantsNum += r.MerchantsNum;
            ArmedMerchantsNum += r.ArmedMerchantsNum;
            PostalBirdsNum += r.PostalBirdsNum;
            SumHints(r);
        }

        public void SumHints (Resources r)
        {
            if(r != null)
            {
                Hints = r.Hints;
                HintID = r.HintID;
            }
        }

        public void Subtract (Resources r)
        {
            ResourcesNum -= r.ResourcesNum;
            MerchantsNum -= r.MerchantsNum;
            ArmedMerchantsNum -= r.ArmedMerchantsNum;
            PostalBirdsNum -= r.PostalBirdsNum;
        }
    }
}
