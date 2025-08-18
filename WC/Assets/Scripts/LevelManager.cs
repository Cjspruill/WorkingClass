using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject endgamePanel;
    [SerializeField] public Transform[] playerOneStartPositions;
    [SerializeField] public Transform[] playerOpponentStartPositions;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI roundText;


    private void OnEnable()
    {
        GameManager.OnRoundStart += StartRound;
        GameManager.OnEndGame += ShowEndScreen;
    }

    private void OnDisable()
    {
        GameManager.OnRoundStart -= StartRound;
        GameManager.OnEndGame -= ShowEndScreen;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.oneVsOnePlayerOneSelection.gameObject.transform.position = playerOneStartPositions[0].position;
        GameManager.instance.oneVsOnePlayerOpponentSelection.gameObject.transform.position = playerOpponentStartPositions[0].position;
        roundText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        int displayTime = Mathf.FloorToInt(GameManager.instance.GetRoundTimer);
        timerText.text = displayTime.ToString();
    }

    void StartRound()
    {
        roundText.text = "Round " + GameManager.instance.GetRound.ToString();

        StartCoroutine(RemoveRoundTitle());
    }

    IEnumerator RemoveRoundTitle()
    {
        yield return new WaitForSeconds(2f);

        roundText.text = "";
    }

    public void ShowEndScreen()
    {
        endgamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        GameManager.instance.oneVsOnePlayerOneSelection.gameObject.transform.position = playerOneStartPositions[0].position;
        GameManager.instance.oneVsOnePlayerOpponentSelection.gameObject.transform.position = playerOpponentStartPositions[0].position;
        endgamePanel.SetActive(false);
        GameManager.instance.RestartGame();
    }

    public void QuitToTitle()
    {
        GameManager.instance.ReturnToTitle();

        SceneManager.LoadScene("MainMenu");
    }

}
