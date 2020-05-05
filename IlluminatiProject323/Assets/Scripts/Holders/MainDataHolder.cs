using UnityEngine;
using System.Collections;
using SO;

namespace SA
{
	[CreateAssetMenu]
	public class MainDataHolder : ScriptableObject
	{
		public GameObject cardPrefab;
		public GameElements.GE_Logic cardDownLogic;
		public GameElements.GE_Logic handCard;
		public Element attackElement;
		public Element defenceElement;

	}
}
