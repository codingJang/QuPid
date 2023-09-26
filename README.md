# QuPid: A VR Approach to Understanding Qubits

**Personal Project by Yejun Jang**

Repository for the QuPid project, a quantum optical computing simulation designed to elucidate the principles of qubits and light polarization in a virtual environment, leveraging recursive algorithms, Unity XR Interaction Toolkit and CSML (C# Matrix Library).

## Introduction

QuPid is a project aimed at simplifying the understanding of Qubits, the basic unit of quantum information, through a Virtual Reality (VR) lab experience. By utilizing light polarization, this VR lab offers a more hands-on approach to the quantum realm.

The idea for QuPid emerged from a personal challenge to make Qubits more approachable. Initially conceived as a physical optical experiment, the project pivoted to VR due to practical constraints. This transition not only made the project feasible but also provided an opportunity to reach a wider audience.

## Objective

QuPid provides a VR environment where users can explore the concept of a Qubit via light polarization. The virtual lab contains optical tools that users can interact with using VR controllers. This setup aims to offer a clearer perspective on quantum concepts such as Pauli gates, Hadamard gates, and phase delay gates.

Developed with the Unity XR Interaction Toolkit, the program is designed to be compatible with various VR devices. Features include a streamlined optical alignment process and a 'Polarization Verification Device' for monitoring polarization.

## Development Details

- **Development Environment**: Unity Game Development Platform
- **SDKs Used**: Unity XR Interaction Toolkit, CSML (C# Matrix Library)
- **Solution**: Optical devices were created as in-game objects to facilitate light polarization experiments.

**Development Timeline**:
- **August 23**: Set up Unity and integrated with a VR headset.
- **August 24**: Established basic user-object interactions.
- **August 25**: Added wave visualization and furthered quantum physics exploration.
- **August 26**: Introduced a virtual device (Socket) for optical device placement.
- **August 27**: Developed an algorithm for laser trajectory.
- **August 28**: Added more optical devices.
- **August 29**: Incorporated light polarization phenomena and a verification device.
- **August 30**: Compiled the report.

## Additional Description

In Unity, entities within the game are termed "GameObjects." These can be equipped with "Components" for added functionalities. Custom components, scripted in C#, were used to give each GameObject its optical properties. An algorithm, inspired by recursive functions, was developed to simulate light behavior in the lab.

The lab offers examples to guide users. In one setup, "sockets" allow users to position optical devices. This setup demonstrates the journey of horizontally polarized light to circular polarization, with each step providing a quantum perspective.

QuPid's VR lab is a modest attempt to bridge the gap between light polarization and qubits. The lab can elucidate single qubit phenomena, drawing parallels with foundational quantum concepts. The potential inclusion of a \( \text{CNOT} \) gate could further expand the quantum explorations.

---

*Note: The "Figure 2" mentioned in the description is assumed to be included in the actual README.md file.*
