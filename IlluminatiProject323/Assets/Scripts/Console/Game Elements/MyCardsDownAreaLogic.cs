using UnityEngine;
using System.Collections;

namespace SA
{
	[CreateAssetMenu(menuName = "Areas/MyCardsDownWhenHoldingCard")]
	public class MyCardsDownAreaLogic : AreaLogic
	{
		public CardVariable card;
		public CardType creatureType;
		public CardType resourceType;
		
		public override void Execute()
		{
			if (card.value == null)
				return;

			Card c = card.value.viz.card;

			// if (c.cardType == creatureType)
			// {
			// 	//MultiplayerManager.singleton.PlayerWantsToUseCard(c.instId, GameManager.singleton.localPlayer.photonId, MultiplayerManager.CardOperation.dropCreatureCard);
			// }
			// else
			// if (c.cardType == resourceType)
			// {
			// 	MultiplayerManager.singleton.PlayerWantsToUseCard(c.instId, GameManager.singleton.localPlayer.photonId, MultiplayerManager.CardOperation.dropResourcesCard);
			// }

		}

	}
}
