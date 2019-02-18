**Beskrivning av API**

**HTTP**

**/ludo**
**/ludo{gameid}**
**/ludo/{gameid}/players**
**/ludo/{gameId}/players/{playerid}**

**GET**
**/ludo** *(Lista av spelen)*

**/ludo{gameId}** *(Info om specifikt spel)*

**/ludo/{gameId}/players** *(lista med alla spelare i specifikt spel)*

**/ludo/{gameId}/players/{playersId}** *(Detaljer om spelaren)*

**POST**
**/ludo** *(kapa ett nytt spel)*

**/ludo{gameId}/players** *(Lägg till en ny spelare till spelet)*

**PUT**
**/ludo[{gameId}** *(Ändra en placerning på en pjäs)*

**/ludo{gameId}/players/{playersId}** *(Ändra namn elLer färg på spelaren)*

**DELETE**
**/ludo{gameId}** *(Ta bort ett spel)*

**/ludo{gameId}/Players/{playersId}** *(Ta bort spelaren)*
