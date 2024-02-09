using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IceCreamCountUI : MonoBehaviour
{
    private TMP_Text text;

    void Start()
    {
      text = GetComponent<TMP_Text>();
    }

    void Update()
    {
      text.text = IceCream.iceCreamCount.ToString();
    }
}
