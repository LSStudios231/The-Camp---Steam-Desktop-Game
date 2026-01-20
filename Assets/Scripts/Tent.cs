using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tent : MonoBehaviour
{
    public Counter count;

    public Text tentText;

    private bool isPlayerNearby = false;

    public AudioSource tentSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Enabled();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Disabled();
        }
    }
    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            count.AddCount(1);
            Disabled();
            tentSound.Play();
        }
    }
    private void Enabled()
    {
        tentText.enabled = true;
    }
    private void Disabled()
    {
        tentText.enabled = false;
    }


}
