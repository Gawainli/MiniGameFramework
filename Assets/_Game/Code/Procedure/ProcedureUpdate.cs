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
            UpdateVersionAndManifest(procedureOwner).Forget();
        }

        private async UniTaskVoid UpdateVersionAndManifest(IFsm<IProcedureManager> procedureOwner)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            var opVersion = GameEntry.Resource.UpdatePackageVersionAsync();
            await opVersion.ToUniTask();

            if (opVersion.Status == EOperationStatus.Succeed)
            {
                Log.Info("GetVersion Succeed");
            }
            else
            {
                Log.Error("GetVersion Failed");
                return;
            }
            
            var opManifest = GameEntry.Resource.UpdatePackageManifestAsync(GameEntry.Resource.PackageVersion);
            await opManifest.ToUniTask();
            
            if(opManifest.Status == EOperationStatus.Succeed)
            {
                Log.Info("GetManifest Succeed");
                ChangeState<ProcedureDownload>(procedureOwner);
            }
            else
            {
                Log.Info("GetManifest Error");
                Log.Error(opManifest.Error);
            }
        }
        
        private async UniTaskVoid UpdateManifest()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            
            var operation = GameEntry.Resource.UpdatePackageManifestAsync(GameEntry.Resource.PackageVersion);
            
            await operation.ToUniTask();
            
  
        }
        
        
        
    }
}