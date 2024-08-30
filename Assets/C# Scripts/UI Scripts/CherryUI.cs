using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryUI : MonoBehaviour
{
    public int CherryValue;
    public Text CherryCount;

    private void test()
    {
        CherryValue++;                          
        CherryCount.text = CherryValue.ToString();
    }

}
