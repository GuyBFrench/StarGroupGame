/*Credit to the following tutorial for help with this script:
https://www.youtube.com/watch?v=_QajrabyTJc
*/

using System;
using UnityEngine;

public class CharacterMoveBehaviour : MonoBehaviour

{
    [SerializeField] private Animator animator;
    private LookChar playerInput;
    private CharacterController controller;
    private Transform camMain;
    private Transform child;
    [SerializeField] private float rotationSpeed = 4f;

    [SerializeField] private FloatData speed;

    private void Awake()
    {
        playerInput = new LookChar();
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        camMain = Camera.main.transform;
        child = transform.GetChild(0).transform;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    void Update()
    {

        Vector2 movementInput = playerInput.Main.Move.ReadValue<Vector2>();
        Vector3 move = (camMain.forward * movementInput.y + camMain.right * movementInput.x);
        move.y = 0f;
        controller.Move(move * (Time.deltaTime * speed.Value));
        if  (movementInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, camMain.localEulerAngles.y,child.localEulerAngles.z));
            child.rotation = Quaternion.Lerp(child.rotation,rotation, Time.deltaTime * rotationSpeed);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        
    }
    
    
}
