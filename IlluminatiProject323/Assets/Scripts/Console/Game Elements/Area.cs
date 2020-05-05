using UnityEngine;
using System.Collections;

namespace SA.GameElements
{
	public class Area : MonoBehaviour
	{
		public AreaLogic logic;
	
		public void OnDrop()
		{
			logic.Execute();
		}
	}
}
