
# Table of Contents

1.  [HOOPERS - A Basketball shooting game based in Augmented Reality(AR)](#org9464bdd)
    1.  [Introduction](#org9fbf85a)
    2.  [Install](#org6f9c659)
    3.  [How to Play ?](#org30a4657)
    4.  [Game Mechanics](#org14e6082)
        1.  [Basketball](#org475c368)
        2.  [Hoops](#org4bd0c38)
        3.  [Score](#orgbf50a1b)
        4.  [Lives](#org6611271)
        5.  [UI](#orge6dd0c2)
        6.  [Audio](#org9b99fb1)
        7.  [Confetti Animation](#org532775c)



<a id="org9464bdd"></a>

# HOOPERS - A Basketball shooting game based in Augmented Reality(AR)


<a id="org9fbf85a"></a>

## Introduction

This game is developed as a class Assignment for the Computer Graphics Course. Hoopers is a game which birthed from the idea of combining a shooting game with a fast paced score-crunching gameplay. 


<a id="org6f9c659"></a>

## Install

You can build the game for any Android Device(device should be support AR), by installing the Unity 2021 LTS Version and building it for AR. 


<a id="org30a4657"></a>

## How to Play ?

Since the game is based on AR, you would have be greeted by numerous floating hoops in your screen, along with a small aiming ball at the centre. Simply rotate your phone to aim the hoop and press the "Throw" button to shoot the basketball. 

    Note The Hoops may not always spawn at the screen, try pointing the phone at different angles to see the hoops. 


<a id="org14e6082"></a>

## Game Mechanics

This is description of all the game mechanics used in the game and how they are implemented. 

<a id="org475c368"></a>

### Basketball

1.  Initilization and Destruction

    The ball is spawned just below the camera, whenever the player presses the "Throw" button and is destroyed after 5 seconds of being thrown. 

2.  Projectile Motion

    The basketball is not shot but is thrown, this should be reflected by the projectile motion of the ball.
    
    This was implemented by calculating by :-
    
    1.  the distance between the hoop and the ball
    2.  then, the velocity needed to launch the ball to the distance at a certain angle
    
    We decided on the angle 65 to be made default in the game because otherwise the projectile wouldn't be properly reflected in the gameplay and going any further would mean the ball would take longer to reach the ground. 

3.  Projectile to different Heights

    The hoops would in the game would spawn at diffferent places and at different height. For this reason, traditional projectile equations for 2d plane won't work to make things easy we rotate the ball in such a manner that the local axis of the ball aligns with the hoop, this solves the projectile in 3d plane and also at different height. 


<a id="org4bd0c38"></a>

### Hoops

The hoops contain two parts, a wooden board and a net in the bottom.

1.  Distance from Hoops

    The distance of the hoops should always remain a constant no matter the movement or the height. To acheive this we made an empty object at the centre(camera position) in reference to which the Hoops would be always at a certain distance. This mechanic was introduced after the it was observed that it was difficult to pinpoint the distance of the hoop from the camera. 

2.  Types of Hoops

    There are three types of hoops present in the game :-
    
    1.  Static Hoops
    2.  Horizontal Motion Hoops
    3.  Vertical Motion Hoops

3.  Position of Hoops

    The initial position of the hoops are generated randomly in which we take account of the height and width of the space in which the hoops should spawn. The three types of hoops have different probability of spawning and are all random. 
    
    1.  Probability
    
        The probability of spawning a certain type of hoop be it static or motion is calculated by a probability function which takes the game score as its argument. The result of this is that initially after score = 5, there is a 10 % chance that the next hoop will be that of a vertical motion one, 30 % chance of a horizontal motion and 60 % chance of a static hoop. And as the score increases, the probability for motion hoops increases making the game difficult.

4.  Motion of Hoops

    The motion of the hoops is not achieved by applying velocity to it but rather rotating the hoops around the center(camera position). This is less performance intensive but also in this manner the hoops always face the camera. 
    
    1.  Speed
    
        The speed of the hoops is simply the speed at which they are rotated, this speed is calculated through a speed function which takes score as its argument and thus increases with score. 


<a id="orgbf50a1b"></a>

### Score

The score is increased whenever the ball passes through the hoop collider placed at the center. 


<a id="org6611271"></a>

### Lives

There is a single life given to the player at the start of the game

1.  Increase of Lives

    The lives increase if you manage to score 3 consequtive hoops without missing. 

2.  Decrease of Lives

    The lives decrease if you miss 3 consequtive shots. 

3.  GameOver

    The GameOver happens when your lives become 0. 

<a id="orge6dd0c2"></a>

### UI

1.  Main Menu

    The Main Menu consists of a background and three options:-
    
    1.  Play
    2.  Options
    3.  Exit

2.  Options

    At the start the options UI has only a volume slider but later in the middle of the game this also has "Return to Main Menu" and "Exit" options. 

3.  Game Over

    The Game Over UI appears when the player loses and it has a exit option.

4.  Gameplay Layout

    The gameplay layout consists of a single "Throw" button at the bottom, a score text at corner right, a lives UI at corner left. 

<a id="org9b99fb1"></a>

### Audio

1.  Background Sounds

    There are three different background sounds suited for 3 different scenes i.e Menu, Gameplay and GameOver. 

2.  Effects Sound

    Effects sounds are placed for scoring, throwing the ball, Decreasing of Lives and Menu selection. 

<a id="org532775c"></a>

### Confetti Animation

There is a confetti animation in which rectangles shapes of different colors explode from a hoop when a hoop is scored. 
