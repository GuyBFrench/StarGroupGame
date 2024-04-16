using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Events;

public class SlimeEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Material orgMat;
    [SerializeField] private Material flashMat;
    [SerializeField] private Renderer rend;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Image[] hearts;
    [SerializeField] private int heartNum;
    [SerializeField] private int maxHealth;
    private int health;
    public UnityEvent onDeath;
    [SerializeField] private Transform particle;
    [SerializeField] private Transform slimePosition;


    private void Start()
    {
        health = maxHealth;
    }


    private void Update()
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
            onDeath.Invoke();
        }
    }

    public void OnMove()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        agent.SetDestination(player.position);
        yield return new WaitForSeconds(1);
        agent.SetDestination(transform.position);
    }

    public void SetHealth()
    {
        health = maxHealth;
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
        rigidbody.isKinematic = false;
        rigidbody.AddForce(-transform.forward * 50);
        yield return new WaitForSeconds(1f);
        
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
        agent.Warp(transform.position);
        agent.enabled = true;
    }

    public void BeginFlash()
    {
        StartCoroutine(OnFlash());
    }

    private IEnumerator OnFlash()
    {
        
        rend.sharedMaterial = flashMat;
        yield return new WaitForSeconds(0.5f);
        rend.sharedMaterial = orgMat;
        
    }

    public void SpawnParticle()
    {
        particle.position = slimePosition.position;
    }


}
