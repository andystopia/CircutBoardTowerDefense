using InterpolationFunction;
using UnityEngine;

public class TileRangeIndicatorFadeUsingGameObject : TileRangeIndicatorUsingGameObject
{
    [SerializeField] private int frameDuration;
    private int currentFrame;
    private float currentRange;

    private readonly InterpolationFunction.InterpolationFunction interpolationFunc =
        CubicBezierInterpolator.EaseInOut;

    private float rangeTarget;
    private float startingRange;

    private void Awake()
    {
    }


    protected virtual void Update()
    {
        if (currentFrame <= frameDuration)
        {
            currentRange = InterpolationHelper.Lerp(startingRange, rangeTarget,
                interpolationFunc.Transform((float) currentFrame / frameDuration));
            base.SetRange(currentRange);
        }
        else if (rangeTarget == 0 && isActiveAndEnabled)
        {
            base.Hide();
        }

        currentFrame += 1;
    }

    public override void Show()
    {
        currentFrame = 0;
        currentRange = 0;
        base.SetRange(0);
        base.Show();
    }

    public override void Hide()
    {
        rangeTarget = 0;
        currentRange = 0;
        currentFrame = 0;
        base.Hide();
    }

    public override void SetRange(float range)
    {
        currentFrame = 0;
        rangeTarget = range;
        startingRange = currentRange;
        base.SetRange(startingRange);
        // base.SetRange(range);
    }
}