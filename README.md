## Inspiration
Many Lego fans choose to design their own builds and order the parts required to bring their creation to life. However, it was quite hard to design a build when you don’t have the pieces to do so with.

## What it does
LegoStudioVR provides a simulated environment for people to build lego. Users have access to a large pool of different blocks, including humanoid and animal pieces, all supporting a wide range of coloring options.

## How we built it
The main software was created on Unity Game Engine, using the Oculus SDK. A large portion of the assets was created by the team, most of which was done in blender.

## Challenges we ran into
This project was the team’s first VR project, and in the case of some members, their first unity project. So it was a giant learning experience for the whole team.

Although the Oculus Rift S is known for its smooth setup and usage, we had many, many problems setting it up to begin with. For whatever reason, the headset would not pass its own sensor calibration test, and required multiple firmware restarts. It would not detect that it was connected to display port and the screen would remain dark. Once the team finally got the headset connected, the Oculus seemed to have some sensor problems where it would sometimes think that the left controller was the right controller, and which was extremely confusing. The team believed that it was a hardware issue and debugged for multiple, multiple hours.

Using blender for the first time means that we were unsure of what was possible, what wasn’t possible and what was unfeasible. Major obstacles visually included light leakage in a sealed room and coloring spherical objects with bands.

## Accomplishments that we're proud of
Managing to render a playable environment with good assets was a major accomplishment as no one on the team had experience with blender or creating 3D environments or assets.

There was also quite a huge amount of assets we had to manage, as we had access to the models from a Lego CAD program. We had to work out a proper naming convention, scale, and orientation in order to standardize the models we had.

The main features were finished relatively quickly, so a large portion of time was spent on polishing, getting every single tiny detail just right.

## What we learned
Our team got a crash course in Unity, VR, Oculus, and Blender, as well as overall game development. Our wide range of experience and skillsets allowed for us to delegate tasks and practice rapid development in a team environment.

## What's next for LegoStudioVR
More bricks! As of the moment, all brick models must be passed through blender and exported to Unity, where it is then given a collider and scaled down to match the scene. This is quite a timely process, so finding a way to automate this would be the next step. Once we get all these bricks in, the inventory system would have to be revamped. Currently, the user would scroll through all of the brick options and look for the one they want, as we have a relatively low number of bricks. However, once we get a couple hundred assets, some sort of search window and organization of the bricks into subsections would be required.
