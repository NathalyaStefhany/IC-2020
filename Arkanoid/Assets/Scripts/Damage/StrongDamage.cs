using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongDamage : IDamage
{
    private SceneControl sceneControl;
    private Score score;

    public override void Damage(GameObject goBlock)
    {
        sceneControl = FindObjectOfType<SceneControl>();
        score = FindObjectOfType<Score>();

        Block block = goBlock.GetComponent<Block>();

        Block.destructibleBlockNum--;

        score.addPoints(block.points);

        sceneControl.DestroyedBlock();

        Destroy(goBlock);
    }
}
