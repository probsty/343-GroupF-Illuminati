using UnityEngine;
using System.Collections;

namespace SA.GameStates
{
	public abstract class Action : ScriptableObject
	{
		public abstract void Execute(float d);
	}
}
