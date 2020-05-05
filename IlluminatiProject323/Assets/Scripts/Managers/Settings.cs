using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace SA
{
	public static class Settings
	{
		public static GameManager gameManager;
		private static ResourcesManager _resourcesManager;
		private static ConsoleHook _consoleManager;

		public static void RegisterEvent(string e, Color color)
		{
			if (_consoleManager == null)
			{
				_consoleManager = Resources.Load("ConsoleHook") as ConsoleHook;
			}

			_consoleManager.RegisterEvent(e,color);
		}

		public static ResourcesManager GetResourcesManager()
		{
			if (_resourcesManager == null)
			{
				_resourcesManager = Resources.Load("ResourcesManager") as ResourcesManager;
				_resourcesManager.Init();
			}

			return _resourcesManager;
		}

		public static List<RaycastResult> GetUIObjs()
		{
			PointerEventData pointerData = new PointerEventData(EventSystem.current)
			{
				position = Input.mousePosition
			};

			List<RaycastResult> results = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerData, results);
			return results;
		}

		public static void DropCreatureCard(Transform c, Transform p, CardInstance cardInst)
		{
			cardInst.isFlatfooted = true;
			//Execute any special card abilities on drop
			SetParentForCard(c, p);
			cardInst.SetFlatfooted(true);
			
			gameManager.currentPlayer.UseResourceCards(cardInst.viz.card.cost);
			gameManager.currentPlayer.DropCard(cardInst);
		}

		public static void SetParentForCard(Transform c, Transform p)
		{
			c.SetParent(p);
			c.localPosition = Vector3.zero;
			c.localEulerAngles = Vector3.zero;
			c.localScale = Vector3.one;
		}

		public static void SetCardForBlock(Transform c, Transform p,int count)
		{
			Vector3 blockPosition = Vector3.zero;
			blockPosition.x += 150 * count;
			blockPosition.y -= 150 * count;
			SetParentForCard(c, p, blockPosition, Vector3.zero);
		}

		public static void SetParentForCard(Transform c, Transform p, Vector3 localPosition, Vector3 euler)
		{
			c.SetParent(p);
			c.localPosition = localPosition;
			c.localEulerAngles = euler;
			c.localScale = Vector3.one;
		}

	}
}
