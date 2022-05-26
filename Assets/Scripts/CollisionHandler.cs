using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    bool collisionsDisabled = false;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    void Update(){
        if(Input.GetKey(KeyCode.C))
        {
            collisionsDisabled = true;
        }
    }
    
    void OnCollisionEnter(Collision other) {
        if (collisionsDisabled == true){
            return;
        }
        else if (!isTransitioning){
            switch(other.gameObject.tag){
                case "Friendly":
                    break;

                case "Finish":
                    NextLevelSequence();
                    break;

                default:
                    StartCrashSequence();
                    break;
            }
        }
    }

    void StartCrashSequence(){
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        crashParticles.Play();
        Invoke("ReloadLevel", delay);
    }

    void NextLevelSequence(){
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        successParticles.Play();
        Invoke("LoadNextLevel", delay);
    }

    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
