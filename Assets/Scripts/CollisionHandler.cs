using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crash;

    AudioSource crashSound;

    void Start(){
        crashSound = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision other) {
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

    void StartCrashSequence(){
        crashSound.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void NextLevelSequence(){
        GetComponent<Movement>().enabled = false;
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
