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
    [SerializeField] private CharacterController controller;
    private Transform camMain;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button rollButton;
    public UnityEvent strikeEvent, offStrikeEvent, onCharDeath, onItemEvent;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Image[] hearts;
    [SerializeField] private FloatData heartNum;
    [SerializeField] private FloatData health;
    private bool canLose = true;
    [SerializeField] private Material orgMat;
    [SerializeField] private Material flashMat;
    [SerializeField] private Renderer rendBody;
    [SerializeField] private Renderer rendSword;
    [SerializeField] private Renderer rendHead;
    [SerializeField] private Renderer rendFeet;
    [SerializeField] private Material orgHeadMat;
    [SerializeField] private Material orgSwordMat;
    
    
    


    [SerializeField] private FloatData speed;

    public bool canMove = true;

    private void Awake()
    {
        playerInput = new LookChar();
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
                animator.SetBool("IsHurt", false);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
                if (health.Value < 2)
                {
                    animator.SetBool("IsHurt", true);
                }

                else
                {
                    animator.SetBool("IsHurt", false);
                }
            }
        }
        
        
    
    if (health.Value > heartNum.Value)
        {
            health.Value = heartNum.Value;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health.Value)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < heartNum.Value)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health.Value <= 0)
        {
            canMove = false;
            animator.SetBool("IsHurt", false);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsDead", true);
            
            onCharDeath.Invoke();

        }
    }

    public void isRoll()
    {
        
        canMove = false;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsRoll", true);
        rollButton.onClick.AddListener(() =>
        {
            rollButton.interactable = false;
        });

        StartCoroutine(WaitForReactiveRoll());
        StartCoroutine(WaitForAnim("IsRoll"));
    }

    public void loseHealth()
    {
        if (canLose)
        {
            health.Value -= 1;
        }
    }

    public void BeginRollForward()
    {
        StartCoroutine(OnRollForward());
    }

    private IEnumerator OnRollForward()
    {
        float startTime = Time.time;

        while (Time.time < startTime + 1)
        {
            controller.Move(transform.forward * 8 * Time.deltaTime);
            yield return null;
        }
    }
    public void BeginFlash()
    {
        if (canLose && health.Value > 0)
        {
            
            StartCoroutine(OnFlash());
        }
    }

    private IEnumerator OnFlash()
    {
        
        rendBody.sharedMaterial = flashMat;
        rendFeet.sharedMaterial = flashMat;
        rendHead.sharedMaterial = flashMat;
        rendSword.sharedMaterial = flashMat;
        yield return new WaitForSeconds(1f);
        rendBody.sharedMaterial = orgMat;
        rendFeet.sharedMaterial = orgMat;
        rendSword.sharedMaterial = orgSwordMat;
        rendHead.sharedMaterial = orgHeadMat;
        

    }

    public void isInvincible()
    {
        canLose = false;
        StartCoroutine(Invincible());
    }

    private IEnumerator Invincible()
    {
        yield return new WaitForSeconds(2.5f);
        canLose = true;
    }
    public void isAttack()
    {
        canMove = false;
        
        
        
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsAttack", true);
        
        
        
        attackButton.onClick.AddListener(() =>
        {
            attackButton.interactable = false;
        });
    
        StartCoroutine(WaitForReactiveAttack());
        StartCoroutine(WaitForAnim("IsAttack"));

    }

    public void onStrike()
    {
        strikeEvent.Invoke();
    }

    public void offStrike()
    {
        offStrikeEvent.Invoke();
    }

    private IEnumerator WaitForAnim(string animName)
    {
        float animWait = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;

        
        
        animWait *= 0.75f;
        

        yield return new WaitForSeconds(animWait);
        
        animator.SetBool(animName, false);
        
    }

    private IEnumerator WaitForReactiveAttack()
    {
        yield return new WaitForSeconds(1);
        canMove = true;
        yield return new WaitForSeconds(2.5f);
        attackButton.interactable = true;
        
        
    }
    
    private IEnumerator WaitForReactiveRoll()
    {
        yield return new WaitForSeconds(1);
        canMove = true;
        yield return new WaitForSeconds(7);
        rollButton.interactable = true;
        
    }

    public void stopMovement()
    {
        canMove = false;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsHurt", false);
    }
    public void OnItemGain()
    {
        
        animator.SetBool("IsItem", true);
        StartCoroutine(ItemGain());
    }

    private IEnumerator ItemGain()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        animator.SetBool("IsItem", false);
        heartNum.Value += 1;
        health.Value = heartNum.Value;
        canMove = true;
        onItemEvent.Invoke();
    }

    public void BeginCheer()
    {
        Debug.Log("Entered");
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsHurt", false);
        animator.SetBool("IsCheer", true);
    }

    public void EndCheer()
    {
        animator.SetBool("IsCheer", false);
    }
    
}
