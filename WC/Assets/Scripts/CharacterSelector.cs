using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] RectTransform spawnedCharacters;
    [SerializeField] RectTransform player1Pos;
    [SerializeField] RectTransform playerOpponentPos;

    [SerializeField] string selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCharacterSelection(string charName)
    {
        for (int i = 0; i < spawnedCharacters.childCount; i++)
        {
           Destroy(spawnedCharacters.GetChild(i).gameObject);      
        }

        switch (charName)
        {
            case "Register":
                selectedCharacter = "Register";
                GameObject newChar = Instantiate(GameManager.instance.registerPrefab);
                newChar.transform.position = player1Pos.position;
                newChar.transform.SetParent(spawnedCharacters);
                break;
            case "Scrubs":
                selectedCharacter = "Scrubs";
                GameObject newChar1 = Instantiate(GameManager.instance.scrubsPrefab);
                newChar1.transform.position = player1Pos.position;
                newChar1.transform.SetParent(spawnedCharacters);
                break;
            case "Shift":
                selectedCharacter = "Shift";
                GameObject newChar2 = Instantiate(GameManager.instance.shiftPrefab);
                newChar2.transform.position = player1Pos.position;
                newChar2.transform.SetParent(spawnedCharacters);
                break;
            case "Big Rig":
                selectedCharacter = "Big Rig";
                GameObject newChar3 = Instantiate(GameManager.instance.bigRigPrefab);
                newChar3.transform.position = player1Pos.position;
                newChar3.transform.SetParent(spawnedCharacters);
                break;
            case "Tenure":
                selectedCharacter = "Tenure";
                GameObject newChar4 = Instantiate(GameManager.instance.tenurePrefab);
                newChar4.transform.position = player1Pos.position;
                newChar4.transform.SetParent(spawnedCharacters);
                break;
            case "Mop":
                selectedCharacter = "Mop";
                GameObject newChar5 = Instantiate(GameManager.instance.mopPrefab);
                newChar5.transform.position = player1Pos.position;
                newChar5.transform.SetParent(spawnedCharacters);
                break;
            case "Pallet":
                selectedCharacter = "Pallet";
                GameObject newChar6 = Instantiate(GameManager.instance.palletPrefab);
                newChar6.transform.position = player1Pos.position;
                newChar6.transform.SetParent(spawnedCharacters);
                break;
            case "Echo":
                selectedCharacter = "Echo";
                GameObject newChar7 = Instantiate(GameManager.instance.echoPrefab);
                newChar7.transform.position = player1Pos.position;
                newChar7.transform.SetParent(spawnedCharacters);
                break;
        }
    }
}
