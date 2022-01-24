using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Ground"&&!hasCrashes)
        {
           
            GetComponent<AudioSource>().PlayOneShot(crashSFX);         
            crashEffect.Play();
           
            Invoke("ReloadScene", loadDelay);
            FindObjectOfType<PlayerController>().DisableControls();
            hasCrashes = true;
        }
    }

   
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
