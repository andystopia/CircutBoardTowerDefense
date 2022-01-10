using InterpolationFunction;
using UnityEngine;

public class TileRangeIndicatorFadeUsingGameObject : TileRangeIndicatorUsingGameObject
{
    private InterpolationFunction.InterpolationFunction interpolationFunc =
        CubicBezierInterpolator.EaseInOut;

    private float rangeTarget = 0.0f;
    private float startingRange = 0.0f;
    private float currentRange = 0.0f;
    private int currentFrame = 0;

    [SerializeField] private int frameDuration;
    
    private void Awake()
    {
    }
    public override void Show()
    {
        currentFrame = 0;
        currentRange = 0;
        base.SetRange(0);
        base.Show();
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