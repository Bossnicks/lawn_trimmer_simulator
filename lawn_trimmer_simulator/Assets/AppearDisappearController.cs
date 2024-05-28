using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearDisappearController : MonoBehaviour
{
    public void Appear()
    {
        gameObject.SetActive(true);
    }
    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}