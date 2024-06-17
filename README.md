# Unity Car Controller

## Description
The Unity Car Controller project provides a comprehensive car control system designed for Unity 3D, allowing for realistic vehicle physics and controls. This project includes scripts and configurations to simulate car behavior, including steering, acceleration, braking, and wheel updates. The system leverages Unity's `Rigidbody` and `WheelCollider` components to create a responsive and realistic driving experience.

## Features
- **Steering Mechanism**: Realistic steering for the front wheels.
- **Motor Force**: Simulates engine torque applied to the front wheels.
- **Braking System**: Implemented braking using space bar input.
- **Wheel Rotation**: Updates the position and rotation of the wheels to match the movement.
- **Center of Mass Adjustment**: Configurable center of mass to improve vehicle stability.

## Getting Started
### Prerequisites
- Unity 2019.4 or higher
- Basic knowledge of Unity and C#

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/Namancoder80/unity-car-controller.git
Open the project in Unity.
Usage
Attach the CarController script to your car GameObject.
Configure the Vehicle class in the inspector:
Assign the WheelCollider and Transform references for each wheel.
Set the COM (Center of Mass) Transform.
Play the scene and use the arrow keys for driving:
Up/Down Arrows: Accelerate/Decelerate
Left/Right Arrows: Steer left/right
Space Bar: Apply brakes
Script Details
CarController.cs
This script handles the core functionalities of the car, including input management, steering, motor force application, wheel updates, and braking.

Methods:
OnEnable(): Initializes the Rigidbody and sets the center of mass.
FixedUpdate(): Main update loop for physics calculations.
streeing(): Handles the steering mechanism.
MoterForce(): Applies motor torque to the front wheels.
GetAxis(): Retrieves input values for vertical and horizontal axes.
UpdateWheel(): Updates the position and rotation of the wheels.
rotateWheel(): Helper method to update a single wheel's position and rotation.
ApplyBreak(): Applies or releases the brake torque based on input.
Vehicle.cs
A serializable class to hold references to the car's wheel colliders, transforms, and center of mass.

Contributing
Contributions are welcome! Please fork the repository and submit a pull request for any improvements or bug fixes.
