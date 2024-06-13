using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    PlayerGravity playerGravity;
    Transform camTransform, throwPoint;
    Weapon weapon;
    GameObject granade;

    Vector3 direction;
    Vector2 camDirection;

    const float speed = 0;
    float verticalRotation, mouseSensitivy;
    bool shooting, crouching;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();
        camTransform = gameObject.transform.GetChild(0);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
