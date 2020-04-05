﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterAttack : MonoBehaviour
{
    //public float speed = 1; 
    Vector3 speed = new Vector3(0,0.5f,0);
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 7){
        transform.position += speed * Time.deltaTime;
        }
        else if(transform.position.y < 72 && transform.position.y > 7){
        transform.position += speed * Time.deltaTime * 2;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            print("meh" + other);
            canvas.SetActive(true);
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}