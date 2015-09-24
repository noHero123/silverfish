## botmakers Ultimate AI
This AI is a Custom Class for Hearthcrawler and intends to simulate all possible turn actions and selects it automatically selects the best.

Official Threads:
- http://www.thecrawlerforum.com/index.php/Thread/5871-The-Ultimate-AI (dead)
- https://www.thebuddyforum.com/hearthbuddy-forum/hearthbuddy-custom-decks/207520-hearthbuddys-deck-aka-silverfish-ai-aka-ultimate-ai.html
- http://www.hearthranger.com/forum/yaf_postst4707_silverfish-update.aspx

build instructions:
if your are using HR:
- copy the Programm.cs and the ai + cards folder in one folder, create a project out of it
- include HSRangerLib.dll from HR
- build it, and copy in the bin\Debug or Release-folder the _cardDB.txt file

Hrtbuddy:
- same like HR, only take the silverfish_HB.cs instead of Programm.cs
- there might be some builderrors i cant fix (dont own HB) if you know how to fix, let me know


How to simulate boards with silver.exe:
- create test.txt file in same folder as silver.exe
- copy your current board, like
```
#######################################################################
start calculations, current time: 00:00:00:0000 V116.27 control 5000 face 15 twoturnsim 1000 ntss 6 16 160 playaround 50 80 ets 16 ets2 160 ents 16 secret
#######################################################################
mana 3/10
emana 10
own secretsCount: 0
enemy secretsCount: 0 ;
player:
1 2 0 1 0 0 0 0 0
0 0 0 0 0 0 0 0 0 0 0
ownhero:
priest 27 30 0 False False 4 True 0 False 0 0
weapon: 0 0 unknown
ability: True CS1h_001 3
osecrets:
enemyhero:
warrior 15 30 35 False False 36
weapon: 0 0 unknown
ability: True AT_132_WARRIOR 0
fatigue: 9 0 7 0
OwnMinions:
twilightguardian AT_017 zp:1 e:212 A:4 H:10 mH:10 rdy:False natt:0 ex ptt spllpwr(1)
EnemyMinions:
boombot GVG_110t zp:1 e:184 A:1 H:1 mH:1 rdy:True natt:0 ex
Own Handcards:
pos 1 arcaneintellect 3 entity 9 CS2_023 0 0
Enemy cards: 4
ownDiedMinions:
enemyDiedMinions:
og: 169,2;1152,1;248,2;246,2;251,1;557,2;1150,2;209,2;430,2;642,1;372,1;1010,2;371,1;701,2;
eg: 995,1;708,1;429,2;740,2;495,1;514,1;648,2;333,1;241,2;516,2;1218,1;188,2;749,2;
```
it will then calculate this board and prints the first 100 best boards (sorted from best to worst) and simulate
the whole turn of the best one.

if you add "test" to the first line:
```
#######################################################################test
start calculations, current time: 00:00:00:0000 V116.27 control 5000 face 15 twoturnsim 1000 ntss 6 16 160 playaround 50 80 ets 16 ets2 160 ents 16 secret
#######################################################################
...
```
you can input the index of the displayed boards to simulate the whole turn of this board (indexes are be displayed 
in the list of the first 100 best boards)