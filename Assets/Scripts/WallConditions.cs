using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class WallConditions : MonoBehaviour
{
    public UnityEvent wallPassedEvent;
    private readonly Dictionary<CollisionZone, bool> _conditions = new()
    {
        { CollisionZone.head, false },
        { CollisionZone.leftHand, false },
        { CollisionZone.rightHand, false }
    };

    private void CheckConditions()
    {
        if (_conditions.All(c => c.Value))
        {
            wallPassedEvent.Invoke();
        }
    }

    private async Task OnEvent(CollisionZone e)
    {
        _conditions[e] = true;
        CheckConditions();
        await Task.Delay(1000);
        _conditions[e] = false;
    }
}
