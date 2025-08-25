# Prototype_3_Game_Design
 
## Intent:

In looking at the GDC Europe video (Juice It or Lose It) with speakers Martin Jonasson
and Petri Purho (2012), the Art of Screen Shake video by Dutch Game Garden with
speaker Jan Willem Nijman (2013) and the Anatomy of a Successful Attack by Ben Ruiz
and Matthew Wegner (2015), I decided I want to learn how to implement feedback
elements in a certain game type.

The game type I chose is a platformer.

In doing this, I hope to learn how to make my games juicier.

**What do I mean by wanting to learn how to implement these elements?**
- I do not know how to apply screen shake.
- I suck at particle systems and making them look like something.
- How to use sound effects effectively escapes me and honestly terrifies me (also,
which sound effects to use).
- I do not know how to add small movements to items in the game to make them
more alive.

**What do I mean by juicy?**
- In simple terms, reactive.
- I want the simulation to do something when the player interacts with it.

**What do I want to explore?**
- As mentioned before, there is a list of feedback elements I do not know how to
implement, and I would like to learn how to implement them.
   - I do not want to spend several prototypes on this, so I thought the best
course of action would be to shove it all into one prototype.
- I think it might be useful to have a place where I have explored these different
aspects and a place I can refer back to when I want to implement these aspects
again.

## Process:

The first thing I did was sit and decide what feedback elements I would like to learn how
to implement. This list became longer and longer as I made this prototype, so much so
that I had to stop myself at some point as to not over scope too much.

The things I decided on are as follows:
- I would like to implement some sort of animation.
- I would like to use sound effects.
- I would like to implement screen shake at some point in the prototype.
- I would like to add different types of particles to different situations in the
prototype.

There were a few extra things I learned on the way as well, and I will make a mention to
these at the end.

**Animation:**

There are a few places I implemented animations in this prototype:
- The player movement.
- The enemy movement.
- The gun movement.

This is something I struggled with a lot. This part of the prototype is the part that
probably took me the longest to figure out how to implement properly, and to be honest
it still needs a lot of improvement.
- I started with the player movement animation.
- I made some simple sprites that would be easy to animate into a walking
animation and an idle animation.
- I made a small sprite sheet for each type of animation.
- At first, I thought I would need to have animations for the player facing right and
left in both a walking and an idle animation.
- This gave me a lot of trouble the moment I got to actually putting the animation
into unity.
- The only way I was going to be able to make the animations change the way I
wanted it to, was to use states in the animator… I dreaded this.
- So, I turned to Google, and found a video by Brackey (2018) that gave a simple
way of adding animations in Unity. I did not follow it precisely, as there were
some things I wanted to do differently:
   - An example is, that in my parameters I used integers instead of floats,
because I wanted the transitions to be precise.
- I got the animations to work… sort of… and decided to move onto having them
change directions when the player moves in different directions.
- This was a challenge to say the least. I made the animations for both directions
and tried to add them to Unity in a similar way as the video showed, but for some
reason the change inanimations were delayed.
- After banging my head against the wall for a bit, I went back in and fiddled with it
a little.
- I found that I could change the scale of the sprite on the x-axis to negative to
change the direction the player sprite was facing, and this happened without a
delay, and without having to use animations for both directions.
- One thing I have not figured out, and still haven’t because I ran out of time, was
to get it to transition to the jumping animation. I left it as is, as I had no more time
to fiddle with this and I needed to move on to other things. (No one seemed to
notice in the playtesting, but I know, so it still hurts my soul)

- With the gun animation I had to approach it a little differently, as it was a singular
animation that had to only happen once on a click.
- So, I found a video by The Game Guy (2020) that taught me how to use the
Boolean parameter in the animator. This was a relatively easy animation to
achieve after learning how to actually use this parameter, and I am pretty sure
this will come in handy again one day. The gun shaking was easy enough, but it
does add an amazing amount of feedback to the shooting of the gun.

- The last animation was the enemy walking animation.
- This had to be approached a little differently from the player walking as it had to
transition between the directions on its own without pressing a button.
- This, luckily, had not much to do with the animator states. It only had one state,
the walking animation.
- I used the same 2 lines of code that made the player move, but I just made it
move the whole time.
- I then checked in which direction the sprite is looking, and then made the enemy
move in that direction.
- To make it move from left to right, every time it hits a wall, it changes the
direction.
- After realising it gets stuck when you shoot the enemy too many times, I just
made the enemy move in the player’s direction when the player shoots it.

