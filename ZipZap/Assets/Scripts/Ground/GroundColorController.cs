using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorController : MonoBehaviour
{
   [SerializeField] private Material groundMaterial;
   [SerializeField] private Color[] colors;
   private int coloIndex = 0;
}
