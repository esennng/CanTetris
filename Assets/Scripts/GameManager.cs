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
    [Range(0.02f,1f)]
    [SerializeField] private float SagSolDonmeSuresi = 0.25f;
    private float SagSolDonmeSayac;
    [Range(0.02f,1f)]
    [SerializeField] private float AsagıTusaBasmaSuresi = 0.25f;
    private float AsagıTusaBasmaSayac;

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
        if (!board || !spawner || !AktifSekil) 
        {
            return; 
        }
        //Yorum satırı eklendi mi??
        GirisKontrolFNC();
    }

    private void GirisKontrolFNC()
    {
        if ((Input.GetKey("right") && Time.time > SagSolTusaBasmaSayac) || Input.GetKeyDown("right"))
        {
            
            AktifSekil.SagaHareketFNC();
            SagSolTusaBasmaSayac = Time.time + SagSolTusaBasmaSuresi;
            if (!board.GecerliPozisyondamı(AktifSekil))
            {
                AktifSekil.SolaHareketFNC();
            }
            
        }
        else if ((Input.GetKey("left") && Time.time > SagSolTusaBasmaSayac) || Input.GetKeyDown("left"))
        {
            
            AktifSekil.SolaHareketFNC();
            SagSolTusaBasmaSayac = Time.time + SagSolTusaBasmaSuresi;
            if (!board.GecerliPozisyondamı(AktifSekil))
            {
                AktifSekil.SagaHareketFNC();
            }
            
        }
        else if ((Input.GetKey("up") && Time.time > SagSolTusaBasmaSayac) )
        {
            
            AktifSekil.SagaDonFNC();
            SagSolTusaBasmaSayac = Time.time + SagSolTusaBasmaSuresi;
            if (!board.GecerliPozisyondamı(AktifSekil))
            {
                AktifSekil.SagaDonFNC();
            }
            
        }
        else if ((Input.GetKey("down") && Time.time > AsagıTusaBasmaSayac) || Time.time>AsagıInmeSayac)
        {
            
            AsagıInmeSayac = Time.time + AsagıInmeSuresi;
            AsagıTusaBasmaSayac = Time.time + AsagıTusaBasmaSuresi;
            
            if (AktifSekil)
            {
                AktifSekil.AsagiHareketFNC();

                if (!board.GecerliPozisyondamı(AktifSekil))
                {
                    YerlestiFNC();
                }
            }
            
        }
    }

    private void YerlestiFNC()
    {
        
        SagSolTusaBasmaSayac = Time.time;
       // AsagıTusaBasmaSuresi = Time.time;
        SagSolDonmeSayac = Time.time;
        
        AktifSekil.YukariHareketFNC();
                    
        board.SekliIzgaraIcineAlFNC(AktifSekil);

        if (spawner)
        {
            AktifSekil = spawner.SekilOlusturFNC();
        }
        
        board.TumSatirlariTemizleFNC();
    }


    Vector2 VectoruIntYapFNC(Vector2 Vector)
    {
        return new Vector2(MathF.Round(Vector.x), MathF.Round(Vector.y));
    }
    
}
