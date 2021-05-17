using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public GameObject bloodFX;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            BloodEffect();
        }
    }

    void BloodEffect()
    {
        GameObject blood = Instantiate(bloodFX, this.transform.position, transform.rotation);
        blood.GetComponent<ParticleSystem>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
