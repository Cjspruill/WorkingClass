using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] RectTransform spawnedCharacters;
    [SerializeField] RectTransform player1Pos;
    [SerializeField] RectTransform playerOpponentPos;

    [SerializeField] string selectedCharacter;

    [SerializeField] Button reselectButton;
    [SerializeField] Button startButton;

    [SerializeField] GameObject playerOneSelectionPanel;
    [SerializeField] GameObject opponentPlayerSelectionPanel;

    //Use this to destroy the original character if rechosen
    [SerializeField] GameObject opponentPlayerCharacterRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCharacterSelectionForPlayerOne(string charName)
    {
        for (int i = 0; i < spawnedCharacters.childCount; i++)
        {
           Destroy(spawnedCharacters.GetChild(i).gameObject);      
        }

        switch (charName)
        {
            case "Register":
                selectedCharacter = "Register";
                GameObject newChar = Instantiate(GameManager.instance.registerPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar;
                newChar.transform.position = player1Pos.position;
                newChar.transform.SetParent(spawnedCharacters);
                break;
            case "Scrubs":
                selectedCharacter = "Scrubs";
                GameObject newChar1 = Instantiate(GameManager.instance.scrubsPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar1;
                newChar1.transform.position = player1Pos.position;
                newChar1.transform.SetParent(spawnedCharacters);
                break;
            case "Shift":
                selectedCharacter = "Shift";
                GameObject newChar2 = Instantiate(GameManager.instance.shiftPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar2;
                newChar2.transform.position = player1Pos.position;
                newChar2.transform.SetParent(spawnedCharacters);
                break;
            case "Big Rig":
                selectedCharacter = "Big Rig";
                GameObject newChar3 = Instantiate(GameManager.instance.bigRigPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar3;
                newChar3.transform.position = player1Pos.position;
                newChar3.transform.SetParent(spawnedCharacters);
                break;
            case "Tenure":
                selectedCharacter = "Tenure";
                GameObject newChar4 = Instantiate(GameManager.instance.tenurePlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar4;
                newChar4.transform.position = player1Pos.position;
                newChar4.transform.SetParent(spawnedCharacters);
                break;
            case "Mop":
                selectedCharacter = "Mop";
                GameObject newChar5 = Instantiate(GameManager.instance.mopPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar5;
                newChar5.transform.position = player1Pos.position;
                newChar5.transform.SetParent(spawnedCharacters);
                break;
            case "Pallet":
                selectedCharacter = "Pallet";
                GameObject newChar6 = Instantiate(GameManager.instance.palletPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar6;
                newChar6.transform.position = player1Pos.position;
                newChar6.transform.SetParent(spawnedCharacters);
                break;
            case "Echo":
                selectedCharacter = "Echo";
                GameObject newChar7 = Instantiate(GameManager.instance.echoPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar7;
                newChar7.transform.position = player1Pos.position;
                newChar7.transform.SetParent(spawnedCharacters);
                break;
        }
        reselectButton.gameObject.SetActive(true);
        playerOneSelectionPanel.gameObject.SetActive(false);
        opponentPlayerSelectionPanel.gameObject.SetActive(true);
    }

    public void UpdateCharacterSelectionForPlayerOpponent(string charName)
    {
        if (opponentPlayerCharacterRef != null)
        {
            Destroy(opponentPlayerCharacterRef.gameObject);
        }

        switch (charName)
        {
            case "Register":
                selectedCharacter = "Register";
                GameObject newChar = Instantiate(GameManager.instance.registerAIPrefab);
                opponentPlayerCharacterRef = newChar;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar;
                newChar.transform.position = playerOpponentPos.position;
                newChar.transform.SetParent(spawnedCharacters);
                break;
            case "Scrubs":
                selectedCharacter = "Scrubs";
                GameObject newChar1 = Instantiate(GameManager.instance.scrubsAIPrefab);
                opponentPlayerCharacterRef = newChar1;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar1;
                newChar1.transform.position = playerOpponentPos.position;
                newChar1.transform.SetParent(spawnedCharacters);
                break;
            case "Shift":
                selectedCharacter = "Shift";
                GameObject newChar2 = Instantiate(GameManager.instance.shiftAIPrefab);
                opponentPlayerCharacterRef = newChar2;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar2;
                newChar2.transform.position = playerOpponentPos.position;
                newChar2.transform.SetParent(spawnedCharacters);
                break;
            case "Big Rig":
                selectedCharacter = "Big Rig";
                GameObject newChar3 = Instantiate(GameManager.instance.bigRigAIPrefab);
                opponentPlayerCharacterRef = newChar3;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar3;
                newChar3.transform.position = playerOpponentPos.position;
                newChar3.transform.SetParent(spawnedCharacters);
                break;
            case "Tenure":
                selectedCharacter = "Tenure";
                GameObject newChar4 = Instantiate(GameManager.instance.tenureAIPrefab);
                opponentPlayerCharacterRef = newChar4;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar4;
                newChar4.transform.position = playerOpponentPos.position;
                newChar4.transform.SetParent(spawnedCharacters);
                break;
            case "Mop":
                selectedCharacter = "Mop";
                GameObject newChar5 = Instantiate(GameManager.instance.mopAIPrefab);
                opponentPlayerCharacterRef = newChar5;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar5;
                newChar5.transform.position = playerOpponentPos.position;
                newChar5.transform.SetParent(spawnedCharacters);
                break;
            case "Pallet":
                selectedCharacter = "Pallet";
                GameObject newChar6 = Instantiate(GameManager.instance.palletAIPrefab);
                opponentPlayerCharacterRef = newChar6;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar6;
                newChar6.transform.position = playerOpponentPos.position;
                newChar6.transform.SetParent(spawnedCharacters);
                break;
            case "Echo":
                selectedCharacter = "Echo";
                GameObject newChar7 = Instantiate(GameManager.instance.echoAIPrefab);
                opponentPlayerCharacterRef = newChar7;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar7;
                newChar7.transform.position = playerOpponentPos.position;
                newChar7.transform.SetParent(spawnedCharacters);
                break;
        }
        reselectButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
    }
}
