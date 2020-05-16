using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{   //Xml serializálás, mint a laboron 
    [XmlRoot("Jedi")]
    public class Jedi
    {
        [XmlAttribute("Nev")]
        public String Name { get; set; }
               
        private int midiChlorianCount;

        //A MidiChlorianCount tagváltozóhoz tartozó setter és getter. Ha a szint 10 vagy alacsonyabb akkor hibát dob.
        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianCount
        {
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("You are not a true jedi!");
                }
                midiChlorianCount = value;
            }
            get { return midiChlorianCount; }
        }


        
    }

}
