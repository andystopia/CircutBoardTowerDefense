using InterpolationFunction;
using UnityEngine;
using VectorInterpolator;

public class TurretShopDisplay : MonoBehaviour, IFloatingUIComponent
{
    [SerializeField] private Vector3 startingPosition;
    [SerializeField] private Vector3 endingPosition;

    [Range(0, 90)] [SerializeField] private int animationFrames;

    [SerializeField] private CommonInterpolators interpolator;
    private PositionInterpolator positionInterpolator;

    public void Update()
    {
        positionInterpolator?.Update();
    }


    public void Show()
    {
        // this is a little bugged, 
        // because it will simply cause
        // the menu to teleport around, 
        // instead of smoothly animate, 
        // when the animation is interupted.
        positionInterpolator = new PositionInterpolator(animationFrames, startingPosition, endingPosition,
            interpolator.GetInterpolationFunction(), transform);
    }

    public void Hide()
    {
        positionInterpolator = new PositionInterpolator(animationFrames, endingPosition, startingPosition,
            interpolator.GetInterpolationFunction(), transform);
    }


    public Vector3 GetDestinationPosition()
    {
        return endingPosition;
    }

    public Vector3 GetStartingPosition()
    {
        return startingPosition;
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }
}