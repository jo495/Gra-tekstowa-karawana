using System;
using System.Collections.Generic;

namespace karawana
{
    class Effect
    {
        public int ResourcesDmg { get; private set; }
        public int MerchantsDmg { get; private set; }
        public int PostalBirdDmg { get; private set; }
        public bool Arm { get; private set; }
        public string Hint { get; private set; }
        public int HintID { get; private set; }

        public Effect(int resourcesDmg, int merchantsDmg, int postalBirdDmg)
        {
            ResourcesDmg = resourcesDmg;
            MerchantsDmg = merchantsDmg;
            PostalBirdDmg = postalBirdDmg;
            Hint = null;
        }
        public Effect(int resourcesDmg, int merchantsDmg, int postalBirdDmg, int hintId, string hint)
        {
            ResourcesDmg = resourcesDmg;
            MerchantsDmg = merchantsDmg;
            PostalBirdDmg = postalBirdDmg;
            Hint = hint;
            HintID = hintId;
        }

        public Effect(int resourcesDmg, int merchantsDmg, int postalBirdDmg, bool arm, int hintId, string hint)
        {
            ResourcesDmg = resourcesDmg;
            MerchantsDmg = merchantsDmg;
            PostalBirdDmg = postalBirdDmg;
            Hint = null;
            Arm = arm;
            Hint = hint;
            HintID = hintId;
        }

        public Effect(int hintId, string hint)
        {
            ResourcesDmg = 0;
            MerchantsDmg = 0;
            PostalBirdDmg = 0;
            Hint = hint;
            HintID = hintId;
        }

        public Effect()
        {
            ResourcesDmg = 0;
            MerchantsDmg = 0;
            PostalBirdDmg = 0;
            Hint = null;
        }
    }
}
