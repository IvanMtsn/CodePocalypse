using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IfNode : ContainingNode
{
    public ICondition condition;
    private bool _isInverted;
    public override async Task GoThroughNodes()
    {
        if(!_isInverted)
        {
            if (condition.Check())
            {
                await base.GoThroughNodes();
            }
        }
        else
        {
            if (!condition.Check())
            {
                await base.GoThroughNodes();
            }
        }
        await Task.Yield();
    }

    public void ToogleInversion()
    {
        if(_isInverted) _isInverted = false;
        else _isInverted = true;
    }
}
