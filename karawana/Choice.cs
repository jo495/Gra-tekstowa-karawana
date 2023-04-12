using System;
using System.Collections.Generic;

namespace karawana
{
    class Choice
    {
        private Condition condition;
        public Effect Effect { get; private set; }
        public string Path { get; private set; }
        public string Text { get; private set; }
        public List<Scene> Scenography { get; private set; }

        public Choice(string path)
        {
            Path = path;
            Effect = new Effect();
            Scenography = null;
        }
        public Choice(string path, Effect effect)
        {
            Path = path;
            Effect = effect;
            Scenography = null;
        }

        public Choice(string path, Effect effect, List<Scene> scenography)
        {
            Path = path;
            Effect = effect;
            Scenography = scenography;
        }

        public void AddCondition(int minResources, int maxResources, int minMerchants, int maxMerchants, int minArmedMerchants, int maxArmedMerchants,
                int minPostalBirds, int maxPostalBirds, int hintID)
        {
            condition = new(minResources, maxResources, minMerchants, maxMerchants, minArmedMerchants, maxArmedMerchants,
                minPostalBirds, maxPostalBirds, hintID);
        }

        public void AddCondition(int minResources, int maxResources, int minMerchants, int maxMerchants, int minArmedMerchants, int maxArmedMerchants,
                int minPostalBirds, int maxPostalBirds)
        {
            condition = new(minResources, maxResources, minMerchants, maxMerchants, minArmedMerchants, maxArmedMerchants,
                minPostalBirds, maxPostalBirds, -1);
        }

        public void AddCondition(int hintID)
        {
            condition = new(0, 1000, 0, 1000, 0, 1000, 0, 1000, hintID);
        }

        public bool CheckCondition(Resources resources)
        {
            if (condition == null) return true;
            else return condition.CheckCondition(resources);
        }

        
    }
}
