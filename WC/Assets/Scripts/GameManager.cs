using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject registerPrefab;
    [SerializeField] public GameObject scrubsPrefab;
    [SerializeField] public GameObject shiftPrefab;
    [SerializeField] public GameObject bigRigPrefab;
    [SerializeField] public GameObject tenurePrefab;
    [SerializeField] public GameObject mopPrefab;
    [SerializeField] public GameObject palletPrefab;
    [SerializeField] public GameObject echoPrefab;

    public static GameManager instance;

    public enum GameModes
    {
        OneVsOne,
        TwoVsTwo
    }

    public GameModes gameMode;

    [SerializeField] bool choosingAIPlayer = false;

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
