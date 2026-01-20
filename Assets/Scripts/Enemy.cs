using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float detectionRadius = 30f;
    public AudioSource scream;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
            {
                Vector3 targetPosition = player.position + new Vector3(0f, 1f, 0f);
                transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
                
                if (!scream.isPlaying)
                {
                    scream.Play();
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameLost");
        }
    }
}
