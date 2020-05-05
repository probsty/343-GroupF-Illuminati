using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	public class EventManager : MonoBehaviour
	{

		#region My Calls
		public void CardIsDroppedDown(int instId, int ownerId)
		{
			//Card c = NetworkManager.singleton.GetCard(instId, ownerId);
		}

		public void CardIsPickedUpFromDeck(int instId, int ownerId)
		{
		//	Card c = NetworkManager.singleton.GetCard(instId, ownerId);
		}
	
		#endregion

	}
}
