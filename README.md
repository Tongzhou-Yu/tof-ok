<p align="center">
  <img align="center" width="360" src="ToF%2COK!.png" />

  <h1 align="center">ToF, OK!</h1>
  <h3 align="center">An UGC tool to jumpstart your virtual fashion projects!</h3>
</p>

<!-- Badges -->
<p align="center">
  <a href="https://github.com/Tongzhou-Yu/tof-ok/blob/main/LICENSE">
    <img src="https://img.shields.io/hexpm/l/plug">
  </a>
  <a href="https://github.com/Tongzhou-Yu/tof-ok/issues">
    <img src="https://img.shields.io/bitbucket/issues/Tongzhou-Yu/tof-ok">
  </a>
  <a href="../../issues/new">
    <img src="https://img.shields.io/badge/Ask%20me-anything-1abc9c.svg">
  </a>
</p>

<!-- Links -->
<p align="center">
  <a href="https://testflight.apple.com/join/EMaJ7vUF" target="_blank">
    <img src="https://img.shields.io/badge/View%20iOS%20Demo-%E9%9B%B7%E7%94%B5%2COK!-orange" />
  </a>
  <a href="https://twitter.com/TongzhouYuu" target="_blank">
    <img alt="Twitter: TongzhouYuu" src="https://img.shields.io/twitter/follow/TongzhouYuu?style=social" />
  </a>
</p>

<a name="about"></a>
# About ToF,OK!  

ToF,OK! is an UGC solution using ToF AR toolkit for virtual fashion designers who are working in metaverse creative industries.  
The vision is to enable the designer to move away from traditional 3D design workflows and design augmented reality products in augmented reality interactions, just like the tailoring approach in apparel design.  
<br />
| Component | Description |
| --- | ---|
| TofOkManager | Important. All make up assets on, such as point brush, line brush and sound. |
| UIManager | Optional. Control the funtion of the UI assets. |

## Verification environment

Operation was verified in the following environment:

* Unity Version  : 2020.3.28f1
* ToF AR Version : 1.0.0  

## Roadmap

 * [x] Gesture Paint: pinch (Use the gesture to paint in the air.)
 * [x] Face Anchor (Fix the result on the real-time face.)
 * [x] Point Brush: Default (Main element for storing artists’ model element, which I called Point.)
 * [x] Line Brush: Default (Black line with gradient width, that artists can apply their own particle shaders on, which is Line.)

<a name="about"></a>
# About ToF AR

ToF AR, Time of Flight Augmented Reality, is a toolkit library intended to aid in Unity application development for iOS and Android devices. It consists of a group of functionalities based on depth information from ToF / Lidar (light detection and ranging) sensor and so on.

As well as ToF AR, Unity and a compatible device with a ToF sensor are required to build and execute this sample application.

Please see [the ToF AR Site on Sony Developer World](https://developer.sony.com/develop/tof-ar) for ToF AR downloads and development guides, sample applications, and a list of compatible devices.  

<a name="environment"></a>
# Development environment

## Build library
ToF AR is required in order to build.
Please download the Toolkit from [the ToF AR Site on Sony Developer World](https://developer.sony.com/develop/tof-ar) and import it.
Please see [Setting up AR Foundation](https://developer.sony.com/develop/tof-ar/development-guides/docs/ToF_AR_User_Manual_en.html#_setting_up_ar_foundation) in the [ToF AR user manual](https://developer.sony.com/develop/tof-ar/development-guides/docs/ToF_AR_User_Manual_en.html) for more information on how to set up AR Foundation.  
If the project is opened before importing, a confirmation message for entering safe mode will appear depending on the settings.  
If safe mode is entered, please import after exiting safe mode from the safe mode menu etc.

## Documents

ToF AR Development documents are also available on Developer World.

* [ToF AR user manual](https://developer.sony.com/develop/tof-ar/development-guides/docs/ToF_AR_User_Manual_en.html) for overview and usage
* [ToF AR reference articles](https://developer.sony.com/develop/tof-ar/development-guides/docs/ToF_AR_Reference_Articles_en.html) for articles about each component
* [ToF AR API references](https://developer.sony.com/develop/tof-ar/development-guides/reference-api/reference/api/TofAr.V0.html)


<a name="contributing"></a>
# Contributing
**We cannot accept any Pull Requests (PR) at this time.** However, you are always welcome to report bugs and request new features by creating issues.

We have released this program as a sample app with a goal of making ToF AR widely available. So please feel free to create issues for reporting bugs and requesting features, and we may update this program or add new features after getting feedback.
