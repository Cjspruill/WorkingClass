using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // at the top
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject bigRigPlayerPrefab;
    [SerializeField] public GameObject echoPlayerPrefab;
    [SerializeField] public GameObject mopPlayerPrefab;
    [SerializeField] public GameObject palletPlayerPrefab;
    [SerializeField] public GameObject registerPlayerPrefab;
    [SerializeField] public GameObject scrubsPlayerPrefab;
    [SerializeField] public GameObject shiftPlayerPrefab;
    [SerializeField] public GameObject tenurePlayerPrefab;

    [SerializeField] public GameObject bigRigAIPrefab;
    [SerializeField] public GameObject echoAIPrefab;
    [SerializeField] public GameObject mopAIPrefab;
    [SerializeField] public GameObject palletAIPrefab;
    [SerializeField] public GameObject registerAIPrefab;
    [SerializeField] public GameObject scrubsAIPrefab;
    [SerializeField] public GameObject shiftAIPrefab;
    [SerializeField] public GameObject tenureAIPrefab;

    [SerializeField] int round = 1;
    [SerializeField] float roundTime = 90f;
    [SerializeField] float roundTimer;
    bool roundActive = false;

    public delegate void RoundEvent();
    public static event RoundEvent OnRoundStart;
    public static event RoundEvent OnRoundEnd;

    public delegate void GameEvent();
    public static event GameEvent OnEndGame;

    public static GameManager instance;


    [SerializeField] int player1Wins = 0;
    [SerializeField] int player2Wins = 0;

    [SerializeField] RectTransform spawnedCharacters;
    private Image player1Image;
    private Image opponentImage;

    public enum GameModes
    {
        OneVsOne,
        TwoVsTwo
    }

    public GameModes gameMode;


    [SerializeField] public GameObject oneVsOnePlayerOneSelection;
    [SerializeField] public GameObject oneVsOnePlayerOpponentSelection;

    public float GetRoundTimer { get => roundTimer; set => roundTimer = value; }
    public int GetRound { get => round; set => round = value; }
    public bool GetRoundActive { get => roundActive; set => roundActive = value; }
    public int GetPlayer1Wins { get => player1Wins; set => player1Wins = value; }
    public int GetPlayer2Wins { get => player2Wins; set => player2Wins = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // note: gameObject, not instance
        }
        else if (instance != this)
        {
            Destroy(gameObject); // destroy duplicate GameManager
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")  // Replace with your actual scene name
        {
            StartCoroutine(BeginRoundWithDelay());
        }
       
    }

    private IEnumerator BeginRoundWithDelay()
    {
        yield return new WaitForSeconds(2f);
        StartRound();
    }

    private void StartRound()
    {
        GetRoundTimer = roundTime;
        GetRoundActive = true;

        OnRoundStart?.Invoke();
    }

    public void EndRound()
    {
        GetRoundActive = false;
        OnRoundEnd?.Invoke();

        round++; // <-- move it here

        if (player1Wins < 2 && player2Wins < 2) // logical AND instead of OR
        {
            StartCoroutine(BetweenRound());
        }
        else
        {
            OnEndGame?.Invoke();
        }
    }

    private void Update()
    {
        if (GetRoundActive)
        {
            GetRoundTimer -= Time.deltaTime;

            if (GetRoundTimer <= 0f)
            {
                GetRoundTimer = 0f;
                EndRound();
            }
        }
    }

    public void SetGameMode(string newGameMode)
    {
        switch (newGameMode)
        {
            case "OneVsOne":
                gameMode = GameModes.OneVsOne;
                break;
            case "TwoVsTwo":
                gameMode = GameModes.TwoVsTwo;
                break;
        }
    }

    IEnumerator BetweenRound()
    {
        yield return new WaitForSeconds(3f);
        StartRound();
    }

    public void EndGame()
    {
        OnEndGame?.Invoke();
    }

    public void RestartGame()
    {
        // Stop any pending coroutines
        StopAllCoroutines();

        // Reset round data
        GetRound = 1;                // start from round 1
        player1Wins = 0;
        player2Wins = 0;
        GetRoundTimer = roundTime;   // reset timer
        GetRoundActive = false;      // ensure round is inactive

        // Start the first round after delay
        StartCoroutine(BeginRoundWithDelay());
    }

    public void ReturnToTitle()
    {
        player1Wins = 0;
        player2Wins = 0;
        GetRound = 0;
        roundActive = false;

        // Clean up character selections
        oneVsOnePlayerOneSelection = null;
        oneVsOnePlayerOpponentSelection = null;

        // destroy spawned children if necessary
        if (spawnedCharacters != null)
        {
            for (int i = spawnedCharacters.childCount - 1; i >= 0; i--)
                Destroy(spawnedCharacters.GetChild(i).gameObject);
        }


            // Optionally destroy or clear the container object itself
            Destroy(spawnedCharacters.gameObject);
            spawnedCharacters = null;
        }
    

    public void PullSpawnedCharacterTransformToGameManager()
    {
        spawnedCharacters.SetParent(gameObject.transform);
    }

    public void SetUIReferences(RectTransform spawned, Image p1, Image opponent)
    {
        spawnedCharacters = spawned;
        player1Image = p1;
        opponentImage = opponent;
    }
}
