using UnityEngine;
using System.Collections;

namespace SA
{
	public class CardInstance : MonoBehaviour, IClickable
	{
		public PlayerHolder owner;
		public CardViz viz;
		public SA.GameElements.GE_Logic currentLogic;
		public bool isFlatfooted;

		public void SetFlatfooted(bool isFlat)
		{
			isFlatfooted = isFlat;
			if (isFlatfooted)
				transform.localEulerAngles = new Vector3(0, 0, 90);
			else
				transform.localEulerAngles = Vector3.zero;
		}

		void Start()
		{
			viz = GetComponent<CardViz>();
		}

		public void CardInstanceToGraveyard()
		{
			Settings.gameManager.PutCardToGraveyard(this);
		}

		public bool CanBeBlocked(CardInstance block, ref int count)
		{
			bool result = owner.attackingCards.Contains(this);

			if (result && viz.card.cardType.canAttack)
			{
				result = true;
				//if a card has flying that can be blocked by non flying, you can check it here
				//or cases like that should be here

				if (result)
				{
					//Settings.gameManager.AddBlockInstance(this, block, ref count);
				}
				return result;
			}			
			else
			{
				return false;
			}
		}

		public bool CanAttack()
		{
			bool result = true;

			if (isFlatfooted)
				result = false;

			if (viz.card.cardType.TypeAllowsForAttack(this))
			{
				result = true;
			}
			
			return result;
		}

		public void OnClick()
		{
			if (currentLogic == null)
				return;

			currentLogic.OnClick(this);
		}

		public void OnHighlight()
		{
			if (currentLogic == null)
				return;

			currentLogic.OnHighlight(this);
		}
	}
}
