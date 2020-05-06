using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA {
	[CreateAssetMenu(menuName = "Card")]
	public class Card : ScriptableObject {
		[System.NonSerialized]
		public int instId;
		[System.NonSerialized]
		public CardViz cardViz;
		[System.NonSerialized]
		public CardType cardType;
		public int cost;
	}
}
