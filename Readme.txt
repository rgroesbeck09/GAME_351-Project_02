______________________________________________________
Program 2 Template (Starter Code) - v. 1.0
School of Information, University of Arizona 
June 14, 2026

This code may modified freely by students of
GAME 351 (Intro to Game Development) for use
in their assignments. Other uses covered by
the terms of the GNU Lesser General Public 
License (LGPL). Note: Some included assets 
may be subject to differing licensing agree-
ments as per the policies of their authors.

To install the project, follow these steps:

1) Create a blank "3D URP" project in Unity Hub.  
   Note: Your project MUST use the Universal 
   Rendering Pipeline for textures and effects
   to render properly.

2) Allow the Unity editor to initialize the project.
3) Save your blank 3D URP project and exit Unity.
4) Navigate to project directory in file system.
5) Drop the "Assets" and "Project Settings" folders 
   into this directory.
6) Open and reload the Unity project you created.
7) In the project navigator, go to the assets directory
   and find the "Scenes" folder.
8) Click on the "Cross-Country Scene" to load it.
7) Go to Unity->File->Build Settings and verify that
   the "Cross-Country Scene" is in the "Scenes in Build" 
   list.
8) If the scene is not in the build list, click
   "Add Open Scenes". The scene should appear checked. 
9) The game template then should be ready for building 
   and running.

Credits:
 
Sample code by Leonard D. Brown, University of Arizona.
This program was developed for educational purposes.

Freeware media assets were used from the following sources:
(1) http://millionthvector.blogspot.com/
(2) https://assetstore.unity.com/
(3) https://www.gameartguppy.com/
(4) https://www.videvo.net/royalty-free-sound-effects/
(5) https://freesound.org/search/

Hovervraft Movement - Raymond Groesbeck
Implemented hovercraft movement by attaching listeners for the A and D keys (left/right), W and S (Forward/backward) to drive hovercraft. 
The hovercraft travels over the landscape, moving and tilting per the terrain elevation. Using a sperate function AlignWithTerrain we use Physics to gather potential/actual hits
to the terrain. From here we get the slope of the enviroment to manipulate the angle and tilts of the hovercraft. 
The camera for each hovercraft stays locked in third person behind the active craft. The camera stays in synch with the hovercraft as it moves creating a follow camera effect.
The implementation of this is simpler. We did need to manipulate the Euler Angles and get the target we are following to make sure the
camera didn't rotate like the ship when going over the terrain. 

Hovercraft types and laser gun - Christopher Garcia-Arvizu:
Used provided hovercraft models and textures to create 3 visually distinct hovercraft models.
With the Movement script we created public function so that we can set the speeds and cornering ability of each type of ship.
Using transform Rotate, Translate we are able to use the speed variables to change the speeds of cornering and forward and backward motion. 
Created C# script for laser gun on the average hovercraft type only that fires when pressing Spacebar. 

Hovercraft Levitation - Amanda Bragg Created a script that makes the ship appear to hover and float. This script is attached 
to the ship game object. In the script, this was done by having variables that control how far the ship moves and how quickly it moves. 
The Update() method runs each frame, and also uses Mathf.Sin() to create the movement that makes the ship appear to hover. 
Used https://www.youtube.com/watch?v=6-pJu0GwK5k for help with writing some aspects of the code. 

Hovercraft toggling - Valeria Ugarte
One hovercraft will be controlled at a time, cycle through hovercrafts by pressing the C key to change the active craft. The active craft
will occupy the center of the screen, the camera will change positions when toggling through the hovercrafts. Active hovercraft will be drivable by 
using WASD keys. Cycling continuously through cars by pressing C will switch between the amount of hovercrafts in the scene and loop back after toggling 
through all of the crafts. 
