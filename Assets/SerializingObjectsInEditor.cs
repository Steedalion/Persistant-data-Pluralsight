using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializingObjectsInEditor : MonoBehaviour
{
	public int i;
	public TestClass testClass;
	public UserInformation user;
 
}
[System.Serializable]
public class TestClass
{
	public int i;
	float f;
}
[System.Serializable]
public struct UserInformation
{
	public string username;
	float xp;
}
