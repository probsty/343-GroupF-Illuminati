using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SA
{
	public class ConsoleManager : MonoBehaviour
	{
		public Transform consoleGrid;
		public GameObject prefab;
		Text[] txtObjects;
		int index;

		public ConsoleHook hook;

		private void Awake()
		{
			hook.consoleManager = this;

			txtObjects = new Text[5];
			for (int i = 0; i < txtObjects.Length; i++)
			{
				GameObject go = Instantiate(prefab) as GameObject;
				txtObjects[i] = go.GetComponent<Text>();
				go.transform.SetParent(consoleGrid);
			}
		}

		public void RegisterEvent(string s , Color color)
		{
			index++;
			if (index > txtObjects.Length-1)
			{
				index = 0;
			}

			txtObjects[index].color = color;
			txtObjects[index].text = s;
			txtObjects[index].gameObject.SetActive(true);
			txtObjects[index].transform.SetAsLastSibling();
		}

	}
}
