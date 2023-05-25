using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;

namespace MiniGame
{
    public class ProcedureStartGame : ProcedureBase
    {
        protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("ProcedureStartGame OnEnter");
            GameEntry.Scene.LoadScene("Assets/_Game/_Scenes/S_Game.unity");
        }
    }
}