using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;

namespace SA.GameStates
{
	[CreateAssetMenu(menuName = "Actions/MouseOverDetection")]
	public class MouseOverDetection : Action
	{
		public override void Execute(float d)
		{

			List<RaycastResult> results = Settings.GetUIObjs();

			IClickable c = null;

			foreach (RaycastResult r in results)
			{
				c = r.gameObject.GetComponentInParent<IClickable>();
				if (c != null)
				{
					c.OnHighlight();
					break;
				}
			}
		}

	}
}
