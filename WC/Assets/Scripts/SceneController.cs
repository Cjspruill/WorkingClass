using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] RectTransform spawnedCharacters;
    [SerializeField] Image player1Image;
    [SerializeField] Image opponentImage;

    private void OnEnable()
    {
        //StartCoroutine(SetReferences());

        // Make sure the GameManager gets the fresh container
        if (GameManager.instance != null)
            GameManager.instance.SetUIReferences(spawnedCharacters, player1Image, opponentImage);
    }

    IEnumerator SetReferences()
    {
        yield return new WaitForSeconds(1f);

       
    }
}
