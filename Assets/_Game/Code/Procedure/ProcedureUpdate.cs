using System;
using Cysharp.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using YooAsset;

namespace MiniGame
{
    public class ProcedureUpdate : ProcedureBase
    {
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureUpdate OnEnter");
            GetVersion().Forget();
        }

        private async UniTaskVoid GetVersion()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            var op = GameEntry.Resource.UpdatePackageVersionAsync();
            await op.ToUniTask();

            if (op.Status == EOperationStatus.Succeed)
            {
                Log.Info("GetVersion Succeed");
            }
            else
            {
                Log.Error("GetVersion Failed");
            }
        }
    }
}