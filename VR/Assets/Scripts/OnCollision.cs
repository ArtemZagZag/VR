using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OnCollision : MonoBehaviour
{
    public int num = 10;
    public Text Mytxt;
    void FixedUpdate()
    {
    }
    public void OnCollisionEnter(Collision collision)
    {
        num--;
        Mytxt.text = num.ToString();
    }
}
