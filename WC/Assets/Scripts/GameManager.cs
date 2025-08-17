using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // at the top

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


    public static GameManager instance;


    int player1Wins;
    int player2Wins;

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

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(instance);
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

        round++;
    }

    public void EndRound()
    {
        GetRoundActive = false;
        OnRoundEnd?.Invoke();
        // You can trigger end-round UI, winner logic etc. here

        if(player1Wins < 2 || player2Wins < 2)
        {
            if(GetRound < 3)
            {
                StartCoroutine(BetweenRound());
            }
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
}
