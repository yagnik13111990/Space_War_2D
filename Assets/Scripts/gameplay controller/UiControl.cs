using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControl : MonoBehaviour
{
    public static UiControl Instance;

    [SerializeField]
    private Text waveInfo, shipDestroyedInfo, meteorDistroyedInfo;

    private int waveCount , shipDistroyCount , meteorDistroyCount ;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void SetInfo(int info)
    {
        switch (info)
        {
            case 1 :
                waveCount++;
                waveInfo.text = "WAVE :" + waveCount; 
                break;

            case 2 :
                shipDistroyCount++;
                shipDestroyedInfo.text = shipDistroyCount + "x ";
                break;

            case 3:
                meteorDistroyCount++;
                meteorDistroyedInfo.text = meteorDistroyCount + "x ";
                break;
        }
    }

    public int GetWaveCount()
    {
        return waveCount;
    }

    public int GetShipCount()
    {
        return shipDistroyCount;
    }

    public int GetMeteorCount()
    {
        return meteorDistroyCount;
    }

}
