using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyCounter : MonoBehaviour
{
    public float startingEnergy;
    public float energy;
    public TextMeshProUGUI energyText;

    // Start is called before the first frame update
    void Start()
    {
        energy = startingEnergy;
        
    }

    // Update is called once per frame
    void Update()
    {
        energyText.text = "" + energy;
    }
}
