using System;
using Cysharp.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using YooAsset;

namespace MiniGame
{
    public class ProcedureCreateDownloader : ProcedureBase
    {
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureCreateDownloader OnEnter");
            CreateDownloader(procedureOwner).Forget();
        }
        
        private async UniTaskVoid CreateDownloader(IFsm<IProcedureManager> procedureOwner)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

            int downloadingMaxNum = 10;
            int failedTryAgainNum = 3;
            int timeOut = 30;
            var downloader = GameEntry.Resource.CreateResourceDownloader(downloadingMaxNum, failedTryAgainNum);

            if (downloader.TotalDownloadCount == 0) 
            {
                Log.Info("No need to download anything");
                ChangeState<ProcedurePreload>(procedureOwner);
            }
            else
            {
                int totalDownloadCount = downloader.TotalDownloadCount;
                long totalDownloadBytes = downloader.TotalDownloadBytes;
                Log.Info($"Found total {totalDownloadCount} files in patch. size: {totalDownloadBytes} bytes");
                ChangeState<ProcedureDownloadFile>(procedureOwner);
            }
        }
    }
}