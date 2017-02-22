﻿using UnityEngine;

[RequireComponent(typeof(ReduceSize))]
public class Trash : Obstacle
{
    public int value;
    public float deathtime;

    private GameManager _gm;

    void Awake()
    {
        Invoke("die", deathtime);
    }

    void Start()
    {
        gameObject.GetComponent<Animator>().speed = .25f;
        GameObject obj = GameObject.FindGameObjectWithTag("GM");
        if(obj)
        {
            _gm = obj.GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Grow(gameObject.tag);
            _gm.ScoredTrashTriggered(value);
            Destroy(gameObject);
        }
    }

    void die()
    {
        gameObject.GetComponent<ReduceSize>().ChangeSize();
    }
}
