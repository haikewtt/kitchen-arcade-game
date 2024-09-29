using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    

    public override void Interact(Player player)
    {
        if(!HasKitchenObject()) // no kitchen object
        {
            if (player.HasKitchenObject()) // player is carrying smthing
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else // player carry nothing 
            {

            }
        }
        else // have kitchen object
        {
            if (player.HasKitchenObject()) // player is carrying smthing
            {
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) // player is holding a plate
                {
                    
                    if( plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                   
                }
                else // player is not holding a plate
                {
                    if(GetKitchenObject().TryGetPlate(out  plateKitchenObject)) // counter holding a plate
                    {
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else // player not carry anything
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}

