using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Motherboard : MonoBehaviour
{
    public float startingHp;
    public float hp;
    public TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {
        hp = startingHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = ("Motherboard: " + hp + "/" + startingHp);
    }
}
