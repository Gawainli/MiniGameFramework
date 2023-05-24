using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework.Localization;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using YooAsset;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace MiniGame
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected internal override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Debug.Log("ProcedureLaunch OnEnter");
            InitLanguageSettings();
        }

        protected internal override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }

        protected internal override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected internal override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected internal override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
        
        private void InitLanguageSettings()
        {
            if (GameEntry.Resource.PlayMode == EPlayMode.EditorSimulateMode && GameEntry.Base.EditorLanguage != Language.Unspecified)
            {
                return;
            }

            Language lang = GameEntry.Localization.Language;
            if (GameEntry.Setting.HasSetting(Constant.Setting.Language))
            {
                try
                {
                    var langStr = GameEntry.Setting.GetString(Constant.Setting.Language);
                    lang = (Language) Enum.Parse(typeof(Language), langStr);
                }
                catch (Exception e)
                {
                    Log.Error("Init language error, reason {0}",e.ToString());
                }
            }

            if (lang != Language.English && lang != Language.ChineseSimplified && lang != Language.ChineseTraditional && lang != Language.Korean)
            {
                lang = Language.English;
                GameEntry.Setting.SetString(Constant.Setting.Language, lang.ToString());
                GameEntry.Setting.Save();
            }
            
            GameEntry.Localization.Language = lang;
            Log.Info("Init language settings complete, current language is '{0}'.", lang.ToString());
        }
    }
}