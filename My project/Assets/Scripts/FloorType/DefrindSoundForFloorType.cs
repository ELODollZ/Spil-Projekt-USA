using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefrindSoundForFloorType : MonoBehaviour
{
    [SerializeField]
    UnityEvent woodEvent, stoneEvent, carpetEvent, metalEvent;

    [SerializeField]
    LayerMask floorLayer;

    public void TestForFloor()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.1f, floorLayer);

        if (hit != null)
        {
            FloorType floor = hit.GetComponent<FloorType>();
            switch (floor.floorType)
            {
                case FloorTypes.wood:
                    woodEvent?.Invoke();
                    break;
                case FloorTypes.carpet:
                    carpetEvent?.Invoke();
                    break;
                case FloorTypes.metal:
                    metalEvent?.Invoke();
                    break;
                case FloorTypes.stone:
                    stoneEvent?.Invoke();
                    break;
            }
        }


    }

}
