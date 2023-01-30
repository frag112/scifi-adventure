using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScifiAdventure
{
    [Serializable]
    public class QuestGoal
    {
        [SerializeField] protected GoalType _goalType;
        [SerializeField] protected bool _completed;

        protected virtual void Init()
        {
            // init
        }
        public bool IsReached()
        {
            return (_completed);
        }
        //public string description { get; set; }
        //public bool completed { get; set; }
        //public int currentAmount {get; set;}
        //public int requiredAmount { get; set;}
        //public virtual void Init()
        //{

        //}
        //public void Evaluate()
        //{
        //    if (currentAmount>=requiredAmount)
        //    {
        //        Complete();
        //    }
        //}
        //public void Complete()
        //{
        //    completed= true;
        //}

    }

    public enum GoalType
    {
        BringItem,
        ActivateSomething,
        DoMiniGame,
        Gathering,
        CombineItems
    }
}