In conclusion, I learned a lot about the animations and animators in Unity, but I still
have a lot to learn. The jumping animation was not on my side in this one and I will need
to go back to that and do some more research.

**Sound Effects:**

Implementing the sound effects was a lot of fun, and a lot simpler than I thought it
would be.
- I started with the player walking sound.
- I was struggling a bit at the beginning because every time I made the player walk,
it would keep playing the sound constantly and it made a horrifying sound.
- I realised I would need to put in some sort of timer, but I was not sure how I
would do this.
- I found a forum blog post on Sharp Coder (n.d.) that explored how to make
footsteps play separately with each step.
- I followed the blog and adjusted the numbers to match the timing of my player
animation footsteps, and I soon had my player walking with a slightly squishy
footstep.
- I honestly thought it would be harder than that.
- In looking at this post, I learned about the PlayOneShot function on audio
sources, and this came in handy with all the other sounds that I implemented in
this prototype.
- I implemented the same timer system with the enemy footsteps, and the sound
that the enemy makes every few seconds. This made my player and my enemy
sound more alive.
- With the other sounds:
   - The sound the player makes when they jump.
   - The sound the player makes when they land.
   - The sound the gun makes when it shoots.
   - The sound that the bullet makes when it hits the wall.
   - The sound that the bullet makes when it hits the enemy.
   - The sound that the enemy makes when it is hits the wall.
- I used the PlayOneShot function every time these actions occur, in order to add
more juiciness.

This worked a lot better than I thought that it would. I honestly thought I would have to
fiddle with the sound elements a lot more in order to make them sound right. I do not
know why I was so afraid to implement sound before this.

**Screen Shake:**

I first had to decide where I would like to implement the screen shake. There were a few
places I could have added it, like:
- Landing after a jump.
- When the player hits the wall.
- When a bullet hits the wall.
- When the bullet hits the enemy.

I decided to choose one of these, the jumping. I could have easily added this screen
shake to all of these options, but because I wanted to add so many different feedback
elements, I only added it to one. The point of adding the screen shake was to learn how
to do it after all. I did not want to shake the hell out of the screen every time I got a
chance, that might have been a little over kill.
- I also faced a few challenges with this.
- I went through a few websites and videos before I found one that I could actually
get to work.
- There was not much to this process, accept for a lot of trial and error, for a long
time before I finally found a video that helped me figure this out properly, and in a
way that made it look the way I wanted it to.
- The video was by Indie Nuggets (2018). The video explained in diagrams what the
aim was and then moved on to how to do it.
- Now I have a piece of code that I can add to whatever game I want to have screen
shake in in the future, and I cannot explain how happy this makes me.

**Particle Systems:**

I added a Particle System to a few places in this prototype:
- When the player changes direction.
- When the player jumps.
- When the player lands after a jump.
- When the gun shoots there are spark.
- When a bullet hits the wall, the wall crumbles,
- When a bullet hits the enemy there is blood splatter.

I had a basic idea of how particle systems worked, but I was still very unsure, and they
never really looked the way I wanted them to. The particle systems in this prototype
looks a lot more like I want them too and they fit the elements they were supposed to
convey. I think I could still go back and adjust them more, play around for a bit longer to
make them look even more like I want them too, as I still feel they could be better.
- I started with the particle system that will show the dust that rises when the
player changes direction.
- I found a video by Press Start (2019), that showed how to make a dust cloud that
looks like the dust that rises in Super Mario World (1990) when mario changes
direction.
- I followed the tutorial, and adjusted the numbers in the particle system that the
tutorial used in such a way that it looked like the dust cloud I wanted.
- I found this tutorial very useful, as it showed me how to use parts of the particle
system I had never used before, or never knew how to use. It also gave me the
confidence to start experimenting with the other things in the particle system to
achieve other effects that might be cool.
- I soon moved on to the particles that pop up when the player lands. These are
like the dust clouds, but they are placed in a different shape and falls down
instead of float.
- I did the same with the particles that come out of the wall when it gets shot, but
here I learned how to use the collision of a particle system properly. I played
around with it for an embarrassingly long time before I found the setting that
made it collide in the 2D world.
- After that I played around with different materials in the rendering of the particle
system, as well as the colours and shapes. From this came the sparks that came
from the gun and the blood splatter.

I really enjoyed playing around with the particle systems. It took very small changes to
make the system look like either sparks or blood, and I found this fascinating. It was
interesting to see how big of an effect on these systems I could make with just minor
changes to some settings.

**Anything Else I did and learned in this prototype:**

