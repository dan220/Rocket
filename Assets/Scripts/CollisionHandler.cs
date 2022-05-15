using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag){
            case "Friendly":
                Debug.Log("Start the game");
                break;

            case "Finish":
                Debug.Log("Congratulations you've finished the level");
                break;

            default:
                Debug.Log("You have died");
                break;
        }
    }
}
