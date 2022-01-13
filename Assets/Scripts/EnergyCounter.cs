using TMPro;
using UnityEngine;

public class EnergyCounter : MonoBehaviour
{
    public float startingEnergy;
    public float energy;
    public TextMeshProUGUI energyText;

    // Start is called before the first frame update
    private void Start()
    {
        energy = startingEnergy;
    }

    // Update is called once per frame
    private void Update()
    {
        energyText.text = "" + energy;
    }
}