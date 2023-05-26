using Cysharp.Threading.Tasks;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using YooAsset;

namespace MiniGame
{
    public class ProcedureDownloadFile : ProcedureBase
    {
        IFsm<IProcedureManager> owner;
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureDownloadFile OnEnter");
            owner = procedureOwner;
            BeginDownload(owner).Forget();
        }
        
        private async UniTaskVoid BeginDownload(IFsm<IProcedureManager> procedureOwner)
        {
            var downloader = GameEntry.Resource.Downloader;
            downloader.OnDownloadErrorCallback = OnDownloadError;
            downloader.OnDownloadProgressCallback = OnDownloadProgress;
            downloader.BeginDownload();
            await downloader;

            if (downloader.Status == EOperationStatus.Succeed)
            {
                ChangeState<ProcedureDownloadOver>(procedureOwner);
            }
            else
            {
                Log.Error("DownloadFile Failed. Status: {0}", downloader.Status);
            }
        }
        
        private void OnDownloadError(string downloadPath, string errorMessage)
        {
            Log.Error("DownloadFile Error. File Path: {0}, Error Message: {1}", downloadPath, errorMessage);
            //todo: retry
            //ChangeState<ProcedureCreateDownloader>(owner);
        }
        
        private void OnDownloadProgress(int totalDownloadCount, int currentDownloadCount, long totalDownloadBytes, long currentDownloadBytes)
        {
            Log.Info("DownloadFile Progress. Total: {0}, Current: {1}, TotalBytes: {2}, CurrentBytes: {3}", totalDownloadCount, currentDownloadCount, totalDownloadBytes, currentDownloadBytes);
        }
    }
}