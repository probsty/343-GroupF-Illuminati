using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
	[CreateAssetMenu]
	public class TurnsHolder : ScriptableObject
	{
		public string[] phaseOrder;
		public Phase[] allPhases;

	

		[System.NonSerialized]
		Dictionary<string, Phase> phaseDict = new Dictionary<string, Phase>();

		[System.NonSerialized]
		bool isInit;

		public void Init()
		{
			phaseDict.Clear();
			for (int i = 0; i < allPhases.Length; i++)
			{
				phaseDict.Add(allPhases[i].name, allPhases[i]);
			}

			isInit = true;
		}

		public Phase GetPhase(string id)
		{
			if (!isInit)
			{
				Init();
			}

			Phase r = null;
			phaseDict.TryGetValue(id,out r);
			return r;
		}
	}


}