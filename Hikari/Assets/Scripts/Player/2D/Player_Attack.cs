using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public int Damage;
    [SerializeField] private Inputs Inputs;
    void Update()
    {
        if(Inputs.Attack == true)
        {
            print("Attacking");
        }
    }
}
