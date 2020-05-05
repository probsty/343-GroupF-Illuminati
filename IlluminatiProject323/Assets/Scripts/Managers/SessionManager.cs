using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace SA
{
	public class SessionManager : MonoBehaviour
	{

		public static SessionManager singleton;
		public delegate void OnSceneLoaded();
		public OnSceneLoaded onSceneLoaded;


		private void Awake()
		{
			if (singleton == null)
			{
				singleton = this;
				DontDestroyOnLoad(this.gameObject);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}

		public void LoadGameLevel(OnSceneLoaded callback)
		{
			onSceneLoaded = callback;
			StartCoroutine(LoadLevel("scene1"));
		}

		public void LoadMenu()
		{
			StartCoroutine("menu");
		}

		IEnumerator LoadLevel(string level)
		{
			yield return SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
			if (onSceneLoaded != null)
			{
				onSceneLoaded();
				onSceneLoaded = null;

			}
		}
	}
}
