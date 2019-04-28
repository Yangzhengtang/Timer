using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MultiTimer
{
    public class Sound
    {
        [DllImport("winmm.dll", SetLastError = true)]//import winmm.dll to play music using Windows APIs
        public static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern long mciSendString(string strCommand,
                StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        public static extern long sndPlaySound(string lpszSoundName, long uFlags);

        [Flags]
        public enum SoundFlags//list all supported formats of sound source files
        {
            /// <summary>play synchronously (default)</summary>
            SND_SYNC = 0x0000,
            /// <summary>play asynchronously</summary>
            SND_ASYNC = 0x0001,
            /// <summary>silence (!default) if sound not found</summary>
            SND_NODEFAULT = 0x0002,
            /// <summary>pszSound points to a memory file</summary>
            SND_MEMORY = 0x0004,
            /// <summary>loop the sound until next sndPlaySound</summary>
            SND_LOOP = 0x0008,
            /// <summary>don’t stop any currently playing sound</summary>
            SND_NOSTOP = 0x0010,
            /// <summary>Stop Playing Wave</summary>
            SND_PURGE = 0x40,
            /// <summary>don’t wait if the driver is busy</summary>
            SND_NOWAIT = 0x00002000,
            /// <summary>name is a registry alias</summary>
            SND_ALIAS = 0x00010000,
            /// <summary>alias is a predefined id</summary>
            SND_ALIAS_ID = 0x00110000,
            /// <summary>name is file name</summary>
            SND_FILENAME = 0x00020000,
            /// <summary>name is resource name or atom</summary>
            SND_RESOURCE = 0x00040004
        }

        public string SoundPath;//the path of sound file to be played
        public Sound(string path)//instance a Sound object with a user input sound path
        {
            SoundPath = path;
        }


        public void ChangePath(string NewPath)// change the SoundPath based on user input
        {
            SoundPath = NewPath;
        }

        public Sound()// instance a Sound object with the defalut sound path
        {
            SoundPath = System.Environment.CurrentDirectory + "\\beep.mp3";
        }

        public static bool Play(string strFileName)//play the sound of the giving sound path
        {
            return PlaySound(strFileName, UIntPtr.Zero,
                    (uint)(SoundFlags.SND_FILENAME | SoundFlags.SND_SYNC | SoundFlags.SND_NOSTOP));
        }

        public void mciPlay()//play the sound according to the SoundPath, which is the most stable function
        {
            string playCommand = "open " + this.SoundPath + " alias MyWav"; //change the name of sound, all types can be played
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            mciSendString("set MyWav time format ms", null, 0, IntPtr.Zero);
            mciSendString("seek MyWav to 0", null, 0, IntPtr.Zero);
            mciSendString("play MyWav", null, 0, IntPtr.Zero);

        }

        public void mciPlay(string strFileName)//play the sound according to the given sound path, which is the most stable function
        {
            this.SoundPath = strFileName;
            string playCommand = "open " + strFileName + " alias MyWav"; //all types can be played
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            mciSendString("set MyWav time format ms", null, 0, IntPtr.Zero);
            mciSendString("seek MyWav to 0", null, 0, IntPtr.Zero);
            mciSendString("play MyWav", null, 0, IntPtr.Zero);

        }
        public void mciStop()// pause the current sound
        {
            mciSendString("stop MyWav", null, 0, new IntPtr(0));
        }
        public static void sndPlay(string strFileName)//play the sound of the giving sound path
        {
            sndPlaySound(strFileName, (long)SoundFlags.SND_SYNC);
        }
        public void mciClose() //close the current sound
        {
            mciSendString("close MyWav", null, 0, new IntPtr(0));
        }
    }


    
}

