using System.Collections;
using System.Collections.Generic;
using Script.Models;
using UnityEngine;

public class PlantInWorld : MonoBehaviour
{
    public Plant PlantInfo;
    
    public List<Sprite> plantSprites;

    public Sprite currentSprite;

    public int growthValue = 0;

    public void PlantGrow()
    {
        growthValue += PlantInfo.EveryDayGrowValue;
        if (growthValue > PlantInfo.TotalGrowthValue)
        {
            
        }
    }
}
