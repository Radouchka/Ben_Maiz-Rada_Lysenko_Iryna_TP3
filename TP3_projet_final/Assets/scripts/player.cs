using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public AudioSource potionSound;
    public int count;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);
        if (other.CompareTag("potion"))
        {
            other.gameObject.SetActive(false);
            count++;
            potionSound.Play();
        }
    }
}
