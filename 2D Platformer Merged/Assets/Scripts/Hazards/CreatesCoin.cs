﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatesCoin : MonoBehaviour
{

    [SerializeField]
    private float maxHealth, knockbackSpeedX = 10f, knockbackSpeedY, knockbackDuration, knockbackDeathSpeedX, knockbackDeathSpeedY, deathTorque;

    private int minCount = 3;
    private int maxCount = 10;
       public bool  coin_activate = false;
             public bool  green_coin_activate = false;
              private GameObject clone;
              private GameObject clone2;
              private GameObject clone3;
              private GameObject clone4;
              private GameObject clone5;

    [SerializeField]
    private bool applyKnockback;
    [SerializeField]
    private GameObject HitParticle;
    [SerializeField]
    private GameObject GreenCoins;
    [SerializeField]
    private GameObject YellowCoins;
    [SerializeField]
    private GameObject BlueCoins;
    [SerializeField]
    private GameObject RedCoins;
    [SerializeField]
    private GameObject PurpleCoins;

    public AttackDetails attackDetails;

    private float currentHealth, knockbackStart;

    private int playerFacingDirection;

    private bool playerOnLeft, knockback, done = false;

    private PlayerController pc;
    private GameObject aliveGO;
    private Rigidbody2D rbAlive;
    private Animator aliveAnim;

    private void Start()
    {
        currentHealth = maxHealth;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        aliveGO = transform.Find("Alive").gameObject;
        aliveAnim = aliveGO.GetComponent<Animator>();
        rbAlive = aliveGO.GetComponent<Rigidbody2D>();
        aliveGO.SetActive(true);
    }

    private void Update()
    {
        checkKnockback();

    }

    public void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;


        if (attackDetails.position.x < aliveGO.transform.position.x)
        {
            playerFacingDirection = 1;
        }
        else
        {
            playerFacingDirection = -1;
        }

        //  Instantiate(hitParticle, Slime.transform.position, Quaternion.Euler(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f)));

        // one or the other should work and randomize the hit particle (make sure to un-comment the serializedfield HitParticle)
        Instantiate(HitParticle, aliveGO.transform.position, Quaternion.Euler(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f)));
        //  Instantiate(HitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360.0f)));

        if (playerFacingDirection == 1)
        {
            playerOnLeft = true;
        }
        else
        {
            playerOnLeft = false;
        }

        aliveAnim.SetBool("hit", true);
        StartCoroutine(Test());

        aliveAnim.SetBool("playerOnLeft", playerOnLeft);
        aliveAnim.SetTrigger("damage");

        if (applyKnockback && currentHealth > 0.0f)
        {
            Knockback();
        }

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Knockback()
    {
        knockback = true;
        knockbackStart = Time.time;
        rbAlive.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
    }

    private void checkKnockback()
    {
        if (Time.time >= knockbackStart + knockbackDuration && knockback)
        {
            knockback = false;
            rbAlive.velocity = new Vector2(0.0f, rbAlive.velocity.y);
        }
    }

    private void Die()
    {

        aliveAnim.SetBool("broke", true);

        StartCoroutine(Test2());

        int count = Random.Range(3, 10); //100% Chance
        int blue_count = Random.Range(2, 7);  //50% Chance
        int yellow_count = Random.Range(1, 5);//25% Chance
        int red_count = Random.Range(0, 1); //10% Chance

        int random_number = Random.Range(0, 100);

       // Debug.Log(count);

        for (int i = 0; i < count; ++i)
        {
             green_coin_activate = true;
            StartCoroutine(Test3());
            clone = (GameObject)Instantiate(GreenCoins, aliveGO.transform.position, Quaternion.identity);
            Destroy (clone, 5.0f);
          

        }
        for (int i = 0; i < blue_count; ++i)
        {
            if (random_number % 2 == 0)
            {
                clone2 = (GameObject)Instantiate(BlueCoins, aliveGO.transform.position, Quaternion.identity);
                Destroy (clone2, 5.0f);
            }


        }
          for (int i = 0; i < yellow_count; ++i)
        {
            if (random_number > 0 && random_number <=25)
            {
                clone3 = (GameObject)Instantiate(YellowCoins, aliveGO.transform.position, Quaternion.identity);
                  Destroy (clone3, 5.0f);
            }
        }
         for (int i = 0; i < red_count; ++i)
        {
            if (random_number > 0 && random_number <=10)
            {
                 clone4 = (GameObject)Instantiate(RedCoins, aliveGO.transform.position, Quaternion.identity);
                   Destroy (clone4, 5.0f);
            }
        }
          coin_activate = true;






    }


    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.2f);
        aliveAnim.SetBool("hit", false);
    }



    IEnumerator Test2()
    {
        yield return new WaitForSeconds(0.9f);
        aliveGO.SetActive(false);
    }
    IEnumerator Test3()
    {
        yield return new WaitForSeconds(0.1f);
        aliveGO.SetActive(false);
    }
    
    



}
