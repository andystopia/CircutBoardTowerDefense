﻿using System;
using System.Linq;
using Channel;
using GameGrid;
using TMPro;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class Motherboard : MonoBehaviour, IObserver<EnemyInvasionEvent>
{
    public float startingHp;
    public float hp;
    public TextMeshProUGUI hpText;
    public GameObject gameOverText;
    [SerializeField] private GameManager gameManagerScript;
    [SerializeField] private EnemyPathManager pathManager;

    private MotherboardExclusionZone exclusionZone;

    [SerializeField] private EnemyInvasionEventChannel enemyDeathChannel;

    protected virtual void Awake()
    {
        enemyDeathChannel.Subscribe(this);
        CalculateCorrectTransform();
    }

    // Start is called before the first frame update
    private void Start()
    {
        hp = startingHp;
    }

    // Update is called once per frame
    private void Update()
    {
        hpText.text = $"{hp}/{startingHp}";

        if (hp <= 0) gameOverText.SetActive(true);
    }

    public void UpdateExclusionZone()
    {
        if (exclusionZone == null) exclusionZone = GetComponent<MotherboardExclusionZone>();

        var lastEnemyPathNode = pathManager.GetActivePath().GetExtrapolator().GetMinimalRepresentation().Last();
        Debug.Assert(lastEnemyPathNode.IncomingDirection != null, "firstEnemyPathNode.IncomingDirection != null");
        exclusionZone.SetDirection(lastEnemyPathNode.Location, lastEnemyPathNode.IncomingDirection.Value.Opposite());
    }

    public void CalculateCorrectTransform()
    {
        var firstEnemyPathNode = pathManager.GetActivePath().GetExtrapolator().GetMinimalRepresentation().Last();
        gameObject.transform.position = GridSpaceGlobalSpaceConverter.FromLocation(firstEnemyPathNode.Location, 3);
        // make sure that this thing isn't null.
        Debug.Assert(firstEnemyPathNode.IncomingDirection != null, "firstEnemyPathNode.IncomingDirection != null");
        gameObject.transform.rotation =
            Quaternion.Euler(CardinalDirectionToEuler(firstEnemyPathNode.IncomingDirection.Value));
    }

    private Vector3 CardinalDirectionToEuler(CardinalDirection direction)
    {
        return direction switch
        {
            CardinalDirection.North => new Vector3(0, 0, 0),
            CardinalDirection.South => new Vector3(0, 180, 0),
            CardinalDirection.East => new Vector3(0, 90, 0),
            CardinalDirection.West => new Vector3(0, 270, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
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

    public void OnNext(EnemyInvasionEvent enemyDeathEvent)
    {
        // make sure this object is still alive.
        if (this == null) return;
        hp -= enemyDeathEvent.Enemy.DamageValue;
    }
    
    

    #endregion
}