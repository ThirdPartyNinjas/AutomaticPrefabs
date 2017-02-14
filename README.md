# AutomaticPrefabs
Automated prefab and manager loading for Unity3D.

Quite a few of the Unity tools that I use are designed to be turned into a prefab and then dropped into a scene. (Rewired, Master Audio, etc.) This requires always starting from a "master" scene that contains the prefab, or putting the prefab into every scene and getting warnings because the objects are designed not to unload on scene changes.

I found a neat plugin on the Unity Asset store called Universe (https://www.assetstore.unity3d.com/en/#!/content/24227) that will automatically load up singleton manager classes for you without needing to juggle that yourself in every scene. It also included some magic to generate prefabs for you if you derived from their Manager class.

This was great, but didn't help me with the prefab tools I'm using, so I took the concept and added the ability to load up any prefab, not just those that were Manager classes. I also changed how the tool works in editor mode vs in a build.

#### Usage
1. Copy the "Automatic Prefabs" folder into your Unity project.
2. (Optional) Configure the path and folder names at the top of Scripts/Automator.cs. The folder will be automatically created the next Unity updates if it doesn't exist. (Usually this when Unity compiles your code or when you hit play.)
3. Implement the IAutomatic marker interface in a class you want turned into an automatic prefab.
4. Copy any prefabs you want automatically loaded into the Resources/AutomaticPrefabs folder (or whatever you changed it to.)
5. Add the "Scene/Automatic Prefab Scene" scene to your build as the very first scene. This won't do anything while you're testing in the editor, but when you create a build, this scene will create the automatic prefabs, then load the scene right after it in the scene order.
6. If you ever want to regenerate an IAutomatic prefab just delete the prefab and hit play. (Only the IAutomatic ones, obviously. I can't regenerate stuff that you made and copied in there.)

That's it. If you want to see an example, load up this project into Unity. It will generate the Resources/AutomaticPrefabs folder. If you copy boxItem.prefab over to that folder it will be added to the scene when you hit play. If you uncomment out the class in TestObject.cs, a prefab will be generated for it, and CoinObject.cs will see it and change color of the rendered box. (Yes, it's a really quick and stupid example.)