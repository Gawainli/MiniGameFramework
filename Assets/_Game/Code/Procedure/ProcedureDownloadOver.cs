using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace MiniGame
{
    public class ProcedureDownloadOver : ProcedureBase
    {
        private IFsm<IProcedureManager> owner;
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            owner = procedureOwner;
            Log.Info("ProcedureDownloadOver OnEnter");
            Log.Info("Clear unused cache files...");
            
            var operation = GameEntry.Resource.ClearUnusedCacheFilesAsync();
            operation.Completed += Operation_Completed;
        }
        
        private void Operation_Completed(YooAsset.AsyncOperationBase obj)
        {
            ChangeState<ProcedurePreload>(owner);
        }
    }
}