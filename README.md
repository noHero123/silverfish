## botmakers Ultimate AI
This AI is a Custom Class for Hearthcrawler and intends to simulate all possible turn actions and selects it automatically selects the best.

Official Threads:
- http://www.thecrawlerforum.com/index.php/Thread/5871-The-Ultimate-AI (dead)
- https://www.thebuddyforum.com/hearthbuddy-forum/hearthbuddy-custom-decks/207520-hearthbuddys-deck-aka-silverfish-ai-aka-ultimate-ai.html
- http://www.hearthranger.com/forum/yaf_postst4707_silverfish-update.aspx

build instructions:
if your are using HR:
- copy the Programm.cs and the AI + cards folder in one folder, create a project out of it
- include HSRangerLib.dll from HR
- build it, and copy in the bin\Debug or Release-folder the _cardDB.txt file

Hrtbuddy:
- same like HR, only take the silverfish_HB.cs instead of Programm.cs
- there might be some builderrors I cant fix (don't own HB) if you know how to fix, let me know

### Custom Mulligan
If you want you can configure custom Mulligan Rules. Create an empty _mulligan.txt file in the same folder as your silverfish.dll to get started.

Each line of your _mulligan.txt file is a custom Mulligan rule. Each Value is separated by a semicolon. 

Since this file works with CARD_ID it is very helpful to check out the included _carddb.txt file to find the ID of specific cards.

The Syntax for this file works like this:
```bash
ACTION;YOUR_CLASS;ENEMY_CLASS;MULIGAN_COMMAND
```

Name  | Possible Values | Notes
------------- | ------------- | -------------
ACTION  | discard or hold | This Value defines what to do with the cards matching the Mulligan rule
YOUR_CLASS  | hunter, mage, pala, rouge, druid, warlock, warrior, priest | Only use the Mulligan rule when you play this character
ENEMY_CLASS | hunter, mage, pala, rouge, druid, warlock, warrior, priest | Only use the Mulligan rule when you play against this character
MULIGAN_COMMAND | cards name (look _carddb.txt in silverfish folder) | The Syntax of the Mulligan rule is CARDNAME:CARD_COUNT - multiple cards are separated with Colons eg CARD1_ID:CARD1_COUNT1:CARD2_ID:CARD2_COUNT

Here an example for a Hunter Mulligan:

```bash
hold;hunter;all;FP1_004
hold;hunter;all;FP1_011
hold;hunter;all;FP1_002
hold;hunter;all;NEW1_019
hold;hunter;hunter;EX1_538
hold;hunter;all;GAME_005:1:NEW1_031
hold;hunter;druid;GAME_005:1:CS2_084:1:CS2_203
```



