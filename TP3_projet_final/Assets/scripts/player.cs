using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public string sceneName;
    public AudioSource potionSound;
    public int count;
    public GameObject lastPotion;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);

        if (other.CompareTag("potion"))
        {
            other.gameObject.SetActive(false);
            count++;
            potionSound.Play();
        }

        if (other.CompareTag("castle"))
        {
            SceneManager.LoadScene(sceneName);
        }

        if (other.CompareTag("indoor"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}