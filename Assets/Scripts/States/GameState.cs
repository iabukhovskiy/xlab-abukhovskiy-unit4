﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public abstract class GameState : MonoBehaviour
    {
        public List<GameObject> views;

        public virtual void Enter()
        { 
            gameObject.SetActive(true);
        }
        public void Exit() 
        { 
            gameObject.SetActive(false);
        }

        protected virtual void OnEnable()
        {
            foreach (var item in views)
            {
                item.SetActive(true);
            }
        }

        protected virtual void OnDisable()
        {
            foreach (var item in views)
            {
                if (item)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}