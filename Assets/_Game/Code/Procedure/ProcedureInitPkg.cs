using System;
using Cysharp.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using YooAsset;

namespace MiniGame
{
    public class ProcedureInitPkg : ProcedureBase
    {
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureInitPkg OnEnter");
            InitPkg(procedureOwner).Forget();
        }
        
        private async UniTaskVoid InitPkg(IFsm<IProcedureManager> procedureOwner)
        {
            var initializationOperation = GameEntry.Resource.InitPackage();
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            await initializationOperation.ToUniTask();
            if (initializationOperation.Status == EOperationStatus.Succeed)
            {
                switch (GameEntry.Resource.PlayMode)
                {
                    case EPlayMode.EditorSimulateMode:
                        Log.Info("Editor resource mode detected.");
                        ChangeState<ProcedurePreload>(procedureOwner);
                        break;
                    case EPlayMode.OfflinePlayMode:
                        Log.Info("Package resource mode detected.");
                        ChangeState<ProcedureInitRes>(procedureOwner);
                        break;
                    case EPlayMode.HostPlayMode:
                        Log.Info("Updatable resource mode detected.");
                        ChangeState<ProcedureUpdate>(procedureOwner);
                        break;
                    default:
                        Log.Error("Invalid resource mode. {0}", GameEntry.Resource.PlayMode);
                        break;

                }
            }
            else
            {
                Log.Error($"{initializationOperation.Error}");
            }
        }
    }
}