using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboController : MonoBehaviour
{
    [SerializeField] BoxCollider2D attackColliderLeft;
    [SerializeField] BoxCollider2D attackColliderRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableAttackColliderLeft(string value)
    {
        switch (value)
        {
            case "Enable":
                attackColliderLeft.gameObject.SetActive(true);
                break;
            case "Disable":
                attackColliderLeft.gameObject.SetActive(false);
                break;
        }
    }

    public void EnableAttackColliderRight(string value)
    {
        switch (value)
        {
            case "Enable":
                attackColliderRight.gameObject.SetActive(true);
                break;
            case "Disable":
                attackColliderRight.gameObject.SetActive(false);
                break;
        }
    }
}
