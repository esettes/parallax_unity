# Parallax effect


Simulation of depth of field with [parallax effect](https://en.wikipedia.org/wiki/Parallax) applying movement to different background layers. This technique is based on an optical illusion, the further away the elements are, the smaller we see them.


<div align=center>
  <img height=228 align=center src="https://github.com/esettes/Parallax_Unity/blob/main/Assets/screenshots/s2.png">
  <img height=229 align=center src="https://github.com/esettes/Parallax_Unity/blob/main/Assets/screenshots/s1.png">
 </div>

<br>

Taking as a reference the camera that follows the character, a higher or lower multiplier is applied to each layer depending on how far away we want to place it. In this case, the [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.3/manual/index.html) package has been used to achieve the effect.
