using System;
using System.Collections.Generic;
namespace HIHead
{
    /// <summary cref="http://singleton-skeleton.html">
    /// Singleton Wrap(DO NOT ABUSE) 
    /// </summary>
    public class Singleton<T> where T : new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }
    }
    /// <summary cref="http://managerinterface.html">
    /// Inteface nested/simple manager with additional functionality
    /// </summary> 
    public interface IManager
    {
        object GetManager();
        void DoTask(Task task);
        void DoTask();
    }
    public delegate void Task();
    /// <summary cref="http://manager.html">
    /// Abstract manager  
    /// </summary> 
    public abstract class Manager : IManager
    {
        public Task ManagerTask { get; set; }
        public object GetManager()
        {
            return this;
        }
        public void DoTask()
        {
            ManagerTask.Invoke();
        }
        public void DoTask(Task task)
        {
            task.Invoke();
        }
    }
    public enum EnumState
    {
        Init,
        Mainmenu,
        Options,
        Restart,
        MainProcess,
        Paused,
        End
    }
    /// <summary cref="http://app-state.html">
    /// Automat to change appstates 
    /// </summary>
    public class AppState
    {
       
        protected EnumState State;
        public AppState()
        {
            SetState(EnumState.Init);
        }
        public EnumState GetApplication()
        {
            return State;
        }
        /// <summary cref="http://app-state.html">
        /// Push State 
        /// </summary>
        public virtual void SetState(EnumState appState)
        {
            State = appState;
            CheckState();
        }
        /// <summary cref="http://app-state.html">
        /// Check and run 
        /// </summary>
        public virtual void CheckState()
        {
            switch (State)
            {
                case EnumState.Init:
                    {
                        break;
                    }
                case EnumState.MainProcess:
                    {
                        break;
                    }
                case EnumState.Mainmenu:
                    {

                        break;
                    }
                case EnumState.Paused:
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
    /// <summary cref="http://singleton-skeleton.html">
    /// TopManager the one and only!  
    /// </summary>
    public class AppManager : Singleton<AppManager>
    {
        private static AppState _appstate;
        public void SetStateAutomat(AppState appstate)
        {
            _appstate = appstate;
        }
        public AppState StateControl { get { return _appstate; } }
        public List<IManager> managers = new List<IManager>();
        public void Begin()
        {
            if (_appstate == null)
            {
                throw new Exception("State Invalid");
            }
            else
            {
                _appstate.CheckState();
            }
        }
    }
    /// <summary cref="http://singleton-skeleton.html">
    /// Settings for list of managers. 
    /// </summary>
    public struct AppManagersSettings
    {
        private List<IManager> _managers;
        private bool _isSecurity;
        public List<IManager> ManagerList
        {
            get
            {
                return _managers;
            }
        }
        private string _password;
        public AppManagersSettings(List<IManager> imanli, bool isSec, string pass = "")
        {
            _managers = imanli;
            _isSecurity = isSec;
            _password = pass;
        }
        public bool CheckSecurity(string pass)
        {
            if (_isSecurity && pass != _password)
            {
                throw new Exception("Security Error");
            }
            else
                return true;
        }
    }
    public abstract class StartupManager
    {
        private string _key;
        protected AppManagersSettings _ams;
        public StartupManager(string key, AppManagersSettings ams)
        {
            _key = key;
            _ams = ams;
            _ams.CheckSecurity(key);
        }
        public virtual void Start()
        {
            AppManager.Instance.SetStateAutomat(new AppState());
            foreach(IManager im in _ams.ManagerList)
            AppManager.Instance.managers.Add(im);
            AppManager.Instance.Begin();
        }
    }
}

