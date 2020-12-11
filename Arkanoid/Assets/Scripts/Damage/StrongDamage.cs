using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongDamage : Damage
{
    private SceneControl sceneControl;

    public override void ExecuteDamage(GameObject goBlock)
    {
        sceneControl = FindObjectOfType<SceneControl>();

        Block block = goBlock.GetComponent<Block>();

        Block.destructibleBlockNum--;
        popUpDMGVFX(block);

        block.DestroyBlock();

        sceneControl.DestroyedBlock();
    }
}
