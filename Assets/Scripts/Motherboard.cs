using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Motherboard : MonoBehaviour
{
    public float startingHp;
    public float hp;
    public TextMeshProUGUI hpText;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        hp = startingHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = ("Motherboard: " + hp + "/" + startingHp);

        if (hp <= 0)
        {
            gameOverText.SetActive(true);
        }
    }
}
