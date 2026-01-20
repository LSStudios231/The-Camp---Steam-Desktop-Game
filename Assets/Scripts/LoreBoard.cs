using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreBoard : MonoBehaviour
{
    public GameObject loreCanvas;

    public AudioSource clipboardSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loreCanvas.SetActive(true);
            clipboardSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            loreCanvas.SetActive(false);
            clipboardSound.Play();
        }
    }
}
