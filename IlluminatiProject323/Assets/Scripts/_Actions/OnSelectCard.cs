using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace SA.GameStates
{
	[CreateAssetMenu(menuName = "Actions/OnSelectCard")]
	public class OnSelectCard : Action
	{
		public SO.GameEvent onCurrentCardSelected;
		public CardVariable currentCard;
		public GameStates.State holdingCard;

		public override void Execute(float d)
		{

			if (Input.GetMouseButtonDown(0))
			{
				List<RaycastResult> results = Settings.GetUIObjs();
				
				foreach (RaycastResult r in results)
				{
					CardInstance c = r.gameObject.GetComponentInParent<CardInstance>();
					if (c != null)
					{
						GameManager gm = Settings.gameManager;
						PlayerHolder enemy = gm.GetEnemyOf(gm.currentPlayer);

						if (c.owner != enemy)
						{
							if (gm.currentPlayer.cardsDown.Contains(c))
							{
								if (!c.isFlatfooted)
								{
								//	Debug.Log(c.name);
									currentCard.value = c;
									gm.SetState(holdingCard);
									onCurrentCardSelected.Raise();
								}
							}
						}

						return;
					}
				}
			}
		}

	}
}
