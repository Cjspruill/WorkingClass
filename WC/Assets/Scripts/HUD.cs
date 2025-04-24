using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] Slider playerOneHealthSlider;
    [SerializeField] Slider playerOpponentHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        playerOneHealthSlider.maxValue = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<Health>().maxHealth;
        playerOpponentHealthSlider.maxValue = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<Health>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerOneHealthSlider.value = GameManager.instance.oneVsOnePlayerOneSelection.GetComponent<Health>().GetHealth;
        playerOpponentHealthSlider.value = GameManager.instance.oneVsOnePlayerOpponentSelection.GetComponent<Health>().GetHealth;
    }
}
