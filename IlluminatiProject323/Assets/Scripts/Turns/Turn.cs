using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Turns/Turn")]
	public class Turn : ScriptableObject
	{
		public PlayerHolder player;
		[System.NonSerialized]
		public int index = 0;
		public PhaseVariable currentPhase;
		public Phase[] phases;

		public PlayerAction[] turnStartActions;

		public void OnTurnStart()
		{
			if (turnStartActions == null)
				return;

			for (int i = 0; i < turnStartActions.Length; i++)
			{
				turnStartActions[i].Execute(player);
			}

//			MultiplayerManager.singleton.SendPhase(player.name, phases[index].name);
		}

		public bool Execute()
		{
			bool result = false;

			//currentPhase.value = phases[index];
			//phases[index].OnStartPhase();

			//bool phaseIsComplete = phases[index].IsComplete();

			//if (phaseIsComplete)
			//{
			//	phases[index].OnEndPhase();

			//	index++;
			//	if (index > phases.Length-1)
			//	{
			//		index = 0;
			//		result = true;
			//	}

			//	MultiplayerManager.singleton.SendPhase(player.name, phases[index].name);
			//}

			return result;
		}

		public void EndCurrentPhase()
		{
			phases[index].forceExit = true;
		}

	}
}