- I wanted the player to recoil when they shoot, I wanted the player to recoil when
an enemy hit them, and I wanted the enemy to be pushed back when it gets shot.
   - The player recoil with the gun and the enemy hit was the same process, I
used AddForce (which is a function I learned about in my Prototype 2), to
push them in the opposite direction ever so slightly.
   - It might be more intense than I wanted it to be, but it works.
   - With the enemy, the push back happened automatically because of the
Rigid Body 2D that was on the Game Object. Yay for accidental
successes.
- When working with the particles, I wanted the particles to appear at the precise
point where the bullet hit. I was not sure how to do this, until I discovered you
can record the position of the collision in a OnCollisionEnter function. This was
an extremely useful discovery.
- When trying to get my gun to shoot bullet, I was struggling quite a bit, so I found a
useful video by Unity3D School (2021) which I though was worth mentioning
here.

## A note on balancing:

As this prototype was more about learning how to implement these feedback elements,
I did not find that I did much noteworthy balancing, except for messing around with the
‘feel’ of the particle systems.

However, when having people playtest, I had a lot of comments of how some of the
feedback elements felt overly strong, so there is some balancing to be done, especially
on the day I implement these into more fully formed games.

I will keep that in mind for the future, but for this prototype, I did not find it necessary to
go ham on the balancing.

## Playtests:

**Player 1:**

*There are many feedback elements I could implement in a platformer. Are there any elements you think would have increased the ‘juicyness’ of the simulator that I missed here?*

There are no specific elements that I can think needs to be added to this prototype at
this time.

*Do you feel any of the elements in this simulator could have been implemented in a better way? Which ones and how would you suggest I do so?*

The gun recoil feels too strong. It pushes the player back quite a bit, it might be best to
lessen the amount the player is being pushed back a little bit.

Also, the player can jump very high, and it feels overly ‘floaty’. Maybe make the jump a
little less intense.

*Do you feel that when the elements are added the ‘platformer’ feels more reactive?*

Yes, the elements definitely make the prototype feel very reactive. It does feel like
something happens every time I do something.

*Are there any elements that I implemented here that you feel are overkill? Why?*

There were no major elements that I felt were overkill, but the blood splatter felt a little
bit over the top.

*Are there any other feedback elements, used in a platformer or not, that you think would be valuable to learn?*

At this point in time, I cannot think of anything else.

**Player 2:** 

*There are many feedback elements I could implement in a platformer. Are there any elements you think would have increased the ‘juicyness’ of the simulator that I missed here?*

Nope, there are not any elements I can think of that would increase the juiciness.

*Do you feel any of the elements in this simulator could have been implemented in a better way? Which ones and how would you suggest I do so?*

The shotgun recoil looked like it added a lot more pushback than the walking strength,
since when I spam the gun, it kept pushing me back into the wall long after I had
stopped spam shooting.

The zombie hit label in the feedback element panels should say "You hit by the zombie"
as I had assumed that that was the setting to make the zombie make noises if I as the
player hit it with the gun.

The running particles shouldn't be activated when I jump. It does not look right have the
dust cloud when I jump up.

The landing particles and screen shake also happened when I hit the site of the
platform, and I feel that should not have happened.

Keep the jumping noises to only when you jump, as I could hear the jump noises when I
was mid-air but no added jump height.

When the player is hit by the enemy, the player sprite should go red momentarily to
showcase that the player was injured.

*Do you feel that when the elements are added the ‘platformer’ feels more reactive?*

Yes, it makes the effects of my actions feel more impactful.

*Are there any elements that I implemented here that you feel are overkill? Why?*

No overkill elements, I felt they were all of a suitable amount.

*Are there any other feedback elements, used in a platformer or not, that you think would be valuable to learn?*

Health bars and how health bars react (so like some health bars blink red and shake). I
think this would be beneficial not only for platformers but for other types of games as
well.

**Player 3:**

*There are many feedback elements I could implement in a platformer. Are there any elements you think would have increased the ‘juicyness’ of the simulator that I missed here?*

There is not any feedback element that I can think of that you possibly missed.

*Do you feel any of the elements in this simulator could have been implemented in a better way? Which ones and how would you suggest I do so?*

It's not really feedback related but the gun kind of looks like just a stick or a wand, so
that visual element feels a bit disjointed but ultimately the actual effects and feedback
are good.

*Do you feel that when the elements are added the ‘platformer’ feels more reactive?*

Yes, the feedback elements make it feel a lot more reactive, that when there are no
elements.

