using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public Transform[] playerOneStartPositions;
    [SerializeField] public Transform[] playerOpponentStartPositions;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.oneVsOnePlayerOneSelection.gameObject.transform.position = playerOneStartPositions[0].position;
        GameManager.instance.oneVsOnePlayerOpponentSelection.gameObject.transform.position = playerOpponentStartPositions[0].position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
