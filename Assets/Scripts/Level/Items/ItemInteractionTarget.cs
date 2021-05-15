using UnityEngine;
using UnityEngine.Events;

public class ItemInteractionTarget : MonoBehaviour
{
    [System.Serializable]
    public class Interaction {
        public bool OneTime;
        public UnityEvent Event;
        private bool activated;
        public bool Active => !OneTime || !activated;
        public void OnActivated(){
            if (!Active) return;
            Event.Invoke();
            if (OneTime) activated = true;
        }
    }

    [System.Serializable]
    public class ItemInteraction : Interaction {
        public string ItemID;
    }

    public ItemInteraction[] interactions = new ItemInteraction[0];

    public void Start() {}

    public void TryInsertItem(PickableItem item){
        bool found = false;
        foreach (var interaction in interactions){
            if (interaction.ItemID == item.ID && interaction.Active){
                interaction.OnActivated();
                found = true;
                break;
            }
        }
        if (found){
            foreach (var interaction in interactions)
                if (interaction.Active) return;
            enabled = false;
        } else {
            Door door = GetComponent<Door>();
            if (door != null) door.PlayAudio("wrong_item");
        }
        
    }
}
