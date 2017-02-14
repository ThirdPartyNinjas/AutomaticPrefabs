using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
	SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();

		var testObject = GameObject.FindObjectOfType<TestObject>();
		if (testObject != null)
		{
			spriteRenderer.color = testObject.color;
		}
	}
}
