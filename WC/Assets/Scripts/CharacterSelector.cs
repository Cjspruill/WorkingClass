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

    [SerializeField] Sprite playerOneSprite;
    [SerializeField] Sprite playerOpponentSprite;

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

        if(playerOneSprite != null)
        {
            Destroy(playerOneSprite);
        }

        for (int i = 0; i < player1Pos.childCount; i++) 
        {
            Destroy(player1Pos.GetChild(i).gameObject);
        }

        switch (charName)
        {
            case "Register":
                selectedCharacter = "Register";
                GameObject newChar = Instantiate(GameManager.instance.registerPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar;
                GameObject newSprite = Instantiate(GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, player1Pos.position, Quaternion.identity);
                newSprite.transform.SetParent(player1Pos);
                newSprite.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOneSprite = newSprite.GetComponent<Image>().sprite;
                newChar.transform.SetParent(spawnedCharacters);
                break;
            case "Scrubs":
                selectedCharacter = "Scrubs";
                GameObject newChar1 = Instantiate(GameManager.instance.scrubsPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar1;
                GameObject newSprite1 = Instantiate(GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, player1Pos.position, Quaternion.identity);
                newSprite1.transform.SetParent(player1Pos);
                newSprite1.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOneSprite = newSprite1.GetComponent<Image>().sprite;
                newChar1.transform.SetParent(spawnedCharacters);
                break;
            case "Shift":
                selectedCharacter = "Shift";
                GameObject newChar2 = Instantiate(GameManager.instance.shiftPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar2;
                GameObject newSprite2 = Instantiate(GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, player1Pos.position, Quaternion.identity);
                newSprite2.transform.SetParent(player1Pos);
                newSprite2.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOneSprite = newSprite2.GetComponent<Image>().sprite;
                newChar2.transform.SetParent(spawnedCharacters);
                break;
            case "Big Rig":
                selectedCharacter = "Big Rig";
                GameObject newChar3 = Instantiate(GameManager.instance.bigRigPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar3;
                GameObject newSprite3 = Instantiate(GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, player1Pos.position, Quaternion.identity);
                newSprite3.transform.SetParent(player1Pos);
                newSprite3.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOneSprite = newSprite3.GetComponent<Image>().sprite;
                newChar3.transform.SetParent(spawnedCharacters);
                break;
            case "Tenure":
                selectedCharacter = "Tenure";
                GameObject newChar4 = Instantiate(GameManager.instance.tenurePlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar4;
                GameObject newSprite4 = Instantiate(GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, player1Pos.position, Quaternion.identity);
                newSprite4.transform.SetParent(player1Pos);
                newSprite4.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOneSprite = newSprite4.GetComponent<Image>().sprite;
                newChar4.transform.SetParent(spawnedCharacters);
                break;
            case "Mop":
                selectedCharacter = "Mop";
                GameObject newChar5 = Instantiate(GameManager.instance.mopPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar5;
                GameObject newSprite5 = Instantiate(GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, player1Pos.position, Quaternion.identity);
                newSprite5.transform.SetParent(player1Pos);
                newSprite5.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOneSprite = newSprite5.GetComponent<Image>().sprite;
                newChar5.transform.SetParent(spawnedCharacters);
                break;
            case "Pallet":
                selectedCharacter = "Pallet";
                GameObject newChar6 = Instantiate(GameManager.instance.palletPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar6;
                GameObject newSprite6 = Instantiate(GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, player1Pos.position, Quaternion.identity);
                newSprite6.transform.SetParent(player1Pos);
                newSprite6.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOneSprite = newSprite6.GetComponent<Image>().sprite;
                newChar6.transform.SetParent(spawnedCharacters);
                break;
            case "Echo":
                selectedCharacter = "Echo";
                GameObject newChar7 = Instantiate(GameManager.instance.echoPlayerPrefab);
                GameManager.instance.oneVsOnePlayerOneSelection = newChar7;
                GameObject newSprite7 = Instantiate(GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, player1Pos.position, Quaternion.identity);
                newSprite7.transform.SetParent(player1Pos);
                newSprite7.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOneSprite = newSprite7.GetComponent<Image>().sprite;
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

        if(playerOpponentSprite != null)
        {
            Destroy(playerOpponentSprite);
        }

        for (int i = 0; i < playerOpponentPos.childCount; i++)
        {
            Destroy(playerOpponentPos.GetChild(i).gameObject);
        }

        switch (charName)
        {
            case "Register":
                selectedCharacter = "Register";
                GameObject newChar = Instantiate(GameManager.instance.registerAIPrefab);
                opponentPlayerCharacterRef = newChar;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar;
                GameObject newSprite = Instantiate(GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, playerOpponentPos.position, Quaternion.identity);
                newSprite.transform.SetParent(playerOpponentPos);
                newSprite.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOpponentSprite = newSprite.GetComponent<Image>().sprite;
                newChar.transform.SetParent(spawnedCharacters);
                break;
            case "Scrubs":
                selectedCharacter = "Scrubs";
                GameObject newChar1 = Instantiate(GameManager.instance.scrubsAIPrefab);
                opponentPlayerCharacterRef = newChar1;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar1;
                GameObject newSprite1 = Instantiate(GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, playerOpponentPos.position, Quaternion.identity);
                newSprite1.transform.SetParent(playerOpponentPos);
                newSprite1.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOpponentSprite = newSprite1.GetComponent<Image>().sprite;
                newChar1.transform.SetParent(spawnedCharacters);
                break;
            case "Shift":
                selectedCharacter = "Shift";
                GameObject newChar2 = Instantiate(GameManager.instance.shiftAIPrefab);
                opponentPlayerCharacterRef = newChar2;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar2;
                GameObject newSprite2 = Instantiate(GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, playerOpponentPos.position, Quaternion.identity);
                newSprite2.transform.SetParent(playerOpponentPos);
                newSprite2.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOpponentSprite = newSprite2.GetComponent<Image>().sprite;
                newChar2.transform.SetParent(spawnedCharacters);
                break;
            case "Big Rig":
                selectedCharacter = "Big Rig";
                GameObject newChar3 = Instantiate(GameManager.instance.bigRigAIPrefab);
                opponentPlayerCharacterRef = newChar3;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar3;
                GameObject newSprite3 = Instantiate(GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, playerOpponentPos.position, Quaternion.identity);
                newSprite3.transform.SetParent(playerOpponentPos);
                newSprite3.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOpponentSprite = newSprite3.GetComponent<Image>().sprite;
                newChar3.transform.SetParent(spawnedCharacters);
                break;
            case "Tenure":
                selectedCharacter = "Tenure";
                GameObject newChar4 = Instantiate(GameManager.instance.tenureAIPrefab);
                opponentPlayerCharacterRef = newChar4;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar4;
                GameObject newSprite4 = Instantiate(GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, playerOpponentPos.position, Quaternion.identity);
                newSprite4.transform.SetParent(playerOpponentPos);
                newSprite4.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOpponentSprite = newSprite4.GetComponent<Image>().sprite;
                newChar4.transform.SetParent(spawnedCharacters);
                break;
            case "Mop":
                selectedCharacter = "Mop";
                GameObject newChar5 = Instantiate(GameManager.instance.mopAIPrefab);
                opponentPlayerCharacterRef = newChar5;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar5;
                GameObject newSprite5 = Instantiate(GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, playerOpponentPos.position, Quaternion.identity);
                newSprite5.transform.SetParent(playerOpponentPos);
                newSprite5.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOpponentSprite = newSprite5.GetComponent<Image>().sprite;
                newChar5.transform.SetParent(spawnedCharacters);
                break;
            case "Pallet":
                selectedCharacter = "Pallet";
                GameObject newChar6 = Instantiate(GameManager.instance.palletAIPrefab);
                opponentPlayerCharacterRef = newChar6;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar6;
                GameObject newSprite6 = Instantiate(GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, playerOpponentPos.position, Quaternion.identity);
                newSprite6.transform.SetParent(playerOpponentPos);
                newSprite6.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOpponentSprite = newSprite6.GetComponent<Image>().sprite;
                newChar6.transform.SetParent(spawnedCharacters);
                break;
            case "Echo":
                selectedCharacter = "Echo";
                GameObject newChar7 = Instantiate(GameManager.instance.echoAIPrefab);
                opponentPlayerCharacterRef = newChar7;
                GameManager.instance.oneVsOnePlayerOpponentSelection = newChar7;

                GameObject newSprite7 = Instantiate(GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenImagePrefab, playerOpponentPos.position, Quaternion.identity);
                newSprite7.transform.SetParent(playerOpponentPos);
                newSprite7.GetComponent<Image>().sprite = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<CharacterStats>().characterSelectionScreenSprite;
                playerOpponentSprite = newSprite7.GetComponent<Image>().sprite;

                newChar7.transform.SetParent(spawnedCharacters);
                break;
        }
        reselectButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
    }
}
