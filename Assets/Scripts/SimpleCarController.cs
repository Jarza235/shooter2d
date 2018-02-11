 using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
 
    [System.Serializable]
    public class AxleInfo {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor;
        public bool steering;
    }
         
    public class SimpleCarController : MonoBehaviour {
        //Handling
        public List<AxleInfo> axleInfos; 
        public float maxMotorTorque;
        public float maxSteeringAngle;
        public float brakeForce;
		public float rocketFroce;
		public float downForce;

        public Vector3 centerOfMassCorrection;
        //Internal
        public bool controlled;
        bool braking;


		private Rigidbody rb;

        void Start()
        {
			rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfMassCorrection;
        }
         
        // finds the corresponding visual wheel
        // correctly applies the transform
        public void ApplyLocalPositionToVisuals(WheelCollider collider)
        {
            if (collider.transform.childCount == 0) {
                return;
            }
         
            Transform visualWheel = collider.transform.GetChild(0);
         
            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);
         
            visualWheel.transform.position = position;
            visualWheel.transform.rotation = rotation;
        }
         
        public void FixedUpdate()
        {
			// Downforce
			rb.AddForce(new Vector3(0f, 0f, 1f) * downForce);

            if (controlled)
            {
                float motor = maxMotorTorque * Input.GetAxis("Vertical");
                float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
                if (Input.GetButton("Jump")) { braking = true; } else { braking = false; }

                foreach (AxleInfo axleInfo in axleInfos)
                {
                    if (axleInfo.steering)
                    {
                        axleInfo.leftWheel.steerAngle = steering;
                        axleInfo.rightWheel.steerAngle = steering;

                        

                    }
                    if (axleInfo.motor)
                    {
                        axleInfo.leftWheel.motorTorque = motor;
                        axleInfo.rightWheel.motorTorque = motor;

						Vector3 dir = Quaternion.AngleAxis(steering, Vector3.forward) * Vector3.forward;
					//rb.AddForce()
					rb.AddRelativeForce(dir * rocketFroce * Input.GetAxis("Vertical"));
                    }

				//Braking
				if (braking)
				{
					axleInfo.leftWheel.brakeTorque = brakeForce;
					axleInfo.rightWheel.brakeTorque = brakeForce;
				}
				else
				{
					axleInfo.leftWheel.brakeTorque = 0;
					axleInfo.rightWheel.brakeTorque = 0;
				}

                    ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                    ApplyLocalPositionToVisuals(axleInfo.rightWheel);
                }
            }
        }


    }