using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace MiniGame
{
    public class GameEntry : MonoBehaviour
    {
        public static BaseComponent Base { get; private set; }

        public static DebuggerComponent Debugger { get; private set; }

        public static EventComponent Event { get; private set; }

        public static FsmComponent Fsm { get; private set; }

        public static NetworkComponent Network { get; private set; }

        public static ProcedureComponent Procedure { get; private set; }

        public static SceneComponent Scene { get; private set; }

        public static UIComponent UI { get; private set; }

        public static WebRequestComponent WebRequest { get; private set; }

        public static ResourceComponent Resource { get; private set; }
        public static SettingComponent Setting { get; private set; }
        public static LocalizationComponent Localization { get; private set; }

        private static void InitBuiltinComponents()
        {
            Base = UnityGameFramework.Runtime.GameEntry.GetComponent<BaseComponent>();
            Debugger = UnityGameFramework.Runtime.GameEntry.GetComponent<DebuggerComponent>();
            Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
            Fsm = UnityGameFramework.Runtime.GameEntry.GetComponent<FsmComponent>();
            Network = UnityGameFramework.Runtime.GameEntry.GetComponent<NetworkComponent>();
            Procedure = UnityGameFramework.Runtime.GameEntry.GetComponent<ProcedureComponent>();
            Scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
            UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
            WebRequest = UnityGameFramework.Runtime.GameEntry.GetComponent<WebRequestComponent>();
            Resource = UnityGameFramework.Runtime.GameEntry.GetComponent<ResourceComponent>();
            Setting = UnityGameFramework.Runtime.GameEntry.GetComponent<SettingComponent>();
            Localization = UnityGameFramework.Runtime.GameEntry.GetComponent<LocalizationComponent>();
        }

        private void Start()
        {
            InitBuiltinComponents();
        }
    }
}