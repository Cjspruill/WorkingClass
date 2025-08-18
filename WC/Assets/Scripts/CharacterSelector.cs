using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] public RectTransform spawnedCharacters;
    [SerializeField] private Image player1Image;         // this is a regular Image from the scene
    [SerializeField] private Image opponentImage;        // same here

    [Header("Buttons / UI")]
    [SerializeField] private Button reselectButton;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject playerOneSelectionPanel;
    [SerializeField] private GameObject opponentPlayerSelectionPanel;

    [System.Serializable]
    public class CharacterData
    {
        public string characterName;
        public GameObject playerPrefab;
        public GameObject aiPrefab;
        public Sprite selectionSprite;
    }

    [Header("Character List")]
    [SerializeField] private List<CharacterData> characters;

    private GameObject opponentPlayerCharacterRef;

    void Awake()
    {
        if (!spawnedCharacters || !player1Image || !opponentImage)
        {
            Debug.LogError("Missing UI references on CharacterSelection!");
        }
    }

    public void UpdateCharacterSelectionForPlayerOne(string charName)
    {
        ClearChildren(spawnedCharacters);
        player1Image.sprite = null;

        var data = characters.Find(c => c.characterName == charName);
        if (data == null)
        {
            Debug.LogWarning("Character not found: " + charName);
            return;
        }

        // Instantiate actual fighter prefab
        GameObject playerCharacter = Instantiate(data.playerPrefab, spawnedCharacters);
        GameManager.instance.oneVsOnePlayerOneSelection = playerCharacter;

        // Just assign the sprite
        player1Image.sprite = data.selectionSprite;

        reselectButton.gameObject.SetActive(true);
        playerOneSelectionPanel.SetActive(false);
        opponentPlayerSelectionPanel.SetActive(true);
    }

    public void UpdateCharacterSelectionForPlayerOpponent(string charName)
    {
        if (opponentPlayerCharacterRef != null)
        {
            Destroy(opponentPlayerCharacterRef);
            opponentPlayerCharacterRef = null;
        }

        opponentImage.sprite = null;

        var data = characters.Find(c => c.characterName == charName);
        if (data == null)
        {
            Debug.LogWarning("Character not found: " + charName);
            return;
        }

        opponentPlayerCharacterRef = Instantiate(data.aiPrefab, spawnedCharacters);
        GameManager.instance.oneVsOnePlayerOpponentSelection = opponentPlayerCharacterRef;

        opponentImage.sprite = data.selectionSprite;

        reselectButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
    }

    private void ClearChildren(RectTransform parent)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }

   
}