using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace MultiTimer
{
    class SoundConfigure
    {
        public string ConfigurePath { get; set; } // the path of SoundConfigure.json
        public string DefaultSoundPath { get; set; }// the sound path to be played
         public List<string> SoundPathList = new List<string>();//all registered path of sounds
        public int DefaultSoundPointer { get; set; }// a num point to the DefaultSoundPath in the SoundPathList

        // public List<string> SoundPathList { get; set; }
        public SoundConfigure()//instance a SoundConfigure object with the ConfigurePath
        {
            this.ConfigurePath = System.Environment.CurrentDirectory + "\\SoundConfigure.json";
            // this.SoundPathList = new List<string>();
        }

        public void load()// load configure from SoundConfigure.json
        {
           this. ConfigurePath = System.Environment.CurrentDirectory + "\\SoundConfigure.json";
            string json;
            using (StreamReader sr = new StreamReader(ConfigurePath))
            {
              
                SoundConfigure tc = new SoundConfigure();
                json = sr.ReadToEnd();
                Console.WriteLine("Read configure done.");
                tc = JsonConvert.DeserializeObject<SoundConfigure>(json);
                Console.WriteLine("Copying....");
               // this.ConfigurePath = tc.ConfigurePath;
                this.DefaultSoundPath = tc.DefaultSoundPath;
                this.DefaultSoundPointer = tc.DefaultSoundPointer;
                this.SoundPathList = tc.SoundPathList;
               // this.DefaultSoundPointer = 0; for test
                this.DefaultSoundPath = System.Environment.CurrentDirectory + "\\" + SoundPathList[this.DefaultSoundPointer];
                Console.WriteLine("Copy done");
                Console.WriteLine(json);
                //sr.Close();
            }
        }
 
        public void dump()// save current configure to SoundConfigure.json
        {
            string json = JsonConvert.SerializeObject(this);
            //Console.WriteLine("Adding sound...");
            Console.WriteLine(json);
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ConfigurePath))
            {
                sw.Write(json);
                //sw.Close();
                
            }
        }

        public void ChangePointer(int NewPointer) //chang the DefaultSoundPointer according to the user input
        {
            this.DefaultSoundPointer = NewPointer;
            this.DefaultSoundPath = System.Environment.CurrentDirectory + "\\" + this.SoundPathList[NewPointer];
            this.dump();
        }

    }
}
