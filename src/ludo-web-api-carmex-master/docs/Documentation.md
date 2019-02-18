Ludo user stories

1. Som spelare slår jag med tärningar och får gå antal prickar på den med min pjäs
2. Som spelare kan man gå med i ett spel som har mindre än 4 spelare
3. Som spelare ska jag flytta pjäsen ett varv innan den kommer i mål.
4. Som spelare har jag fyra pjäser att gå i mål med
5. Som spelare vinner jag om jag har gått i mål med mina 4 pjäser
6. Som spelar får jag slå igen om jag slagit en 6:a med tärningen


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

**/ludo** *(skapa ett nytt spel)*

**/ludo{gameId}/players** *(Lägg till en ny spelare till spelet)*

**PUT**

**/ludo[{gameId}** *(Ändra en placerning på en pjäs)*

**/ludo{gameId}/players/{playersId}** *(Ändra namn elLer färg på spelaren)*

**DELETE**

**/ludo{gameId}** *(Ta bort ett spel)*

**/ludo{gameId}/Players/{playersId}** *(Ta bort spelaren)*


![API beskrivning](https://github.com/PGBFDH18/ludo-web-api-carmex/blob/master/docs/API.PNG)


Vi har utgått från Stephan Kaas Johansen GameEnginge, samt API beskrvining. För att skriva reseterande delar av API:et har vi tagit hjälp av sidor via google så som stackoverflow, microsoft docs mfl. 

