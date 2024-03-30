using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterial : MonoBehaviour
{

    [SerializeField] Material headMaterial;

    public void ChangeHeadMaterialColor(Color color) {
        headMaterial.color = color;
    }
}
