using System;
using Cysharp.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using YooAsset;

namespace MiniGame
{
    public class ProcedureUpdateVersion : ProcedureBase
    {
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureUpdate OnEnter");
            UpdateVersion(procedureOwner).Forget();
        }

        private async UniTaskVoid UpdateVersion(IFsm<IProcedureManager> procedureOwner)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            var opVersion = GameEntry.Resource.UpdatePackageVersionAsync();
            await opVersion.ToUniTask();

            if (opVersion.Status == EOperationStatus.Succeed)
            {
                Log.Info("GetVersion Succeed");
                GameEntry.Resource.PackageVersion = opVersion.PackageVersion;
                ChangeState<ProcedureUpdateManifest>(procedureOwner);
                
            }
            else
            {
                Log.Error("GetVersion Failed");
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