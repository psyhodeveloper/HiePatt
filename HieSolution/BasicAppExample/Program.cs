using System;
using System.Collections.Generic;
using HIHead;
using ConsoleUI;
namespace BasicAppExample
{
    class BasicAppStartup : StartupManager
    {
        public BasicAppStartup(string key, AppManagersSettings ams) : base(key, ams)
        {

        }
        public override void Start()
        {
            AppManager.Instance.SetStateAutomat(new BasicApp());
            foreach (IManager im in _ams.ManagerList)
                AppManager.Instance.managers.Add(im);
        }
    }
    class BasicApp : AppState
    {
        public override void CheckState()
        {
            switch (State)
            {
                case EnumState.Init:
                    {
                        ConsoleManager.CreateStatusBorder(10, "Init Complete");
                        break;
                    }
                case EnumState.MainProcess:
                    {
                        break;
                    }
                case EnumState.Mainmenu:
                    {
                        ConsoleManager.CreateMenu(new string[] { "MainProcess", "Options" });
                        break;
                    }
                case EnumState.Paused:
                    {
                        break;
                    }
                case EnumState.Options:
                    {
                        break;
                    }
                case EnumState.End:
                    {
                        break;
                    }
                case EnumState.Restart:
                    {
                        break;
                    }
            }
        }
    }
    class BasicManager : Manager
    {
        public void SystemReport()
        {
            Console.WriteLine("<SystemReport...>");
            Console.WriteLine("Managers count:" + AppManager.Instance.managers.Count);
            Console.WriteLine("</SystemReport...>");
            AppManager.Instance.StateControl.SetState(EnumState.Mainmenu);
            Console.WriteLine("State control: " + AppManager.Instance.StateControl.GetApplication());
        }
    }
    class Program
    {
        private const int BASIC_MAN = 0;
        static void Main(string[] args)
        {
            List<IManager> setlist = new List<IManager>();
            setlist.Add(new BasicManager());
            AppManagersSettings ams = new AppManagersSettings(setlist, false);
            BasicAppStartup bas = new BasicAppStartup("", ams);
            bas.Start();
            ((BasicManager)AppManager.Instance.managers[BASIC_MAN].GetManager()).SystemReport();
            Console.ReadLine();
        }
    }
}
