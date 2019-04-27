﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MultiTimer
{
    public class Sound
    {
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern long mciSendString(string strCommand,
                StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        public static extern long sndPlaySound(string lpszSoundName, long uFlags);

        [Flags]
        public enum SoundFlags
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

        public string SoundPath;
        public Sound(string path)
        {
            SoundPath = path;
        }


        public void ChangePath(string NewPath)
        {
            SoundPath = NewPath;
        }

        public Sound()
        {
            SoundPath = System.Environment.CurrentDirectory + "\\beep.mp3";
        }

        public static bool Play(string strFileName)
        {
            return PlaySound(strFileName, UIntPtr.Zero,
                    (uint)(SoundFlags.SND_FILENAME | SoundFlags.SND_SYNC | SoundFlags.SND_NOSTOP));
        }

        public void mciPlay()
        {
            string playCommand = "open " + this.SoundPath + " alias MyWav"; //all types can be played
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            mciSendString("set MyWav time format ms", null, 0, IntPtr.Zero);
            mciSendString("seek MyWav to 0", null, 0, IntPtr.Zero);
            mciSendString("play MyWav", null, 0, IntPtr.Zero);

        }

        public void mciPlay(string strFileName)
        {
            this.SoundPath = strFileName;
            string playCommand = "open " + strFileName + " alias MyWav"; //all types can be played
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            mciSendString("set MyWav time format ms", null, 0, IntPtr.Zero);
            mciSendString("seek MyWav to 0", null, 0, IntPtr.Zero);
            mciSendString("play MyWav", null, 0, IntPtr.Zero);

        }
        public void mciStop()
        {
            mciSendString("stop MyWav", null, 0, new IntPtr(0));
        }
        public static void sndPlay(string strFileName)
        {
            sndPlaySound(strFileName, (long)SoundFlags.SND_SYNC);
        }
        public void mciClose()
        {
            mciSendString("close MyWav", null, 0, new IntPtr(0));
        }
    }


    /* example of change bgm

          this.sound.mciPlay();
          System.Threading.Thread.Sleep(1000);
          this.sound.mciStop();
          this.sound.mciClose();
          System.Threading.Thread.Sleep(1000);
          Application.DoEvents(); //thread窗口无法显示
          SoundConfigure soundConfigure = new SoundConfigure();
          soundConfigure.load();
          //this.label1.Text = showWords;
          //string PathOfSound;
          //soundConfigure.init();
          soundConfigure.dump();
          sound.ChangePath(soundConfigure.DefaultSoundPath);
          Console.WriteLine(soundConfigure.DefaultSoundPath);
          Console.WriteLine(sound.SoundPath);
          sound.mciPlay(sound.SoundPath);
     */
}

