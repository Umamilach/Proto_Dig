using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBall;
    private float cooldownTimer = 10f;

    private Movement plyMove;
    void Start()
    {
        plyMove = GetComponent<Movement>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && plyMove.CanAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        // pool fireball
        fireBall[FindFireball()].transform.position = firePoint.position;
        fireBall[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int FindFireball()
    {
        for (int i = 0; i < fireBall.Length; i++)
        {
            if (!fireBall[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
