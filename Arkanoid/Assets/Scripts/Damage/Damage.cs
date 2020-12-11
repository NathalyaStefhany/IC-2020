using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damage : MonoBehaviour
{
    public abstract void ExecuteDamage(GameObject block);

    [SerializeField]
    protected GameObject dmgPopUpTxtVFX;

    protected void popUpDMGVFX(Block block) {
        GameObject popUp = Instantiate(dmgPopUpTxtVFX, block.transform.position, Quaternion.identity);
        Color color = block.GetComponent<SpriteRenderer>().color;

        popUp.GetComponentInChildren<MeshRenderer>().sortingLayerName = "VFX";
        popUp.GetComponentInChildren<TextMesh>().text = block.points.ToString();
        popUp.GetComponentInChildren<TextMesh>().color = color;
        
        Destroy(popUp, 2.0f);
    }
}
