using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberView : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite0To9;
    [SerializeField] private SpriteRenderer[] spriteRenderersLtoR;

    public void SetNumber(int number)
    {
        var strNum = number.ToString($"D{spriteRenderersLtoR.Length}");
        var isTopZero = true;
        for (int i = 0; i < spriteRenderersLtoR.Length; i++)
        {
            if (isTopZero)
            {
                if (strNum[i] == '0')
                {
                    spriteRenderersLtoR[i].enabled = false;
                    continue;
                }
                isTopZero = false;
            }

            var index = int.Parse(strNum[i].ToString());
            spriteRenderersLtoR[i].sprite = sprite0To9[index];
            spriteRenderersLtoR[i].enabled = true;
        }
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
