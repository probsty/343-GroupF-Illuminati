using UnityEngine;
using System.Collections;

namespace SA
{
	[CreateAssetMenu(menuName = "Turns/ClientEmptyPhase ")]
	public class ClientEmptyPhase : Phase
	{

		public override bool IsComplete()
		{
			if (forceExit)
			{
				forceExit = false;
				return true;
			}

			return false;
		}

		public override void OnStartPhase()
		{
	
		}
	}
}
