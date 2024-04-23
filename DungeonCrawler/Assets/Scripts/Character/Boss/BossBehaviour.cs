using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;


public class BossBehaviour : MonoBehaviour
{

    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Image[] hearts;
    [SerializeField] private int heartNum;
    [SerializeField] private float health;
    private bool canLose = true;
    [SerializeField] private Material orgMat;
    [SerializeField] private Material flashMat;
    [SerializeField] private Renderer rendBody;
    [SerializeField] private Renderer rendSword;
    [SerializeField] private Renderer rendHead;
    [SerializeField] private Renderer rendFeet;
    [SerializeField] private Material orgHeadMat;
    [SerializeField] private Material orgSwordMat;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Rigidbody rb;
    public UnityEvent deathEvent;



        void Update()
    {
        
    
    if (health > heartNum)
        {
            health = heartNum;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < heartNum)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0)
        {
            animator.SetBool("IsDead",true);
            deathEvent.Invoke();
        }
    }
    
    
    
    
    public void BeginFlashBoss()
    {
        if (canLose && health > 0)
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
    
    
    public void loseHealth()
    {
        health -= 1;
    }
    
    public void CauseKockback()
    {
        StartCoroutine(ApplyKnockback());
    }

    private IEnumerator ApplyKnockback()
    {
        agent.enabled = false;
        rb.isKinematic = false;
        rb.AddForce(-transform.forward * 20);
        yield return new WaitForSeconds(1f);
        
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        agent.Warp(transform.position);
        agent.enabled = true;
    }
}




    
    
    

