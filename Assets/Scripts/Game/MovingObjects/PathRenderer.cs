using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace KnifeThrower
{
    public class PathRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _force;
        [SerializeField] private Material _fullLenghtMaterial;
        [SerializeField] private Material _shortLenghtMaterial;

        private Vector3 _startPosition = new Vector3(0, 2.87f, -9.57f);

        private Vector3 _throwForce;
        private Vector3 _throwDirection;

        private IInputPosition _inputPosition;
        private IGUIControl _guiControl;
        [Inject]
        private ThrowArea _throwArea;

        [Inject]
        public void Construct(IInputPosition inputPosition)
        {
            _inputPosition = inputPosition;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex > 3)
            {
                _lineRenderer.material = _shortLenghtMaterial;
            }

            else
            {
                _lineRenderer.material = _fullLenghtMaterial;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (_throwArea.IsThrowPrepared)
            {
                if (!_lineRenderer.enabled)
                {
                    _lineRenderer.enabled = true;
                }

                ReadyPath();
            }

            else
            {
                if (_lineRenderer.enabled)
                {
                    _lineRenderer.enabled = false;
                }
            }
        }

        public void ShowTrajectory(Vector3 origin, Vector3 speed)
        {
            Vector3[] points = new Vector3[100];
            _lineRenderer.positionCount = points.Length;
            for (int i = 0; i < points.Length; i++)
            {
                float time = i * 0.02f;
                points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
                if (SceneManager.GetActiveScene().buildIndex > 3)
                {
                    if (points[i].z > -8f)
                    {
                        _lineRenderer.positionCount = i;
                        break;
                    }
                }
            }

            _lineRenderer.SetPositions(points);
        }

        private void ReadyPath()
        {
            _throwDirection = _inputPosition.MousePoint;

            if (_inputPosition.IsPowerShotUsed)
            {
                _throwForce = (_throwDirection - _startPosition).normalized *
                    (_force * 10);
            }
            else
            {
                _throwForce = (_throwDirection - _startPosition).normalized *
                    (_force * _throwArea.MouseYDistance);
                /*  if (_throwForce.z > 1500)
                  {
                      _throwForce.z = 1500;
                  } */
            }

            ShowTrajectory(_startPosition, _throwForce);
        }
    }
}