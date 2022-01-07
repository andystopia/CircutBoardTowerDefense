using System;
using UnityEngine;

public class FocusEdge
{
    private readonly Transform gameObjectTransformation;
    private readonly float edgeScale;
    private readonly Vector3 signOffset;
    private readonly Vector3 scaleMask;

    private readonly SpriteRenderer renderer;
    
    public SpriteRenderer Renderer => renderer; 
    public GameObject gameObject => gameObjectTransformation.gameObject;

    public FocusEdge(Transform gameObjectTransformation, float edgeScale, Vector3 signOffset, Vector3 scaleMask)
    {
        renderer = gameObjectTransformation.gameObject.GetComponent<SpriteRenderer>();
        this.gameObjectTransformation = gameObjectTransformation;
        this.edgeScale = edgeScale;
        this.signOffset = signOffset;
        this.scaleMask = scaleMask;
    }


    public float Length
    {
        get => Vector3.Scale(gameObjectTransformation.localScale, scaleMask).magnitude;
        set
        {
            var localScale = gameObjectTransformation.localScale;

            // essentially contains in one of three channels
            // how long the vector has been scaled.
            // the other two channels will be zero.
            Vector3 currentScale = Vector3.Scale(localScale, scaleMask);
            
            // this one will contain, in one channel,
            // the value we want, and in the other
            // two it will contain zeros.
            Vector3 desiredScale = Vector3.Scale(Vector3.one * value, scaleMask);


            // so now this will contain the difference
            // between the two scales that we want
            // and if we add this to the original
            // it will modify the channel, exactly
            // as expected, leaving the other two's scales
            // as expected.
            Vector3 diff = desiredScale - currentScale;
            
            localScale += diff;
            gameObjectTransformation.localScale = localScale;
        }
    }

    public float FarEdgeDistance
    {
        get
        {
            float len = Distance;

            return len + (edgeScale / 2) * Math.Sign(len);
        }
        set => Distance = value - (edgeScale / 2) * Math.Sign(value);
    }

    public float Distance
    {
        get => Vector3.Scale(gameObjectTransformation.localPosition, signOffset).magnitude;
        set => gameObjectTransformation.localPosition = signOffset * value;
    }
}
