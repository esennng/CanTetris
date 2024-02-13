using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnerManager spawner;
    BoardManager board;

    [Header("Sayaclar")]
    
    [Range(0.02f,1f)]
    [SerializeField] private float AsagıInmeSuresi = .1f;
    private float AsagıInmeSayac;
    [Range(0.02f,1f)]
    [SerializeField] private float SagSolTusaBasmaSuresi = 0.25f;
    private float SagSolTusaBasmaSayac;
    
    private ShapeManager AktifSekil;
    private void Start()
    {
       // spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerManager>();
        //CanTetris
       board = GameObject.FindObjectOfType<BoardManager>();
       spawner = GameObject.FindObjectOfType<SpawnerManager>();

       if (spawner)
       {
           if (AktifSekil==null)
           {
               AktifSekil = spawner.SekilOlusturFNC();
               AktifSekil.transform.position = VectoruIntYapFNC(AktifSekil.transform.position);
           }
       }
    }

    private void Update()
    {
        if (!board || !spawner) 
        {
            return; 
        }
        //Yorum satırı eklendi mi??
        GirisKontrolFNC();
    }

    private void GirisKontrolFNC()
    {
        Debug.Log(Input.GetKey("right"));
        if ((Input.GetKey("right")&& Time.time>SagSolTusaBasmaSayac) || Input.GetKeyDown("right"));
        {
            
            AktifSekil.SagaHareketFNC();
            SagSolTusaBasmaSayac = Time.time + SagSolTusaBasmaSuresi;
            if (board.GecerliPozisyondamı(AktifSekil))
            {
                print("sağa hareket ediyor");
            }
            else
            {
                AktifSekil.SolaHareketFNC();
            }
        }
        
        

        if (Time.time > AsagıInmeSayac)
        {

            AsagıInmeSayac = Time.time + AsagıInmeSuresi;
            
            if (AktifSekil)
            {
                AktifSekil.AsagiHareketFNC();

                if (!board.GecerliPozisyondamı(AktifSekil))
                {
                    AktifSekil.YukariHareketFNC();
                    
                    board.SekliIzgaraIcineAlFNC(AktifSekil);

                    if (spawner)
                    {
                        AktifSekil = spawner.SekilOlusturFNC();
                    }
                }
            }

        }
    }


    Vector2 VectoruIntYapFNC(Vector2 Vector)
    {
        return new Vector2(MathF.Round(Vector.x), MathF.Round(Vector.y));
    }
    
}
