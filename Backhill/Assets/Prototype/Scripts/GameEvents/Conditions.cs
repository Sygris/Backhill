using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Conditions
{
    public abstract bool TestCondition();
}

[System.Serializable]
public class ObjectsActiveCondition : Conditions
{
	public override bool TestCondition()
	{
		foreach (GameObject gameObject in _objectsToCheck)
		{
			if (gameObject.activeSelf != checkObjectsAreActive)
			{
				return false;
			}
		}

		return true;
	}

	[SerializeReference] private List<GameObject> _objectsToCheck;
	[SerializeReference] private bool checkObjectsAreActive = false;
}
