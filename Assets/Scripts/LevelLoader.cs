using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }

        if (Fuel.fuel <= 0)
        {
            LoadCurrentLevel();
        }
    }

    void LoadNextLevel(){
        
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void LoadCurrentLevel()
    {
        Debug.Log(currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }
}
