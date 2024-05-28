using Assets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableResultController : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI characterName;
    private TextMeshProUGUI ostrSum;
    private TextMeshProUGUI srednSum;
    private TextMeshProUGUI slabSum;
    private TextMeshProUGUI itog;
    private TMP_InputField inputField;
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        characterName = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        ostrSum = GameObject.Find("OstrSum").GetComponent<TextMeshProUGUI>();
        srednSum = GameObject.Find("SrednSum").GetComponent <TextMeshProUGUI>();
        slabSum = GameObject.Find("SlabSum").GetComponent<TextMeshProUGUI>();
        itog = GameObject.Find("Itog").GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppearTable()
    {
        RaycastController.enterField.SetActive(false);
        gameObject.SetActive(true);
        characterName.text = inputField.text;
        ostrSum.text = GameController.sumOstraya.ToString();
        srednSum.text = GameController.sumSrednya.ToString();
        slabSum.text = GameController.sumSlabaya.ToString();
        float lineDurabilityResult = GameController.Instance.currentLineType == GameController.LineType.Strong ? 1f : GameController.Instance.currentLineType == GameController.LineType.Medium ? 0.8f : 0.6f;
        itog.text = (GameController.sumSlabaya * 200 * 0.6f +  GameController.sumSrednya * 100 * 0.8f + GameController.sumOstraya * 50 * 1f + lineDurabilityResult + GameController.flowerCount * 20f).ToString();

    }
}
