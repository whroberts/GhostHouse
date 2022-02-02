using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC {
    public abstract class NPCBase : MonoBehaviour, IInteractable
    {
        [Header("NPC Details")]
        [SerializeField] protected string _name = string.Empty;
        [SerializeField] protected int _age = 0;
        [Tooltip("i.e. younger sister or grandmother")]
        [SerializeField] protected string _placeInFamily = string.Empty;

        [Header("Animations")]
        [SerializeField] protected AnimationClip _idleAnimation = null;
        [SerializeField] protected AnimationClip _surprisedAnimation = null;
        [SerializeField] protected AnimationClip _happyAnimation = null;
        /*
        [Tooltip("Bigger than the happy animation. May not be necessary")]
        [SerializeField] protected AnimationClip _overjoyedAnimation = null;
        */
        [SerializeField] protected AnimationClip _sadAnimation = null;
        [SerializeField] protected AnimationClip _angryAnimation = null;

        [Tooltip("Can be used to insure where the NPC goes in between playthroughs and levels")]
        [Header("Preset Locations")]
        [SerializeField] protected Transform _levelPosition = null;

        


        public abstract void Idle();
        public abstract void Talking();
        public abstract void Reactions();
        public abstract void Dialogue();


        #region Interaction
        Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void MoveHorizontal()
        {
            Quaternion turnOffset = Quaternion.Euler(0, 30f, 0);
            if (_rb != null)
            {
                _rb.MoveRotation(_rb.rotation * turnOffset);
            }
        }

        void MoveVerticalBackwards()
        {
            Quaternion turnOffset = Quaternion.Euler(-30f, 0, -20f);
            if (_rb != null)
            {
                _rb.MoveRotation(_rb.rotation * turnOffset);
            }
        }

        void MoveVerticalForwards()
        {
            Quaternion turnOffset = Quaternion.Euler(30f, 0, 20f);
            if (_rb != null)
            {
                _rb.MoveRotation(_rb.rotation * turnOffset);
            }
        }

        //This is when the mouse first hovers over the object.
        public void OnHoverEnter()
        {
            Debug.Log("Hovering over " + gameObject.name);
            MoveHorizontal();
        }

        //This is when the mouse leaves the shape of the object.
        public void OnHoverExit()
        {
            Debug.Log("No Longer Hovering over" + gameObject.name);
        }

        //This is when the mouse left clicks on the object.
        public void OnLeftClick()
        {
            Debug.Log("Left Clicked On" + gameObject.name);
            MoveVerticalForwards();
        }

        //This is when the mouse right clicks on an object.
        public void OnRightClick()
        {
            Debug.Log("Right Clicked On" + gameObject.name);
            MoveVerticalBackwards();
        }

        #endregion
    }
}
