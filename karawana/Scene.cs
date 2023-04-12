using System;
using System.Collections.Generic;

namespace karawana
{
    class Scene
    {

        public bool IsUsed { get; set; }
        public bool IsOneTime { get; set; }
        public int TypeNum { get; private set; }
        /*
         * Numer typu
         * 0 - zwyczajna scena z ewentualnymi warunkami, efektami lub podscenografią
         * następne indeksy oznaczają nr puli losowej, a te sceny są tylko wskaźnikami, żeby losować z danej puli
         */
        public int Range { get; private set; }
        public string Path { get; set; }
        public List<Scene> Scenography { get; private set; }
        public List<Choice> Choices { get; private set; }
        public List<Choice> BegginningChoices { get; private set; }

        public Scene(bool isOneTime, string path, List<Choice> choices)
        {
            IsUsed = false;
            Choices = choices;
            BegginningChoices = choices;
            if (Choices == null) Range = 0;
            else Range = Choices.Count-1;
            TypeNum = 0;
            Path = path;
            IsOneTime = isOneTime;

        }

        public Scene(int typeNum)
        {
            TypeNum = typeNum;
            IsOneTime = false;
        }

        public void Play(Resources resources, HubEngine hubEn)
        {
            List<Choice> choicesToPlay = new();
            for (int i = 0; i <= Range; i++)
            {
                if (Choices[i].CheckCondition(resources) == true) choicesToPlay.Add(Choices[i]);
            }
            int decision = Interface.Play(choicesToPlay, choicesToPlay.Count, Path);
            if (decision == -1) return;
            if (decision == 0) hubEn.HubReset();
            var choice = choicesToPlay[decision];

            resources.AddEffect(choice.Effect);
            Scenography = choice.Scenography;
            if (IsOneTime) IsUsed = true;
            Interface.ShowChoiceEffect(choice.Effect, resources);
        }
    }
}
