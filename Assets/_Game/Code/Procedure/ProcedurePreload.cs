using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace MiniGame
{
    public class ProcedurePreload : ProcedureBase
    {
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedurePreload OnEnter");
        }

        protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            //For Huatuo/HybridCLR/ILruntime, we should change state to ProcedureLoadAssembly
            //ChangeState<ProcedureLoadAssembly>(procedureOwner);
            ChangeState<ProcedureStartGame>(procedureOwner);
        }
    }
}