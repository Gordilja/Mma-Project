using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveUpCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            StartCoroutine(cdTime());
        }
    }

    IEnumerator cdTime() 
    {
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<MeshCollider>().enabled = true;
    }
}
