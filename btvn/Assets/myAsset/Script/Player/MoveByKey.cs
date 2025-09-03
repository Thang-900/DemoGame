using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    public CharacterController characterController;
    public float movingSpeed;
    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        float hINput=Input.GetAxis("Horizontal");
        float vInput=Input.GetAxis("Vertical");
        Vector3 direction=transform.right*hINput+transform.forward*vInput;
        characterController.SimpleMove(direction * movingSpeed);
    }
}
