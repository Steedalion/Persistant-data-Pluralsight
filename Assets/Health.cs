using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public CharacterSaveData_SO characterData;
	public Text text;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		text = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
	    text.text = "Health "+characterData.CurrentHealth.ToString();
    }
}
