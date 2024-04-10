/*Credit to the following tutorial for help with this script:
https://www.youtube.com/watch?v=_QajrabyTJc
*/


using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class CharacterMoveBehaviour : MonoBehaviour

{
    [SerializeField] private Animator animator;
    private LookChar playerInput;
    private CharacterController controller;
    private Transform camMain;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button rollButton;
    public UnityEvent onAttack, offAttack;
    


    [SerializeField] private FloatData speed;

    public bool canMove = true;

    private void Awake()
    {
        playerInput = new LookChar();
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        camMain = Camera.main.transform;
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
        if (canMove)
        {


            Vector2 movementInput = playerInput.Main.Move.ReadValue<Vector2>();
            Vector3 move = (camMain.forward * movementInput.y + camMain.right * movementInput.x);
            move.y = 0f;
            controller.Move(move * (Time.deltaTime * speed.Value));
            if (movementInput != Vector2.zero)
            {

                float targAngle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg + camMain.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0f, targAngle, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }
        
        
    }
    
    public void isRoll()
    {
        
        canMove = false;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsRoll", true);
        rollButton.onClick.AddListener(() =>
        {
            rollButton.interactable = false;
        });

        StartCoroutine(WaitForReactiveRoll());
        StartCoroutine(WaitForAnim("IsRoll"));
    }

    public void isAttack()
    {
        canMove = false;
        
        onAttack.Invoke();
        
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsAttack", true);
        
        
        
        attackButton.onClick.AddListener(() =>
        {
            attackButton.interactable = false;
        });
    
        StartCoroutine(WaitForReactiveAttack());
        StartCoroutine(WaitForAnim("IsAttack"));

    }

    private IEnumerator WaitForAnim(string animName)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        
        animator.SetBool(animName, false);
        offAttack.Invoke();
        canMove = true;
        
        
    }

    private IEnumerator WaitForReactiveAttack()
    {
        yield return new WaitForSeconds(4);
        attackButton.interactable = true;
        
        
    }
    
    private IEnumerator WaitForReactiveRoll()
    {
        yield return new WaitForSeconds(4);
        rollButton.interactable = true;
        
    }
    
}
