using System;
using InterpolationFunction;
using UnityEngine;
using VectorInterpolator;

public class FocusIndicator : MonoBehaviour, IFocusIndicator
{
    /// <summary>
    ///  how wide each side of the focus rectangle is.
    /// </summary>
    private readonly float edgeScale = 0.125f;

    private FocusEdge leftEdge;
    private FocusEdge rightEdge;
    private FocusEdge topEdge;
    private FocusEdge bottomEdge;
    

    // names, but there must be a better way to do this.
    private const string LEFT_EDGE_NAME = "LeftEdge";
    private const string RIGHT_EDGE_NAME = "RightEdge";
    private const string BOTTOM_EDGE_NAME = "BottomEdge";
    private const string TOP_EDGE_NAME = "TopEdge";

    [Range(1, 90)] public int AnimationFrameDuration;

    /// <summary>
    /// the dimensions of the focused box.
    /// note: the value of this vector
    /// is variant with the <c>IsFocused</c>
    /// state, so check that there is
    /// a focused element before accessing.
    /// this field.
    ///
    /// the <c>x</c> component is the width,
    /// and the <c>y</c> component is the height.
    /// </summary>
    private Vector2 boundingBoxDimensions;

    /// <summary>
    /// Where we are currently focused
    /// Please use the encapsulation of this field
    /// for setting, as it will maintain state better.
    /// </summary>
    private IFocusable focusedOn;

    // interpolators
    private PositionInterpolator positionInterpolator;
    private VectorInterpolator.VectorInterpolator dimensionInterpolator;
    private VectorInterpolator.VectorInterpolator colorInterpolator;

    // functions for the interpolators
    public CommonInterpolators interpolatorFunction;
    public CommonInterpolators colorInterpolationFunction;

        
    private IFocusable FocusedOn
    {
        get => focusedOn;
        set
        {
            // when we have something to focus on,
            // then we can be visible, 
            // otherwise, when we have nothing `null`
            // set inactive.
            gameObject.SetActive(value != null);
            focusedOn = value;
        }
    }

    /// <summary>
    /// The color of the indicator.
    /// You can change this for various
    /// visual effects.
    ///
    /// Note: you cannot depend on the getter
    /// yielding the actual current color value.
    /// It will return the color of the current
    /// state of the animation, and if the animation
    /// is completed, then it will return whatever
    /// the object requested.
    /// </summary>
    public Color CurrentColor
    {
        get => currentColor;
        set
        {
            leftEdge.Renderer.color = value;
            rightEdge.Renderer.color = value;
            bottomEdge.Renderer.color = value;
            topEdge.Renderer.color = value;
            currentColor = value;
        }
    }

    /// <summary>
    /// Whatever the current color of the this object is.
    /// </summary>
    private Color currentColor;



    public void Awake()
    {
        // give each one the unit vector in each direction from the origin.
        leftEdge = new FocusEdge(transform.Find(LEFT_EDGE_NAME), edgeScale, new Vector3(-1, 0, 0), new Vector3(0, 1, 0));
        rightEdge = new FocusEdge(transform.Find(RIGHT_EDGE_NAME), edgeScale, new Vector3(1, 0, 0), new Vector3(0, 1, 0));
        bottomEdge = new FocusEdge(transform.Find(BOTTOM_EDGE_NAME), edgeScale, new Vector3(0, 0, -1), new Vector3(1, 0, 0));
        topEdge = new FocusEdge(transform.Find(TOP_EDGE_NAME), edgeScale, new Vector3(0, 0, 1), new Vector3(1, 0, 0));
    }
    // Start is called before the first frame update
    void Start()
    {

        // FocusedOn = null;
        
        currentColor = Color.white;
    }

    void Update()
    {
        positionInterpolator?.Update();
        if (dimensionInterpolator != null)
        {
            dimensionInterpolator.Update();
            
            Vector3 currentFrameDimensions = dimensionInterpolator.CurrentValue;
            BoundBoxStateless(currentFrameDimensions.x, currentFrameDimensions.z);
        }

        if (colorInterpolator != null)
        {
            colorInterpolator.Update();
            Vector3 updatedColor = colorInterpolator.CurrentValue;

            CurrentColor = new HSVColor(updatedColor);
        }
    }
    
    
    /// <summary>
    /// Centers the box at a certain position.
    /// 
    /// </summary>
    /// <param name="center"></param>
    void AnimateCenterAt(Vector3 center)
    {
        var transformPosition = transform.position;
        transformPosition.x = center.x;
        transformPosition.z = center.z;

 
        positionInterpolator = new PositionInterpolator(AnimationFrameDuration, transform.position, transformPosition, interpolatorFunction.GetInterpolationFunction(), transform);
    }

