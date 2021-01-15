using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializingObjectsInEditor : MonoBehaviour
{
	public int i;
	[Header("Class")]
	public TestClass testClass;
	[Header("Struct")]
	public UserInformation user;
	
	private const string fileKey = "SerializeableObjectsInEditor1";
	
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(fileKey), this);
	}
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		PlayerPrefs.SetString(fileKey, JsonUtility.ToJson(this,true));
		PlayerPrefs.Save();
	}
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
