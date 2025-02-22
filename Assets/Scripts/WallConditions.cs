using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class WallConditions : MonoBehaviour
{
    public UnityEvent wallPassedEvent;
    private readonly Dictionary<string, bool> _conditions = new()
    {
        { "head", false },
        { "leftHand", false },
        { "rightHand", false }
    };

    private void CheckConditions()
    {
        if (_conditions.All(c => c.Value))
        {
            wallPassedEvent.Invoke();
        }
    }

    private async Task OnHeadEvent()
    {
        await OnEvent("head");
    }

    private async Task OnLeftHandEvent()
    {
        await OnEvent("leftHand");
    }

    private async Task OnRightHandEvent()
    {
        await OnEvent("rightHand");
    }

    private async Task OnEvent(string e)
    {
        _conditions[e] = true;
        CheckConditions();
        await Task.Delay(1000);
        _conditions[e] = false;
    }
}
