using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTSResource : MonoBehaviour
{
    [SerializeField] string resourceName;
    [SerializeField] string description;
    [SerializeField] Image icon;
    [SerializeField] int amount;

    [SerializeField] RTSResourceDisplay display;

   public void SetResource(string name, string desc, Image icon, int amount)
    {
        this.name = name;
        this.description = desc;
        this.icon = icon;
        this.amount = amount;
    }

    public void UpdateResources(int amount)
    {
        this.amount += amount;
        UpdateResourceText();
    }

    void UpdateResourceText()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
