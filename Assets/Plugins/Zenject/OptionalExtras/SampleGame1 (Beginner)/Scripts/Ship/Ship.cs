using UnityEngine;

#pragma warning disable 649
#pragma warning disable 618

namespace Zenject.Asteroids
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        MeshRenderer _meshRenderer;

        [SerializeField]
        ParticleSystem _particleSystem;


        ShipStateFactory _stateFactory;

        ShipState _state; // ShipState - это абстрактный класс
                            // от которого наследуются, чтобы
                            // прописать каждый стейт. 

        [Inject]
        public void Construct(ShipStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

		#region UnityComponents

		public MeshRenderer MeshRenderer
        {
            get { return _meshRenderer; }
        }

        public ParticleSystem ParticleEmitter
        {
            get { return _particleSystem; }
        }


        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Quaternion Rotation
        {
            get { return transform.rotation; }
            set { transform.rotation = value; }
        }

		#endregion

		#region unityeventLinkedToShipState

		public void Start()
        {
            ChangeState(ShipStates.WaitingToStart);
        }

        public void Update()
        {
            _state.Update();
        }

        public void OnTriggerEnter(Collider other)
        {
            _state.OnTriggerEnter(other);
        }
        #endregion


        public void ChangeState(ShipStates state)
        {
            if (_state != null)
            {
                _state.Dispose();
                _state = null;
            }

            _state = _stateFactory.CreateState(state);
            _state.Start();
        }
    }
}

