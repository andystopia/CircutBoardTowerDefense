using System;
using System.Globalization;
using Channel;
using TMPro;
using UnityEngine;

public class EnergyCounter : MonoBehaviour, IObserver<EnemyDeathEvent>
{
    [SerializeField] private float startingEnergy;
    public float Energy { get; set; }
    public TextMeshProUGUI energyText;

    [SerializeField] private EnemyDeathEventChannel deathEventChannel;
    protected virtual void Awake()
    {
        deathEventChannel.Subscribe(this);
    }
    // Start is called before the first frame update
    private void Start()
    {
        Energy = startingEnergy;
    }

    // Update is called once per frame
    private void Update()
    {
        energyText.text = Energy.ToString(CultureInfo.InvariantCulture);
    }
    
    #region EnemyDeath

    public void OnCompleted()
    {
        // do nothing.
    }

    public void OnError(Exception error)
    {
        // do nothing.
    }

    public void OnNext(EnemyDeathEvent value)
    {
        Energy += value.Enemy.EnergyDrop;
    }

    #endregion
}