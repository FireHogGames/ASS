using System;
using System.Speech.Synthesis;

/*
 * Author: Hidde Loman
 * Description: Home based security system
 * License: Apache license 2.0
 */

namespace ASS
{
    class Program
    {
        //Speech dependecies
        SpeechSynthesizer speechEngine = new SpeechSynthesizer();
        bool running = true;
        bool isInit = false;

        public Program()
        {
            SendConsoleMessage("Starting up, please wait...");
            speechEngine.SelectVoiceByHints(VoiceGender.Male);

            //if all the systems are started up without any errors, the program will continue. Otherwise it will crash
            //TODO Add a crash log system to be able to send to the developer(s)
            if (!isInit)
                return;

            //Run an infinite loop
            Run();
        }

        //Constant loop
        private void Run()
        {
            //As long as the running bool is TRUE the program will keep running
            while (running)
            {
                string command = Console.ReadLine();

                //if the user enter terminate in the console the program will exit
                if (command == "terminate")
                {
                    running = false;
                }
            }
        }

        //Needed for speech
        public void Speak(string sentence)
        {
            //This metod is used to let the program do multiple text to speech calculations at the same time
            speechEngine.Speak(sentence);
            Console.WriteLine(sentence);
        }

        public void SendConsoleMessage(string message)
        {
            //This is used for debugging and non speech messages
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
