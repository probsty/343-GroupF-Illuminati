using UnityEngine;
using System.Collections;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/Player Actions/PickCardFromDeck")]
	public class PickCardFromDeck : PlayerAction
	{
		public override void Execute(PlayerHolder player)
		{
			GameManager.singleton.PickNewCardFromDeck(player);
		}
	}
}
