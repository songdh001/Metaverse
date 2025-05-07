using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEKey : MonoBehaviour
{
    public GameObject PopUpUI; // "Press E to Enter" UI 오브젝트

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PopUpUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PopUpUI.SetActive(false);
        }
    }
}
