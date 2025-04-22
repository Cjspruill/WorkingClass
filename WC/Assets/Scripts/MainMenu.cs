using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject[] howToPlayPanels;
    [SerializeField] int howToPlayPanelIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void IncrementHowToPlayPanel()
    {
        howToPlayPanels[howToPlayPanelIndex].gameObject.SetActive(false);

        howToPlayPanelIndex++;

        if (howToPlayPanelIndex >= howToPlayPanels.Length)
        {
            howToPlayPanelIndex = 0;
        }

        howToPlayPanels[howToPlayPanelIndex].gameObject.SetActive(true);
    }

    public void DecrementHowToPlayPanel()
    {
        howToPlayPanels[howToPlayPanelIndex].gameObject.SetActive(false);
        
        howToPlayPanelIndex--;

        if(howToPlayPanelIndex < 0)
        {
            howToPlayPanelIndex = howToPlayPanels.Length - 1;
        }

        howToPlayPanels[howToPlayPanelIndex].gameObject.SetActive(true);
    }
}
