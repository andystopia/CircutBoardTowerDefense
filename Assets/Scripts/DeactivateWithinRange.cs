using System.Collections.Generic;
using UnityEngine;

public class DeactivateWithinRange : MonoBehaviour
{
    public List<GameObject> tilesToDisable;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    private void Update()
    {
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        if (collision.gameObject.CompareTag("Tile"))
        {
            var isAvailable = true;
            foreach (var ti in tilesToDisable)
                if (ti == collision.gameObject)
                    isAvailable = false;
            if (isAvailable)
            {
                tilesToDisable.Add(collision.gameObject);
                Debug.Log("Deactivate This One");
            }
        }
    }
}