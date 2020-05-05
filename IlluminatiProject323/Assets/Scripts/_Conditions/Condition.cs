using UnityEngine;
using System.Collections;


namespace SA
{
	public abstract class Condition : ScriptableObject
	{
		public abstract bool IsValid();
	}
}
