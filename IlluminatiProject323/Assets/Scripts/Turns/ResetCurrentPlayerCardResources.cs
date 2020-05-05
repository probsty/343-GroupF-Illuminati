using UnityEngine;
using System.Collections;

namespace SA
{
	[CreateAssetMenu(menuName = "Turns/ResetCurrentPlayerCardResources ")]
	public class ResetCurrentPlayerCardResources : Phase
	{
		public override bool IsComplete()
		{
			//MultiplayerManager.singleton.PlayerWantsToResetResourcesCards();
			return true;
		}

		public override void OnStartPhase()
		{

		}
	}
}