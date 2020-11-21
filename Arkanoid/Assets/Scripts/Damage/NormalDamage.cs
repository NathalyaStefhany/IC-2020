using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDamage : Damage
{
    private SceneControl sceneControl;
    private Score score;

    public override void ExecuteDamage(GameObject goBlock)
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

            //codigo para o efeito do pop up text
            popUpDMGVFX(block);
            //------------//

            sceneControl.DestroyedBlock();

            GameObject.Destroy(goBlock);
        }
        else
        {
            block.LoadSprite();
        }
    }
}
