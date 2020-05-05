using UnityEngine;
using System.Collections;

namespace SA
{
	public abstract class Phase : ScriptableObject
	{
		public string phaseName;
		public bool forceExit;

		public abstract bool IsComplete();
		public abstract void OnStartPhase();
		//public abstract void OnEndPhase();

	}
}
