using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    bool OneGround;

    Vector3 velocity;
    Vector3 offSet;

    float jumpHeight, radius;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
