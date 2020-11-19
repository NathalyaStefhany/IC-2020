using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDamage : IDamage
{
    private SceneControl sceneControl;
    private Score score;

    public override void Damage(GameObject goBlock)
    {
        sceneControl = FindObjectOfType<SceneControl>();
        score = FindObjectOfType<Score>();

        Block block = goBlock.GetComponent<Block>();

        block.SetNumHits();

        int maxHits = block.sprites.Length + 1;

        if (block.GetNumHits() >= maxHits)
        {
            Block.destructibleBlockNum--;

            score.addPoints(block.points);

            sceneControl.DestroyedBlock();

            GameObject.Destroy(goBlock);
        }
        else
        {
            block.LoadSprite();
        }
    }
}
