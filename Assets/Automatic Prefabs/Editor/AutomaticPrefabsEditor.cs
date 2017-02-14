using System;
using System.IO;
using System.Reflection;

using UnityEditor;
using UnityEngine;

namespace AutomaticPrefabs
{
    [InitializeOnLoad]
    public class AutomaticPrefabsEditor
    {
        static AutomaticPrefabsEditor()
        {
            EditorApplication.playmodeStateChanged += PlaymodeStateChanged;

			DirectoryInfo directory = new DirectoryInfo(Application.dataPath + "/" + Automator.ResourcePath);
			if (!directory.Exists)
				directory.Create();

			// Loop through all the types available, if any of them implement IAutomatic, create a GameObject, then make a prefab of it.
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IAutomatic).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        GameObject gameObject = Resources.Load(Automator.PrefabFolder + type.Name) as GameObject;
                        if (gameObject != null)
                            continue;

                        gameObject = new GameObject(type.Name);
                        gameObject.AddComponent(type);

                        PrefabUtility.CreatePrefab("Assets/" + Automator.ResourcePath + type.Name + ".prefab", gameObject.gameObject);

                        GameObject.DestroyImmediate(gameObject);
                    }
                }
            }
        }

        private static void PlaymodeStateChanged()
        {
            if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
            {
                // If we're in here, the user just hit play, create an Automator if one doesn't exist
                Automator automator = GameObject.FindObjectOfType<Automator>();
                if (automator == null)
                {
                    GameObject go = new GameObject("Automator");
                    go.AddComponent<Automator>();
                    go.hideFlags = HideFlags.NotEditable;
                }
            }
			else if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
			{
				// If we're here, the user just hit stop, destroy the Automator if it exists
				Automator automator = GameObject.FindObjectOfType<Automator>();
				if (automator != null)
				{
					GameObject.DestroyImmediate(automator.gameObject);
				}
			}
		}
    }
}
