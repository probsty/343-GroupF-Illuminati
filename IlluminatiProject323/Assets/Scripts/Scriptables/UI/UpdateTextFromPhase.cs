using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SA;
using SO.UI;

namespace SO{
public class UpdateTextFromPhase : UIPropertyUpdater
{
		public PhaseVariable currentPhase;
		public Text targetText;

		/// <summary>
		/// Use this to update a text UI element based on the target string variable
		/// </summary>
		public override void Raise()
		{
		//	targetText.text = currentPhase.value.phaseName;
		}
	}
}

