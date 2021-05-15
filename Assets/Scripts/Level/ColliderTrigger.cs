using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ColliderTrigger : MonoBehaviour
{
    public ItemInteractionTarget.Interaction interaction;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            interaction?.OnActivated();
    }

}
