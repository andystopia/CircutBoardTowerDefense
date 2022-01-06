
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class GameObjectHelper
{
    /// <summary>
    /// Calculates the bounding box of an object, given it's renderer's,
    /// and it's child renderers.
    ///
    /// If you pass null in for child renderers, then it will just calculate
    /// based on the sole renderer, which is really sweet.
    ///
    /// If the first two arguments are null, it returns a zero extent bounding
    /// box centered at the position.
    /// </summary>
    /// <param name="renderer"> active object renderer </param>
    /// <param name="childRenderers"> all the sub renderers </param>
    /// <param name="position"> the position of the active game object </param>
    /// <returns></returns>
    public static Bounds GetBounds(Renderer renderer, Renderer[] childRenderers, Vector3 position)
    {
        Bounds bounds = new Bounds();
        if (renderer == null)
        {
            if (childRenderers == null || childRenderers.Length == 0)
            {
                bounds.center = position;
                bounds.extents = Vector3.zero;
                return bounds;
            }

            bounds.center = childRenderers[0].bounds.center;
            bounds.extents = childRenderers[0].bounds.extents;
            
        }
        else
        {
            var rendererBounds = renderer.bounds;
            bounds.center = rendererBounds.center;
            bounds.extents = rendererBounds.extents;
        }
        
        foreach (var childRenderer in childRenderers)
        {
            bounds.Encapsulate(childRenderer.bounds);
        }

        return bounds;
    }

    private class ReferenceEq<A>: IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
            return ReferenceEquals(x, y);
        }

        public int GetHashCode(A obj)
        {
            return obj.GetHashCode();
        }
    }
    
    /// <summary>
    /// Checks that this is the only object
    /// that implements a given interface on a given
    /// object. Note does not check if they could share
    /// a parent interface of the passed interface.
    ///
    /// Note that since this call is expensive, you MUST
    /// be in DEBUG mode!
    /// </summary>
    /// <param name="obj"> the object to check.</param>
    /// <typeparam name="T"> the type to ensure uniqueness</typeparam>
    public static void AssertOnlyComponentOfType<T>(MonoBehaviour obj) where T: class
    {
        if (!Debug.isDebugBuild) return;
        // note that the below works because GetComponent
        // returns the first instance it finds, so this will
        // pass for the first instance, but fail once the 
        // second instance attempts to check the comparision.
        T objT = obj as T;

        if (objT == null)
        {
            Debug.LogAssertion($"Passed object to ${nameof(AssertOnlyComponentOfType)}<${nameof(T)}> does not implement interface.");
        }
        Assert.AreEqual(objT, obj.GetComponent<T>(), $"Warning game behavior is not the only instance of interface ${nameof(T)} on the object. ", new ReferenceEq<T>());
    }
    
}