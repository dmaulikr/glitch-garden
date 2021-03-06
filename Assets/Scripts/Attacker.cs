﻿using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(-1f, 1.5f)]
    public float walkSpeed;
    public AudioClip strikeSound;

    private Animator animator;
    private GameObject currentTarget;
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetSpeed(float speed)
    {
        walkSpeed = speed;
    }

    // This method is called by event from Lizard's attacking animation (motion clip)
    // and hence the damage is applied from there
    public void StrikeCurrentTarget(float damage)
    {
        AudioSource.PlayClipAtPoint(strikeSound, transform.position);
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.Damage(damage);
            }
        }
    }

    public void attack(GameObject defender)
    {
        currentTarget = defender;
    }
}
