using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAndTableController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject TableImg;
    private GameObject AboutImg;
    void Start()
    {
        AboutImg = GameObject.Find("AboutImg");
        TableImg = GameObject.Find("TableA");
        AboutImg.SetActive(false);
        TableImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AppearAbout()
    {
        gameObject.SetActive(true);
    }
    public void DisappearAbout()
    {
        gameObject.SetActive(false);
    }

    public void AppearHint()
    {
        gameObject.SetActive(true);
    }

    public void DisappearHint()
    {
        gameObject.SetActive(false);
    }
}
