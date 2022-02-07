using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC {

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Animator))]
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
        [SerializeField] protected AnimationClip _sadAnimation = null;
        [SerializeField] protected AnimationClip _angryAnimation = null;

        [Tooltip("Can be used to insure where the NPC goes in between playthroughs and levels")]
        [Header("Preset Locations")]
        [SerializeField] protected Transform _levelPosition = null;

        [Header("Sounds")]
        [SerializeField] protected AudioClip _sound1 = null;

        Rigidbody _rb;
        Collider _collider;
        AudioSource _audioSource;
        Animator _animator;


        public abstract void Idle();
        public abstract void Talking();
        public abstract void Reactions();
        public abstract void Dialogue();

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
        }

        #region Animation

        AnimatorControllerParameter[] _animParameters;
        

        void GetComponenets()
        {
            _animParameters = _animator.parameters;
            Debug.Log(_animParameters.Length);

            Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).IsName("ReactionTest"));
        }

        void SetAnimations()
        {
            //check if animator has states

            if (_animator.HasState(0,))

        }

        #endregion

        #region Interaction

        //This is when the mouse first hovers over the object.
        public void OnHoverEnter()
        {
            //Debug.Log("Hovering over " + gameObject.name);
        }

        //This is when the mouse leaves the shape of the object.
        public void OnHoverExit()
        {
            //Debug.Log("No Longer Hovering over" + gameObject.name);
        }

        //This is when the mouse left clicks on the object.
        public void OnLeftClick()
        {
            Debug.Log("Left Clicked On" + gameObject.name);
            _animator.SetTrigger("ReactionTrigger");
            GetComponenets();
        }

        //This is when the mouse right clicks on an object.
        public void OnRightClick()
        {
            Debug.Log("Right Clicked On" + gameObject.name);
        }
        #endregion
    }
}
