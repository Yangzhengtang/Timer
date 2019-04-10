using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace count_down_test_1
{
    class SoundConfigure
    {
        public string ConfigurePath { get; set; } 
        public string DefaultSoundPath { get; set; }
        // public List<string> SoundPathList { get; set; }
         public List<string> SoundPathList = new List<string>();
        public int DefaultSoundPointer { get; set; }

        public SoundConfigure()
        {
            this.ConfigurePath = System.Environment.CurrentDirectory + "\\SoundConfigure.json";
            // this.SoundPathList = new List<string>();
        }

        public void load()
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
                this.ConfigurePath = tc.ConfigurePath;
                this.DefaultSoundPath = tc.DefaultSoundPath;
                this.DefaultSoundPointer = tc.DefaultSoundPointer;
                this.SoundPathList = tc.SoundPathList;
               // this.DefaultSoundPointer = 0; for test
                this.DefaultSoundPath = SoundPathList[this.DefaultSoundPointer];
                Console.WriteLine("Copy done");
                Console.WriteLine(json);
                //sr.Close();
            }
        }
        public void ChooseSound()
        {
           
        }

        public void AddSound()
        {

        }

        //public void init()
        //{
        //    this.SoundPathList.Add("C:\\Users\\lenovo\\Desktop\\count_down_test_1\\count_down_test_1\\bin\\Release\\joy.mp3");
            
        //}
        public void dump()
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

        public void ChangePointer(int NewPointer)
        {
            this.DefaultSoundPointer = NewPointer;
            this.DefaultSoundPath = this.SoundPathList[NewPointer];
            this.dump();
        }

    }
}
