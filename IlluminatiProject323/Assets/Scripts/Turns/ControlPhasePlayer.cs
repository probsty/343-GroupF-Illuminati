using UnityEngine;
using System.Collections;

namespace SA
{
	[CreateAssetMenu(menuName = "Turns/Control Phase Player ")]
	public class ControlPhasePlayer : Phase
	{
		public GameStates.State playerControlState;

		public PlayerAction[] turnStartActions;


		public override bool IsComplete()
		{
			if (forceExit)
			{
				forceExit = false;
				return true;
			}


			playerControlState.Tick(Time.deltaTime);

			return false;
		}

		public override void OnStartPhase()
		{	
			Settings.gameManager.SetState(playerControlState);
			Settings.gameManager.onPhaseChanged.Raise();
			foreach (PlayerAction action in turnStartActions)
			{
				action.Execute(Settings.gameManager.localPlayer);
			}
		}
	}
}
