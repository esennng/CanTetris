using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
   [SerializeField] private bool Donebilirmi=true;
   

   public void SolaHareketFNC()
   {
      //transform.Translate(new Vector3(-1,0,0));s
      transform.Translate(Vector3.left,Space.World);

   }
   public void SagaHareketFNC()
   {
      //transform.Translate(new Vector3(-1,0,0));
      transform.Translate(Vector3.right,Space.World);

   }

   public void AsagiHareketFNC()
   {
      transform.Translate(Vector3.down,Space.World);
   }
   
   public void YukariHareketFNC()
   {
      transform.Translate(Vector3.up,Space.World);
   }

   public void SagaDonFNC()
   {
      if (Donebilirmi)
      {
         transform.Rotate(0,0,-90);
      }
   }
   // ınvoke fonksiyonu belli aralıklarla tetiklemeyi sağlar
   public void SolaDonFNC()
   {
      if (Donebilirmi)
      {
         transform.Rotate(0,0,90);
      }
   }

   IEnumerator HareketRutin()
   {
      while (true)
      {
         AsagiHareketFNC();
         yield return new WaitForSeconds(.25f);
      }
   }

   
   
}
