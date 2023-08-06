using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator animator;
    public bool enermy;
    public float moveSpeed = 10;

    public ObservableValue<int> HP {get;set;} = new ();
    public ObservableValue<int> EXP = new ();
    public ObservableValue<int> Level = new();
    public ObservableValue<int> Attack = new();

    public int HPMax = 100;

    [SerializeField]
    private ProgressBar progressBarHP;
    [SerializeField]
    private ProgressBar progressBarEXP;

    [SerializeField]
    private int hp = 100;

    [SerializeField]
    private int attack = 10;


    // Start is called before the first frame update
    void Start()
    {
        progressBarEXP.Value = 0;
        if (enermy)
        {
            StartCoroutine(AttackForeverCo());
        }
        HP.OnValueChanged += Character_OnHpChanged;
        HP.Value = hp;

        Attack.Value = attack;

        EXP.OnValueChanged += EXP_OnValueChanged;
    }

    private void EXP_OnValueChanged(int oldValue, int newValue)
    {
        if(newValue >= 100)
        {
            EXP.Value = 0;
            Level.Value++;
        }
        progressBarEXP.Value = (float)newValue / 100;
    }

    private void Character_OnHpChanged(int oldValue, int newValue)
    {
        progressBarHP.Value = (float)newValue / HPMax;
    }

    IEnumerator AttackForeverCo()
    {
        while (true)
        {
            yield return PlayAttackCo();
        }
    }

    IEnumerator PlayAttackCo()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(1.0f);
        animator.ResetTrigger("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (!enermy)
        {
            //鼠标左键按下则攻击
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(PlayAttackCo());
            }

            //A、D键左右移动
            float h = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime);
        }
    }
}
