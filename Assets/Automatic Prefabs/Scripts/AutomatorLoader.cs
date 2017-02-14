using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutomaticPrefabs
{
	public class AutomatorLoader : MonoBehaviour
	{
		void Awake()
		{
			Automator automator = GameObject.FindObjectOfType<Automator>();
			if (automator == null)
			{
				GameObject go = new GameObject("Automator");
				go.AddComponent<Automator>();
				go.hideFlags = HideFlags.NotEditable;
			}
		}

		void Start()
		{
			SceneManager.LoadScene(1);
		}
	}
}
