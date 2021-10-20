README

-----------------------------------------------

These abilities are simply examples and may not behave like one would think!
(currently they all simply Destroy a predetermined object SUBJECT TO CHANGE)

Available to simply show how the tool works (it reads from data on the character and at runtime attaches the scripts needed. 

Allows user to make any type of ability through the Scriptable Objects and attach to a character. Then can code behaviour for that ability too so it attaches it!

One thing to note is ALWAYS name the code (the thing doing the work!) the same as your ability name!

From examples:
HealingAura.cs is named for the Healing Aura ability (in SampleAbilities folder)
IceSpear.cs is named for the Ice Spear ability
and so on...

------------------------------------------------

TO USE TOOL:

Create a game object (any kind does not matter)
Attach DataHolder script and attach character you would like to use

THERE ARE SAMPLE CHARACTERS IN "SampleCharacters" FOLDER

Then scripts will be added according to the abilities on the character AT RUNTIME

Press key that is mapped to that ability to use!