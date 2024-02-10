using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
   [SerializeField] private Transform TilePrefab;

   public int yukseklik = 22;
   public int genislik = 10;

   private Transform[,] Izgara;

   private void Awake()
   {
      Izgara = new Transform[genislik, yukseklik];
   }

   private void Start()
   {
      BosKareleriOlusturFNK();
   }

   bool BoardIcindemi(int x, int y)
   {
      return (x >= 0 && x < genislik && y >= 0 );
   }

   bool KareDolumu(int x, int y, ShapeManager shape)
   {
      //print(x.ToString() +y.ToString());
      return (Izgara[x, y] != null && Izgara[x,y].parent!=shape.transform);

   }
   

   public bool GecerliPozisyondamı(ShapeManager Shape)
   {
      foreach (Transform child in Shape.transform)
      {
         Vector2 pos = VectoruIntYapFNC(child.position);

         if (!BoardIcindemi((int) pos.x,(int)pos.y))
         {
            return false;
         }

         if (pos.y < yukseklik)
         {
            if(KareDolumu((int)pos.x,(int)pos.y,Shape))
            {
               return false;
            }
         }
        
      }

      return true;
   }
   
   void BosKareleriOlusturFNK()
   {
      if (TilePrefab != null)
      {
         for (int y = 0; y < yukseklik; y++)
         {
            for (int x = 0; x < genislik; x++)
            {
               Transform Tile = Instantiate(this.TilePrefab, new Vector3(x, y, 0), Quaternion.identity);
               Tile.name = "x" + x.ToString() + ", " + "y" + y.ToString();
               Tile.parent = this.transform;

            }
         }
      }
      else
      {
         print("TilePrefab eklenmedi!!!");
      }
   }

   public void SekliIzgaraIcineAlFNC(ShapeManager Shape)
   {
      if (Shape == null)
      {
         return;
      }

      foreach (Transform child in Shape.transform)
      {
         Vector2 pos = VectoruIntYapFNC(child.position);
         Izgara[(int)pos.x, (int)pos.y] = child;
      }
   }
   
   
   Vector2 VectoruIntYapFNC(Vector2 Vector)
   {
      return new Vector2(MathF.Round(Vector.x),MathF.Round(Vector.y));
    
   }
   
   
}
