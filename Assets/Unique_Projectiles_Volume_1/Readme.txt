Unique Projectiles Volume 1 - Readme


This package contains:

- 20 Projectiles Prefabs;
- 20 Hits/Impacts Prefabs;
- 20 Muzzles Prefabs;
- Demo Scene;
- Customizable Shaders;
- Particle System Controller Script (control size, speed, color, lights, trails, enable/disable vfxs, etc);
- Projectile Script (control fire rate, accuracy, fire point, etc);




DEMO SCENE - SHORTCUTS:

Mouse 1 - Fire Projectile
D - Next Effect
A - Previous Effect
C - Change Camera
Z - Zoom In
X - Zoom Out
1 - Enable/Disable Camera Shake




PARTICLE SYSTEM CONTROLLER SCRIPT - DESCRIPTION:

Options:
'Size' - Multiplies Particle Systems and Trails sizes.
'Speed' - Multiplies Particle Systems and Trails speeds.
'Loop' - Enable/Disable Particle Systems loop.
'Lights' - Enable/Disable Particle Systems lights.
'Trails' - Enable/Disable Particle Systems trails.
'Changes Color' - Enable/Disable changing color of Particle Systems and Trails speeds.
'New Max Color' - New maximum color.
'New Min Color' - New minimum color.
'Particle Systems' - The Particle Systems and Trails the prefab contains. Can be filled automatically with 'Fill Lists' button, or manually.
'Active Particle Systems' - Choose which Particle Systems and Trails are active. Can be filled automatically with 'Fill Lists' button, or manually.
'Fill Lists' - Finds and adds Particle Systems and Trails, of the parent and childs of current gameobject, to 'Particle Systems' and 'Active Particle Systems' lists.
'Empty Lists' - Emptys 'Particle Systems' and 'Active Particle Systems' lists.
'Apply' - It will apply the changes you made (Size, Speed, Loop, Lights Enabled/Disabled, Trails Enabled/Disabled, Change Color) to the particle systems in 'Particle Systems' that ARE active in the 'Active Particle Systems' list. It will also save the original settings in a folder called 'Original Settings' inside the folder of the vfx prefab.
'Reset' - Resets the Particle Systems and Trails to the original settings which are saved in a folder called 'Original Settings' inside the folder of the vfx prefab.

Workflow:
1) Add script to any VFX prefab;
2) Press 'Fill Lists' to automatically find and add Particle Systems and Trails to lists;
3) Make your changes (Size, Speed, Loop Enabled/Disabled, Lights Enabled/Disabled, Trails Enabled/Disabled, Change Color, Enable/Disable Particle Systems with 'Active Particle Systems' lists);
4) Press 'Aplly';
5) Script saves original settings and applies changes;
6) That's it, enjoy. 
PS: You can always press 'Reset' to go back to original settings.

Warnings:
1) Don't change the name of the VFX after you have pressed 'Apply'. Otherwise 'Reset' will not work since it wouldn't be able to find the original settings.
2) You can change the name of the VFX BUT you must go to the respective 'Original Settings' folder and copy paste the exact same name of the VFX. Watch video for a demonstration.
3) 'Fill Lists' won't work if the gameobject contains a Particle System and a Trail (at least for now)




POST-PROCESSING EFFECTS INFO:

All footage was done using Post-Processing Effects. Follow this steps if you want to achieve that quality:

1) Go to Unity Archives ( https://unity3d.com/get-unity/download/archive ), select your version and download the Standard Assets from the drop-down list;

2) Import that package to your project in Unity (you can only import the Effects folder if you want);

3) In the DemoScene01 you can add "Depth Of Field", "Bloom", "Vignetter And Chromatic Aberration", "Sun Shafts" and "Color Correction Curves" components to the cameras;

4) Copy values from screenshot "PostProcessingParameters";

4) Enjoy and Have Fun!




CONTACTS:

Feel free to contact me via links bellow in case you have any doubts. 

Twitter: @GabrielAguiProd

Facebook: facebook.com/gabrielaguiarprod/

YouTube: youtube.com/c/gabrielaguiarprod



Thank you for purchasing the Unique Projectiles Volume 1 package.
Unique Projectiles Volume 01 is created by Gabriel Aguiar
