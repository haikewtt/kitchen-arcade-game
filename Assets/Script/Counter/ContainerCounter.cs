using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedOject; 

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerGrabbedOject?.Invoke(this, EventArgs.Empty);
        }
        
    }

   
}
