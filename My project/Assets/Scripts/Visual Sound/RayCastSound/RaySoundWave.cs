using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// af Rasmus
// hoved mechaninc i vores spil
// scriptet bruges til at sende rays ud fro at finde ud af hvordan lyd bouncer undt i rumet

namespace SoundWaveSystem
{
    public class RaySoundWave : MonoBehaviour
    {
        [SerializeField] bool debuger;

        // hvor mange rays der bliver skudt ud, og der for hvor detaljerede lyd reflektion der laves
        [SerializeField] int soundDetail = 360;

        [SerializeField] LayerMask hitLayer, hitLayerFirstRay;


        ISoundOrigin soundOrigin;
        float maxDis;



        private void Awake()
        {
            soundOrigin = GetComponent<ISoundOrigin>();
            soundOrigin.makeSound += ShootRay;
        }

        bool debugray = true;


        //skyder rays ud for at simulere lyd reflektion
        public void ShootRay(float dis)
        {
            maxDis = dis;

            float angelPerStep = 360f / soundDetail;

            for (int i = 0; i < soundDetail; i++)
            {
                if (i == 0 && debuger)
                {
                    debugray = true;
                }
                 else
                {
                    debugray = false;
                }

                IHitObj[] hits = new IHitObj[10];
                SubRay(transform.position, new Vector2(Mathf.Cos(angelPerStep * i * Mathf.Deg2Rad), Mathf.Sin(angelPerStep * i * Mathf.Deg2Rad)), dis, angelPerStep * i, hits, 0);
                EndRay(hits);
            }
        }


        //Ray stuf, til at reflektere lyden
        public void SubRay(Vector2 origin, Vector2 dir, float disLeft, float angle, IHitObj[] hits, int hitCount)
        {
            if (debugray) Debug.Log(disLeft);

            //hvis lydstyrke er forlav stopper den
            if (disLeft <= 0) return;
            // hvis lyden har bouncet 10 gange stopper den
            if (hitCount == 10) return;


            RaycastHit2D rayHit = Physics2D.Raycast(origin, dir, disLeft, hitCount==0? hitLayerFirstRay : hitLayer);

            if (rayHit)
            {
                //finder den ramte ting
                IHitObj justHit = rayHit.collider.gameObject.GetComponent<IHitObj>();

                //vis det der blev ramt ikke var et hit obj
                if (justHit == null) return;

                hits[hitCount] = justHit;
                //siger til det ramte obj at det var ramt
                justHit.Hit(soundOrigin, hits, rayHit.point, disLeft - rayHit.distance, maxDis);

                //colider vinkel
                float colAngle = To360Deg(Mathf.Atan2(rayHit.normal.y, rayHit.normal.x) * Mathf.Rad2Deg);

                float reflectAngle = 180;
                //Regner reflektions vinklen
                reflectAngle += colAngle + (colAngle - angle);

                reflectAngle = To360Deg(reflectAngle);

                //skyder en ny ray
                SubRay(rayHit.point+ (rayHit.normal*0.01f), new Vector2(Mathf.Cos(reflectAngle * Mathf.Deg2Rad), Mathf.Sin(reflectAngle * Mathf.Deg2Rad)), disLeft-rayHit.distance- justHit.Dampening, reflectAngle, hits, hitCount+1);
            }
        }

        //oprydning efter rays
        private void EndRay(IHitObj[] hits)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i] == null) return;
                hits[i].EndOfRay();
            }
        }

        //holder rotationen inden for 360
        private float To360Deg(float deg)
        {
            while (deg < 0)
            {
                deg += 360;
            }
            while (deg > 360)
            {
                deg -= 360;
            }
            return deg;
        }

    }
}
