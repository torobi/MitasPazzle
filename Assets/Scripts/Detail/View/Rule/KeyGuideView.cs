using System.Collections;
using System.Collections.Generic;
using Adapter.IView;
using UnityEngine;

public class KeyGuideView : MonoBehaviour, IKeyGuideView
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Appear()
    {
        this.gameObject.SetActive(true);
    }

    public void Disappear()
    {
        this.gameObject.SetActive(false);
    }
}
