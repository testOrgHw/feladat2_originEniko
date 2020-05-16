using System;
using System.Collections.Generic;
using System.Text;

namespace ModernLangToolsApp
{
    public class JediCouncil
    {
        public event CouncilChangedDelegate CouncilChanged;

        private List<Jedi> members = new List<Jedi>();

        public void Add(Jedi newJedi)
        {
            //A generikus lista Add függvényét használja
            members.Add(newJedi);
            if (CouncilChanged != null)
            {
                CouncilChanged("Új taggal bővültünk");
            }
        }

        public void Remove()
        {
            // Eltávolítja a lista utolsó elemét
            members.RemoveAt(members.Count - 1);
            if (CouncilChanged != null)
            {
                if (members.Count > 0)
                {
                    CouncilChanged("Zavart érzek az erőben");
                }
                else
                    CouncilChanged("A tanács elesett!");
            }
        }

        //A delegate-hez tartozó részekehez a laboranyagot és a mintát használtam fel.
        public delegate void CouncilChangedDelegate(string message);


        //A GetBeginner FindAll-hoz tarozó segédfüggvénye. Kiválasztja azokat a Jediket amiknek 300-nál alacsonyabb a midichlorian szintje.
        static bool Beginner(Jedi j)
        {
            if (j.MidiChlorianCount < 300)
                return true;
            else
                return false;
        }

        //Egy olyan listával tér vissza, aminek Jedik az elemei és a midichlorian szintjük alacsonyabb mint 300.
        public List<Jedi> GetBeginners()
        {
            List<Jedi> list = new List<Jedi>();
            list = members.FindAll(Beginner);
            return list;
        }
    }
}
