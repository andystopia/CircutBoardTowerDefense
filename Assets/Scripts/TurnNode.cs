using UnityEngine;

public class TurnNode : MonoBehaviour
{
    public GameObject nextNode;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }


    private void OnTriggerStay(Collider other)
    {
        // if (other.transform.position.Equals(transform.position))
        // {
        //     other.GetComponent<Enemy>().nextNode = nextNode;
        //     other.transform.LookAt(nextNode.transform);
        // }
    }
}