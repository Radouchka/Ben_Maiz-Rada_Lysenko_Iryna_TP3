using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public AudioSource potionSound;
    public int count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("potion"))
        {
            other.gameObject.SetActive(false);
            count++;
            potionSound.Play();
        }
        else if (other.tag == "door")
        {
            doorSound.Play();
        }
    }
}