*Are there any elements that I implemented here that you feel are overkill? Why?*

The screen shake is the only element that felt a bit excessive. It could maybe only come
into play after falling from a higher place, and not every time the player comes down
from a jump.

*Are there any other feedback elements, used in a platformer or not, that you think would be valuable to learn?*

There are not any I can think of at this moment in time.

**Player 4:**

*There are many feedback elements I could implement in a platformer. Are there any elements you think would have increased the ‘juicyness’ of the simulator that I missed here?*

I think it would have been beneficial to add more feedback when the player is hit by the
zombie, like a particle effect or a colour change to the player sprite.

*Do you feel any of the elements in this simulator could have been implemented in a better way? Which ones and how would you suggest I do so?*

Getting damaged by the zombie. I feel like it was never really communicated properly
that I was damaged. The injured sound for the player just gave me an indication that I
was touched by the zombie, but not injured. I don’t think the sound is wrong or a bad
thing, just that it is not a strong enough element on its own to communicate that I was
damaged and how much damage I had received. It just needs a visual element as well.

The recoil from the damage feels more like the zombie is just pushing me and not
hurting me. Maybe if you added a particle effect for the zombie’s attack, or just let the
player flicker in different colour will help with communicating contact, like I mentioned
above.

*Do you feel that when the elements are added the ‘platformer’ feels more reactive?*

Yes, there is a definite different feel to the game after the elements are added.

*Are there any elements that I implemented here that you feel are overkill? Why?*

No. The feedback elements implemented makes sense for the actions taken and at no
point did the effects feel overwhelming.

*Are there any other feedback elements, used in a platformer or not, that you think would be valuable to learn?*

I think you got most of the basics down in the prototype. New things you could learn I
think would be very situational, like if you are making a platformer that is based on
speed and where the player moves at different speeds, like the sonic games. It will be
important to be able to build a system that can communicate the different speeds.
Thus, it very heavily depends on what you want to do for any other games.

**Player 5:**

*There are many feedback elements I could implement in a platformer. Are there any elements you think would have increased the ‘juicyness’ of the simulator that I missed here?*

Honestly from my perspective I think you basically covered most things here. I would
say maybe trying to add feedback when being touched by the zombie, like it damaging
you also show that touching the zombie is bad as well. Even though you won't die I think
that can add a feeling of urgency, but I do not think with what you did here, that is
necessary.

*Do you feel any of the elements in this simulator could have been implemented in a better way? Which ones and how would you suggest I do so?*

I think you implemented everything quite effectively.

The only part I would go back to is where the screen shakes when the player hits it from
underneath.

*Do you feel that when the elements are added the ‘platformer’ feels more reactive?*

Yes 100% and it feels so satisfying. It's like once you add another one it opens your eyes
up more to the enjoyment of the game.

*Are there any elements that I implemented here that you feel are overkill? Why?*

Just the walking particles. It looks like dust/smoke, so when I see the character walk and
smoke appears it feels out of place because the character isn't running.

*Are there any other feedback elements, used in a platformer or not, that you think would be valuable to learn?*

I cannot think of any extra right now. The elements you did implement are very versatile
and you will be able to use them in many other types of games, which I think is very
useful on its own.

## Reflection on Playtesting:

I found it interesting that all the players picked up on different things that bothered
them. A lot of them I think is preference, but I still think it is worth going back and
adjusting the elements they mention. I agree with a lot of what they said as well, there
are things I could have done better, and things I missed, and I think these tests were
valuable in showing me more clearly what these things are.

## Reflection:

This prototype was more on the simple side of things I could have done. However, I
enjoyed making this prototype immensely. Not only did I learn a lot, but I could see the
things I learned come to fruition.

Most of what I learned is mentioned above in the process part of this document, so I will
try not to repeat myself too much in this reflection part.

I found that making this prototype was extremely valuable. I learned more about certain
feedback elements I knew a little about, and I also learned how to implement
completely new elements (like screen shake for example).

The one thing that surprised me the most was in implementing the sound effects. I was
convinced that it would be a lot harder, and I had an irrational fear when it came to
implementing sound effects, because I was scared the sound effects would not fit with
each other or make no sense.

However, when I actually sat down, and made an effort to look for sound effects that
would work for my prototype and communicate what I was trying to achieve, I found that
it was not THAT hard, and that it could be quite enjoyable. And after learning about a few
tips and tricks to use when using sound, I flew through all the sound effects, and the
ones I chose seemed to fit quite well, especially after making some adjustments to
volume and pitch.

