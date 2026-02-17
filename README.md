<p align="center">
  <img align="center" width="360" src="ToF%2COK!.png" />

  <h1 align="center">ToF, OK!</h1>
  <h3 align="center">A pro & ar UGC tool to jumpstart your virtual fashion projects!</h3>
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
## Script
### TofOkManager.cs
| VARIABLE | DESCRIPTION | TYPE | DEFAULT VALUE |
| --- | --- | --- | --- |
| Point Brush | Use models as brush. | GameObject |  |
| Line Brush | Use LineRenderer as brush. | GameObject | LineBrush_Default |
| Sound | The sound once generated a brush will be played. | AudioClip | ui-app.wav |
| Toggle Point | Active the point brush function. | bool | True |
| Toggle Line | Active the line brush function. | bool | True |
| Toggle Face | Visible the face mask. | bool | False |
| Transparent Face | The initial material of the face. | Material | TransparentFace |
| Nr Drawing | When triggered, the brush generates a position factor between the index finger and thumb. The range interval is 0~1. | float | 0.5 |
| Interval | The time interval at which each brush is generated. | float | 10 |
| Threshold | When triggered, the distance between the index finger and the thumb. The unit of measurement is meters. | float | 0.05 |
| Face Jewelry | The initial jewelry on face. | GameObject | OnFace |

## Verification environment

Operation was verified in the following environment:

* [Unity](https://unity.cn/releases) Version  : 2020.3.28f1
* [ToF AR](https://developer.sony.com/develop/tof-ar) Version : 1.0.0  

## Documentation
- [Augmented Realities before AR](https://blog.csdn.net/weixin_45454260/article/details/125945766) - 被定义之前的增强现实
- [ToF AR Basics for Unity](https://blog.csdn.net/weixin_45454260/article/details/125945096) - ToFAR基础与Unity设置
- [ToF AR Hand Component](https://blog.csdn.net/weixin_45454260/article/details/126282902) - ToFAR Hand手势识别
- [Face Tracking](https://blog.csdn.net/weixin_45454260/article/details/126009355) - 人脸跟踪
- [Developing an AR Applications with ToF AR](https://blog.csdn.net/weixin_45454260/article/details/126157224) - 开发增强现实应用程序

## Roadmap
### Released  
 * [x] `Gesture Paint` `pinch` Use the gesture to paint in the air.
 * [x] `Face Anchor` Fix the result on the real-time face.
 * [x] `Point Brush` `Default` Main element for storing artists’ model element, which I called Point.
 * [x] `Line Brush` `Default` Black line with gradient width, that artists can apply their own particle shaders on, which is Line.
 * [x] `Point Brush` `Glass Sample` A refraction sample for show the possibility of point brush.
 * [x] `Line Brush` `Liquid Sample` A refraction sample for show the possibility of line brush.
 * [x] `Delete function` Delete the point or the whole trace.
 * [x] `Shader Graph support` For the easilier usage to the artists.
### In Progress
 * [ ] `Image Filter` Apply stylized effect on the real view, both color image and tof image.
 * [x] `Point Brush Elements` As the flower in the demo, there will be more elements such as diamonds, stars and etc..
### Planned
 * [x] `Result Export` `Video` Save and export the result for the ability of sharing and selling.
 * [ ] `Result Export` `Model` Save and export the result for the ability of sharing and selling.
 * [ ] `Symmetry Mode` Create brush’s copy symmetrically.
### Consideration
 * [ ] `Paint on the face mesh` Use the finger to paint on the texture of the facemesh generated.
 * [ ] `Body Anchor` Fix the result on the real-time body for Digital Fashion.
 * [ ] `More gestures for different brushs` For the easilier usage to the artists.
 * [ ] `Mesh Brush` Allow artists to create more 3D result.

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
