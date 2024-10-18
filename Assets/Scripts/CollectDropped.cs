using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDropped : MonoBehaviour
{
    GameObject iSystem;
    void Start()
    {
        iSystem = GameObject.Find("InventorySys");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Coin")
            {
                iSystem.GetComponent<Inventory>().goldCount += 1;
            }
            Destroy(gameObject);
        }
    }
}
