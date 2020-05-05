using UnityEngine;
using System.Collections;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/Player Actions/Reset Flat Foot")]
	public class ResetFlatFootedCards : PlayerAction
	{
		public override void Execute(PlayerHolder player)
		{
		//	MultiplayerManager.singleton.PlayerWantsToResetResourcesCards(player.photonId);
		//	MultiplayerManager.singleton.PlayerWantsToResetFlatfootedCards(player.photonId);
		}
	}
}
