using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    private float toatlSpinAmount;
    

    private void Update()
    {
    
        if (!isActive)
        {
            return;
        }

        float spinAddAmount = 360 * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);

        toatlSpinAmount += spinAddAmount;
        if(toatlSpinAmount >= 360f)
        {
            isActive= false;
            onActionComplete();
        }

    }
    public void Spin(Action onActionComplete)
    {
        this.onActionComplete = onActionComplete;
        isActive= true;
        toatlSpinAmount = 0f;
        Debug.Log("Spin");
    }
}
