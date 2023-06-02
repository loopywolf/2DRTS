using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class RTSResource : MonoBehaviour
{
    public string resourceName;
    [SerializeField] string description;
    [SerializeField] Sprite icon;
    [SerializeField] int amount;

    [SerializeField] RTSResourceDisplay display;

   public void SetResource(string name, string desc, Sprite icon, int amount)
    {
        this.name = name;
        this.description = desc;
        this.icon = icon;
        this.amount = amount;
    }

    public void AddResources(int amount)
    {
        this.amount += amount;
        UpdateResourceText();
    }

    public bool HasAmountOfResource(int amount)
    {
        return this.amount > amount;
    }

    void UpdateResourceDescription(string desc)
    {
        this.description = desc;
    }

    void UpdateResourceText()
    {
        //Update the display source for this resource
    }

    public void AssignResourceIcon(Sprite sprite)
    {
        this.icon = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
