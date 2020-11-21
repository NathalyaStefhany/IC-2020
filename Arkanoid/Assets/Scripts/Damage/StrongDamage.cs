using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongDamage : Damage
{
    private SceneControl sceneControl;
    private Score score;

    public override void ExecuteDamage(GameObject goBlock)
    {
        sceneControl = FindObjectOfType<SceneControl>();
        score = FindObjectOfType<Score>();

        Block block = goBlock.GetComponent<Block>();

        Block.destructibleBlockNum--;
        popUpDMGVFX(block);//efeito popup txt
        score.addPoints(block.points);

        sceneControl.DestroyedBlock();

        Destroy(goBlock);
    }
}
