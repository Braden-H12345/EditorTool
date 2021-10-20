README

-----------------------------------------------

These abilities are simply examples on how to cast an ability and recommended setup.
These do not do anything other than send a message to the console to let user know something worked!

Available to simply show how the tool works (it reads from data on the character and at runtime attaches the scripts needed. 

Allows user to make any type of ability through the Scriptable Objects and attach to a character. Then a script will be auto generated with that
ability name. Behaivoir will have to be implemented by user though as it is not possible to predict all types of possible ability behaviour!

If you wish to rename abilities after tool usage be sure to follow the naming convention in examples folders.


From examples:
HealingAura.cs is named for the Healing Aura ability (in SampleAbilities folder)
IceSpear.cs is named for the Ice Spear ability
and so on...

------------------------------------------------

TO USE TOOL:

Open > Window > CharacterCreator

Then fill out the various fields and press Create Abilities to move to ability creation. After filling fields of abilities click the create button
to then create the various assets.

MULTIPLE ASSETS WILL BE CREATED

4 ABILITY DATA ASSETS (One for each ability, type of data varies based on ability type)
4 ABILITY SCRIPTS (all templated to include IAbility interface and Cast method. File named for the ability)
1 CHARACTER (named after the character name you filled inside the tool.)