The sound was one of the easier parts that I implemented, but it was the part I had the
most revelations in.

With the particle systems, I already knew a little bit, but I always dreaded using them,
because I struggled to use them in a way that made them look right. But after doing
some research and fiddling a little bit, I found that they could be quite useful and
enjoyable to make. I definitely built up some confidence when it comes to the particle
systems, and I am quite grateful for that.

The animations I still want to smack with a hammer to make me feel better about it,
because even after struggling for a few hours, I still could not get some of it to work. That
is something I will need to go back to and figure out properly in the future.

All in all, this was quite an enriching experience. I now have a bunch of code I can come
back to and use in the future when working with feedback. I know this is going to make
me sigh a breath of relief in the future, as this will make my life a lot easier when making
games. Anything I can use again, and not have to code again is a positive in my book.

## References:

**Resources:**

Belty118. (2019). ‘Move player backwards when firing a gun. Unity 2D. Top Down.’ Unity
Discussions. January. Available at: https://discussions.unity.com/t/move-player-backwards-when-firing-a-gun-unity-2d-top-down/218929 [Accessed on: 20 March
2024]

Brackeys. (2018). 2D Animation in Unity (Tutorial). 5 August. Available at:
https://www.youtube.com/watch?v=hkaysu1Z-N8 [Accessed on: 18 March 2024]

Dutch Game Garden. (2013). Jan Willem Nijman - Vlambeer - "The art of screenshake"
at INDIGO Classes 2013. 16 December. Available at:
https://www.youtube.com/watch?v=AJdEqssNZ-U [Accessed on: 12 March 2024]

GDC Vault. (2012). Juice It or Lose It. Available at:
https://www.gdcvault.com/play/1016487/Juice-It-or-Lose [Accessed on: 12 March
2024]

Indie Nuggets. (2018). How to add Screen Shake in your game with Unity. 11 January.
Available at: https://www.youtube.com/watch?v=rlBZL-woa9U [Accessed on: 20 March
2024]

Press Start. (2019). Dust Effect when Running & Jumping in Unity [Particle Effect].
Available at: https://www.youtube.com/watch?v=1CXVbCbqKyg [Accessed on: 14
March 2024]

Raja-Unity. (2017). ‘How to make player detect when on ground and when lands on
ground.’ Unity Discussions. September. Available at:
https://discussions.unity.com/t/how-to-make-player-detect-when-on-ground-and-when-lands-on-ground/196439 [Accessed on: 14 March 2024]

Ruiz, B. and Wegner, M. (2015) Anatomy of a Successful Attack. Available at:
https://aztez.com/blog/2014/01/06/anatomy-of-a-successful-attack/ [Accessed on: 12
March 2024]

Sharp Coder Blog. (n.d.). ‘Unity Implementing Footstep Sounds.’ Sharp Coder Blog.
Available at: https://www.sharpcoderblog.com/blog/unity-implementing-footstep-sounds [Accessed on: 14 March 2024]

Unity3D School. (2021). Simple Shooting | 2D | Bullets | Unity Game Engine. 20
November. Available at: https://www.youtube.com/watch?v=4KoAlJ8sPy4 [Accessed
on: 12 March 2024]

The Game Guy. (2020). How to make 2D Shooting in UNITY with Gun Recoil – Unity 2D.
21 April. Available at: https://www.youtube.com/watch?v=NKF-FkDzE-s [Accessed on:
20 March 2024]

**Assets:**

artisticdude. (2011). Zombies Sound Pack. 2 January. Available at:
https://opengameart.org/content/zombies-sound-pack [Accessed on: 20 March 2024]

IgnasD. (2016). Jumping Man Sounds. 13 January. Available at:
https://opengameart.org/content/jumping-man-sounds [Accessed on: 19 March 2024]

KuraiWolf. (2019). Light Machine Gun. 13 September. Available at:
https://opengameart.org/content/light-machine-gun [Accessed on: 20 March 2024]

Little Robot Sound Factory. (2015). Fantasy Sound Effects Library. 13 April. Available at:
https://opengameart.org/content/fantasy-sound-effects-library [Accessed on: 13 March
2024]

MentalSanityOff. (2012). Jump Landing Sound. 12 May. Available at:
https://opengameart.org/content/jump-landing-sound [Accessed on: 19 March 2024]

rubberduck. (2019). 75 CC0 Breaking/Falling/Hit/SFX. 8 October. Available at:
https://opengameart.org/content/75-cc0-breaking-falling-hit-sfx [Accessed on: 20
March 2024]