using UnityEngine;
using System.Collections;

namespace SA.GameElements
{
	[CreateAssetMenu(menuName = "Game Elements/My Hand Card")]
	public class HandCard : GE_Logic
	{
		public SO.GameEvent onCurrentCardSelected;
		public CardVariable currentCard;
		public SA.GameStates.State holdingCard;

		public override void OnClick(CardInstance inst)
		{
			currentCard.Set(inst);
			Settings.gameManager.SetState(holdingCard);
			onCurrentCardSelected.Raise();
		}

		public override void OnHighlight(CardInstance inst)
		{

		}

	}
}
