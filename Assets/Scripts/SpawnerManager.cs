using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
   [SerializeField] ShapeManager[] TumSekiller;
   
   public ShapeManager SekilOlusturFNC()
   {

      int RandomSekil = Random.Range(0, TumSekiller.Length);
      ShapeManager Sekil = Instantiate(TumSekiller[RandomSekil],transform.position,Quaternion.identity) as ShapeManager;
      
      
      if (Sekil != null)
      {
          return Sekil;
      }
      else
      {
          print("boş dizi");
          return null;
      }
      
   }
   
}
