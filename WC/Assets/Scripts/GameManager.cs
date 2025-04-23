using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static GameManager instance;

    public enum GameModes
    {
        OneVsOne,
        TwoVsTwo
    }

    public GameModes gameMode;


    [SerializeField] public GameObject oneVsOnePlayerOneSelection;
    [SerializeField] public GameObject oneVsOnePlayerOpponentSelection;

    [SerializeField] public GameObject TwoVsTwoPlayerOneSelectionOne;
    [SerializeField] public GameObject TwoVsTwoPlayerOneSelectionTwo;

    [SerializeField] public GameObject TwoVsTwoPlayerOpponentSelectionOne;
    [SerializeField] public GameObject TwoVsTwoPlayerOppoenntSelectionTwo;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
}