    /// <summary>
    /// Request the focus box to focus on a certain object
    /// and also have the focus box animate to a certain
    /// color.
    /// </summary>
    /// <param name="focusable"></param>
    /// <param name="targetColor"></param>
    public void FocusOn(IFocusable focusable, Color targetColor)
    {
        FocusedOn = focusable;

        // animate the colors.
        colorInterpolator = new VectorInterpolator.VectorInterpolator(
            new HSVColor(CurrentColor).AsVector(), 
            new HSVColor(targetColor).AsVector(), AnimationFrameDuration,
            colorInterpolationFunction.GetInterpolationFunction());
        
        if (focusable == null)
        {
            return;
        }
        
        // gotta make sure we are always on the top, so preserve the current `y`.
        AnimateCenterAt(focusable.FocusBounds.center);

        // get the bounds of the focusable.
        AnimateBoundBox(focusable.FocusBounds.extents);
    }
    /// <summary>
    /// Request the focus box to focus on a certain
    /// object.
    /// </summary>
    /// <param name="focusable"> the object to focus on.</param>
    public void FocusOn(IFocusable focusable)
    {
        FocusOn(focusable, Color.white);
    }
    

    /// <summary>
    /// Bound the focus around a vector3's x and z components.
    /// </summary>
    /// <param name="focusBoundExtents"></param>
    private void BoundBox(Vector3 focusBoundExtents)
    {
        BoundBox(focusBoundExtents.x, focusBoundExtents.z);
    }

    /// <summary>
    /// Animate the bounding of the box around a vector3's x and z components.
    /// </summary>
    /// <param name="focusBoundExtents"></param>
    public void AnimateBoundBox(Vector3 focusBoundExtents)
    {
        var startingDimensions = new Vector3(boundingBoxDimensions.x, 0, boundingBoxDimensions.y);
        var destinationDimensions = new Vector3(focusBoundExtents.x, 0, focusBoundExtents.z);
        dimensionInterpolator = new VectorInterpolator.VectorInterpolator(startingDimensions, destinationDimensions, AnimationFrameDuration,
            interpolatorFunction.GetInterpolationFunction());
        BoundBox(focusBoundExtents);
    }


    /// <summary>
    /// Bound the box around a given width and height,
    /// updating the <c>boundingBoxDimensions</c>
    /// field.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    private void BoundBox(float width, float height)
    {
        BoundBoxStateless(width, height);
        boundingBoxDimensions.x = width;
        boundingBoxDimensions.y = height;
    }
    /// <summary>
    /// This method will just set the width of the
    /// box without updating the state of boundingBoxDimensions.
    /// As such, in order to to maintain behavior,
    /// this method should be used with great caution.
    /// Things such animations make sense to use this function.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    private void BoundBoxStateless(float width, float height)
    {
        float farEdgeWidth = height + edgeScale;
        float farEdgeHeight = width + edgeScale;

        float lengthHorizontal = farEdgeHeight * 2;
        float lengthVertical = farEdgeWidth * 2;

        leftEdge.FarEdgeDistance = farEdgeHeight;
        rightEdge.FarEdgeDistance = farEdgeHeight;
        bottomEdge.FarEdgeDistance = farEdgeWidth;
        topEdge.FarEdgeDistance = farEdgeWidth;
        
        leftEdge.Length = lengthVertical;
        rightEdge.Length = lengthVertical;
        bottomEdge.Length = lengthHorizontal;
        topEdge.Length = lengthHorizontal;
    }

    /// <summary>
    /// Stops focusing on a given object if it the
    /// focus is on that object.
    /// </summary>
    /// <param name="focusable"></param>
    public void StopFocusOn(IFocusable focusable)
    {
        if (ReferenceEquals(FocusedOn, focusable))
        {
            FocusedOn = null;
        }
    }
}