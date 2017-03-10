using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace AutomaticPrefabs
{
	public class Automator : MonoBehaviour
	{
		public const string PrefabFolder = "AutomaticPrefabs/";
		public const string ResourcePath = "Resources/" + PrefabFolder;

		void Awake()
		{
			// Ensure there's only one Automator instance and keep it alive on scene transitions
			if (instance != null && instance != this)
			{
				Destroy(gameObject);
				return;
			}

			instance = this;
			DontDestroyOnLoad(gameObject);

			// Load up all of the resources, instantiate any that are GameObjects (i.e. prefabs)
			var resources = Resources.LoadAll(PrefabFolder);
			foreach (var resource in resources)
			{
				if (resource is GameObject)
				{
					var go = Instantiate(resource as GameObject, transform);
					go.name = resource.name;
				}
			}
		}

		private static Automator instance = null;
	}
}
