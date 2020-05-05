using UnityEngine;
using System.Collections;

namespace SA
{
	
	public abstract class PlayerAction : ScriptableObject
	{
		public abstract void Execute(PlayerHolder player);

	}
}
