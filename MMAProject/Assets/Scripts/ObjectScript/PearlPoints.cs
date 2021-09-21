using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().pearlPlay();
            FindObjectOfType<GameManager>().scoreUp();
        }
    }
}
