using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Save Data", menuName = "Character/Data", order = 1)]
public class CharacterSaveData_SO : ScriptableObject
{
    [Header("Stats")]

    [SerializeField]
    int currentHealth;

    [Header("Leveling")]
    [SerializeField]
	int currentLevel = 1;
	[SerializeField] int maxLevel = 30;
	[SerializeField] int basisXPPoints = 200;
	[SerializeField] int xppointsTillNextLevel;

    [SerializeField]
	float levelBuff = 0.1f;
	[Header("Savedata")]
	[SerializeField] string key;

    public float LevelMultiplier
    {
        get { return 1 + (currentLevel - 1) * levelBuff; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public void AggregateAttackPoints(int points)
	{
		xppointsTillNextLevel -= points;
		if(xppointsTillNextLevel <= 0)
		{
			currentLevel = Mathf.Clamp(currentLevel + 1, 0, maxLevel);
			xppointsTillNextLevel += (int)(basisXPPoints * LevelMultiplier);
			Debug.Log("Level up");
		}
	}
    
	// This function is called when the object is loaded.
	protected void OnEnable()
	{
		if(xppointsTillNextLevel == 0 )
		{
			xppointsTillNextLevel += (int)(basisXPPoints * xppointsTillNextLevel);
		}
		JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), this);
	}
	
	// This function is called when the scriptable object goes out of scope.
	protected void OnDisable()
	{
		if(key == "")
		{
			key = name;
		}
		PlayerPrefs.SetString(key, JsonUtility.ToJson(this));
		PlayerPrefs.Save();
	}
}
