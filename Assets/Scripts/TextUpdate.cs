using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    public int field;
    Text value;

    // Start is called before the first frame update
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = field.ToString();
    }
}
