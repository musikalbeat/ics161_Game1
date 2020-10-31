## ICS 161 Game 1 [Rework]
The original game was created 2 years ago for a Unity class I took. I was unfamiliar with Unity back then and produced a game that was rather messy. When revisiting old repositories, I thought it would be fun to revamp my old works and better them rather than leave it in a pile of its own misery.

The mini-game will be titled "Alice in the Dark Forest" and is played as a 2D platformer.

## Assets
I kept all the assets the same and added nothing new. I also wanted to link/credit the creator but I could not locate this asset on the Unity Asset Store nor on YouTube where I recall watching their tutorial video. If I so chance upon it again, I will edit this.

## Using Tilemap
In the original game, I created my walls with multiple platforms stacked on top of each other. This was messy and looked terrible when looking at all the uneven colliders. With the tilemap, I can easily plot out the levels and erase with ease. Tiles can easily be duplicated with the brush tools and a collider can be implemented for any tilemap layer, so I can have a ground layer with collider and a decoration layer with no collider.

## Player Movement
An issue I remember being critique about is the character being stuck to the walls when jump onto the colliders. Being a complete beginner, I thought it was due to each of the walls consisting of many boxes. However this wasn't the case as tilemaps create multiple coliders per tile. After searching around, I realized I was able to implement a physical material for the character's collider. The physical material can influence friction and bounciness. Problem solved!

## Adjusting Animations
The previous version used only 1 animation change when jumping, making the player look stiff. I haven't use the Animator much, but after messing with some of the settings the player now have a jump up animation and a falling animation.
