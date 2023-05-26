using System;
using Cysharp.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using YooAsset;

namespace MiniGame
{
    public class ProcedureUpdateManifest : ProcedureBase
    {
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureUpdateManifest OnEnter");
            UpdateManifest(procedureOwner).Forget();
        }
        
        private async UniTaskVoid UpdateManifest(IFsm<IProcedureManager> procedureOwner)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            
            var operation = GameEntry.Resource.UpdatePackageManifestAsync(GameEntry.Resource.PackageVersion);
            
            await operation.ToUniTask();

            if (operation.Status == EOperationStatus.Succeed)
            {
                Log.Info("GetManifest Succeed");
                ChangeState<ProcedureCreateDownloader>(procedureOwner);
            }
            else
            {
                Log.Error("GetManifest Failed");
            }
   
        }
        
    }
}