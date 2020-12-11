using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDamage : Damage
{
    private SceneControl sceneControl;

    public override void ExecuteDamage(GameObject goBlock)
    {
        sceneControl = FindObjectOfType<SceneControl>();

        Block block = goBlock.GetComponent<Block>();

        block.SetNumHits();

        int maxHits = block.sprites.Length + 1;

        if (block.GetNumHits() >= maxHits)
        {
            Block.destructibleBlockNum--;

            popUpDMGVFX(block);

            block.DestroyBlock();

            sceneControl.DestroyedBlock();
        }
        else
        {
            block.LoadSprite();
        }
    }
}
