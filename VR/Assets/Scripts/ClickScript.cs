using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public int num;
    public Text Mytxt;
    public GameObject test;
    void FixedUptade()
    {
        num++;
        Mytxt.text = num.ToString();
    }
    public void ClickButton()
    {
        test.SetActive(!(test.activeSelf));
    }
}
