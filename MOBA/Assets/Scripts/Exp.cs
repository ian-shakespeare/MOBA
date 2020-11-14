using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Exp : MonoBehaviour
{
    private int maxLevel = 5;

    [SerializeField]

    private int curLevel = 1;

    private int expMax = 100;

    private int curExp;

    public event Action<float> OnExpPctChanged = delegate { };

    private void OnEnable()
    {
        curExp = 0;
    }

    public int GetExp()
    {
        return curExp;
    }

    public int GetLevel()
    {
        return curLevel;
    }

    public void ModifyExp(int amount)
    {
        curExp += amount;

        if (curExp >= expMax && curLevel < maxLevel) {
            curLevel += 1;
            curExp = 0;
        }

        float curExpPct = (float)curExp / (float)expMax;
        OnExpPctChanged(curExpPct);
    }

    private void Update()
    {
        if ( Time.time % 10f <= 0.005 ) {
          ModifyExp(10);
        }
        if (Input.GetKeyDown(KeyCode.F))
            ModifyExp(10);

    }


}
