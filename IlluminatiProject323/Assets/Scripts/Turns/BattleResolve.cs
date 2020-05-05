using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu(menuName = "Turns/Battle Resolve ")]
	public class BattleResolve : Phase
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
		//	MultiplayerManager.singleton.SetBattleResolvePhase();
			forceExit = true;
		}
	}
}

