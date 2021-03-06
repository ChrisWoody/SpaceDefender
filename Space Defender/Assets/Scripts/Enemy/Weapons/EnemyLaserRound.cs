﻿using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Enemy.Weapons
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyLaserRound : EnemyWeaponBase
    {
        private const float Speed = 60f;

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Player.GetComponent<Player.Player>().Hit(GameController.EnemyLaserDamage);

                Destroy(gameObject);
            }
        }

        public void Fire(Vector3 pos, Vector3 dir)
        {
            transform.position = pos;
            transform.up = dir;
            transform.GetComponent<Rigidbody>().velocity = dir*Speed;
            Destroy(gameObject, 60f);
        }
    }
}