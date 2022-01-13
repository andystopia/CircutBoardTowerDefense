using UnityEngine;

public class DestroySoon : MonoBehaviour
{
    public float destroyTimer;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}