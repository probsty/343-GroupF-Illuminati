using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace SA.GameStates
{
	[CreateAssetMenu(menuName = "Actions/OnMouseClick")]
	public class OnMouseClick : Action
	{
		public override void Execute(float d)
		{
			if (Input.GetMouseButtonDown(0))
			{

				List<RaycastResult> results = Settings.GetUIObjs();

				foreach (RaycastResult r in results)
				{
					IClickable c = r.gameObject.GetComponentInParent<IClickable>();
					if (c != null)
					{
						c.OnClick();
						break;
					}
				}
			}
		}

	}
}
