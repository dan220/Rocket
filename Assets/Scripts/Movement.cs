using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
 
{
    float thrustSpeed = 1000f;
    [SerializeField] float rotateSpeed = 1000f;
    Rigidbody rocketRigidbody;
    AudioSource rocketThrust;
    // Start is called before the first frame update
    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        rocketThrust = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if(Input.GetKey(KeyCode.W))
        {
            ApplyThrust(thrustSpeed);
        }
        
        else{
            rocketThrust.Stop();
        }
        
    }

    private void ApplyThrust(float thrustThisFrame)
    {
        rocketRigidbody.AddRelativeForce(Vector3.up * thrustThisFrame * Time.deltaTime);
        if (!rocketThrust.isPlaying){
             rocketThrust.Play();
        }
    }

    void ProcessRotation(){

        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }

        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotateSpeed);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        // freezing rotation so we can manually rotate
        rocketRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        // unfreezing rotation so we can let the physics system take over
        rocketRigidbody.freezeRotation = false;
    }
}
