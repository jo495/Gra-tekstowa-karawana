using System;
using System.Collections.Generic;


namespace karawana
{
    class Condition
    {
        public int MinResources { get; private set; }
        public int MaxResources { get; private set; }
        public int MinMerchants { get; private set; }
        public int MaxMerchants { get; private set; }
        public int MinArmedMerchants { get; private set; }
        public int MaxArmedMerchants { get; private set; }
        public int MinPostalBirds { get; private set; }
        public int MaxPostalBirds { get; private set; }
        public int HintID { get; private set; }
        
        public Condition(int minResources, int maxResources, int minMerchants, int maxMerchants, int minArmedMerchants, int maxArmedMerchants,
            int minPostalBirds, int maxPostalBirds, int hintID)
        {
            MinResources = minResources;
            MaxResources = maxResources;
            MinMerchants = minMerchants;
            MaxMerchants = maxMerchants;
            MinArmedMerchants = minArmedMerchants;
            MaxArmedMerchants = maxArmedMerchants;
            MinPostalBirds = minPostalBirds;
            MaxPostalBirds = maxPostalBirds;
            HintID = hintID;
        }


        public Condition(int hintID)
        {
            MinResources = 0;
            MaxResources = 60;
            MinMerchants = 0;
            MaxMerchants = 60;
            MinArmedMerchants = 0;
            MaxArmedMerchants = 60;
            MinPostalBirds = 0;
            MaxPostalBirds = 60;
            HintID = hintID;

        }

        public Condition()
        {
            MinResources = 0;
            MaxResources = 60;
            MinMerchants = 0;
            MaxMerchants = 60;
            MinArmedMerchants = 0;
            MaxArmedMerchants = 60;
            MinPostalBirds = 0;
            MaxPostalBirds = 60;
            HintID = -1;
        }

        public bool CheckCondition(Resources r)
        {
            if (r.ResourcesNum >= MinResources & r.ResourcesNum <= MaxResources & r.MerchantsNum >= MinMerchants & r.MerchantsNum <= MaxMerchants
                & r.ArmedMerchantsNum >= MinArmedMerchants & r.ArmedMerchantsNum <= MaxArmedMerchants & r.PostalBirdsNum >= MinPostalBirds
                & r.PostalBirdsNum <= MaxPostalBirds & (HintID == -1 || r.HintID.Contains(HintID))) return true;

            else return false;
        }
    }
}
