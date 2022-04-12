using System;
using UnityEngine;

namespace KeyboardEventSystem
{
    /// <summary>
    /// Represents a given keymapping of a game.
    ///
    /// If being implemented for a new project,
    /// everything between the braces can be cleared,
    /// and then the syntax for specifying keys is simply
    ///
    /// <code>
    /// [SerializeField] private Key keyName;
    /// [SerializeField] private Key otherKeyName;
    /// </code>
    ///
    /// Note that you should not provide the key here.
    /// Instead create an instance of the scriptable object
    /// and then use them from there.
    ///
    /// Also because of good practices since all the
    /// keys are private, use your IDE to generate
    /// Read-Only Properties for all the fields. So that
    /// you can use them outside of the class.
    ///
    /// Note that Key is just an implementation, the class
    /// is not sealed, so feel free to extend it, and
    /// there's nothing special about the key type so
    /// you can even use your own types, but the Key
    /// type is a great starting point for setup right
    /// "out of the box"
    /// </summary>
    [CreateAssetMenu(fileName = "KeyMapping", menuName = "KeyMappings/KeyMapping", order = 0)]
    public class KeyMapping : ScriptableObject
    {

        [SerializeField] private SingleKey cancelOperationKey;
        [SerializeField] private DirectionalKeyDPad mainMenuMove;
        [SerializeField] private DirectionalKeyDPad focusIndicatorMove;
        [SerializeField] private MultiKey clickKey;
        [SerializeField] private SingleKey placeTurret;
        [SerializeField] private SingleKey sellTurret;
        [SerializeField] private SingleKey menuAndBack;
        [SerializeField] private SingleKey showScoreboard;
        [SerializeField] private SingleKey summonWave;
        [SerializeField] private SingleKey advanceThroughList;
        [SerializeField] private SingleKey regressThroughList;
        [SerializeField] private SingleKey pause;

        public SingleKey Pause => pause;

        public SingleKey AdvanceThroughList => advanceThroughList;

        public SingleKey RegressThroughList => regressThroughList;

        public SingleKey SummonWave => summonWave;

        public SingleKey MenuAndBack => menuAndBack;

        public SingleKey ShowScoreboard => showScoreboard;

        public SingleKey CancelOperationKey => cancelOperationKey;

        public DirectionalKeyDPad MainMenuMove => mainMenuMove;

        public DirectionalKeyDPad FocusIndicatorMove => focusIndicatorMove;

        public MultiKey ClickKey => clickKey;

        public SingleKey PlaceTurret => placeTurret;

        public SingleKey SellTurret => sellTurret;
    }
}