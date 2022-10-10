using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgPlayer : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(other.gameObject);
    }
}
