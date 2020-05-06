using UnityEngine;
using System.Collections;

namespace SA
{
	[CreateAssetMenu(menuName = "Turns/BlockPhase ")]
	public class BlockPhase : Phase
	{
		public GameStates.State playerControlState;
		public override bool IsComplete()
		{
			if (forceExit)
			{
				forceExit = false;
				return true;
			}

			return false;
		}


		public override void OnStartPhase()
		{
			forceExit = true;
			return;
			GameManager gm = Settings.gameManager;
			gm.SetState(playerControlState);
			gm.onPhaseChanged.Raise();
			PlayerHolder e = gm.GetEnemyOf(gm.currentPlayer);
			if (e.attackingCards.Count == 0)
			{
				forceExit = true;
				return;
			}

		}
		
	}
}
