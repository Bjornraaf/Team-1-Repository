# Team-1-Repository

Kinderen voltooien uitdagingen op verschillende locaties tijdens een wandeling om cijfers te verdienen voor een cijferslot. De uitdagingen worden weergegeven op een kaart met pictogrammen en de behaalde cijfers worden zichtbaar op het scherm. Om het slot te openen zijn minstens twee verschillende uitdagingen vereist. Herhaling van uitdagingen is mogelijk om alle cijfers te verkrijgen.
<br>  
Een complete en uitgebreide beschrijving is [hier](https://github.com/Bjornraaf/Team-1-Repository/wiki) te vinden.

# Geproduceerde Game Onderdelen

Geef per teammember aan welke game onderdelen je hebt geproduceerd. Doe dit met behulp van omschrijvingen visual sheets en screenshots.
Maak ook een overzicht van alle onderdelen met een link naar de map waarin deze terug te vinden zijn.

Bjorn Ravensbergen:
  * GPS System[GPS System](https://github.com/Bjornraaf/Team-1-Repository/tree/develop/Assets/Scripts/GPSSystem)

Patryk Podworny:
  * blank
  * blank

Ties Postma:
  * blank
  * blank

## GPS System

De variabelen ```RealInit```, ```RealCurrentPosition``` en ```FakeCurrentPosition``` zijn allemaal Vector2 variabelen die de locatie van de speler op verschillende manieren opslaan. ```RealInit``` slaat de initiële GPS-coördinaten op van waar de speler zich bevond toen de app werd gestart. ```RealCurrentPosition``` slaat de huidige GPS-coördinaten van de speler op en ```FakeCurrentPosition``` bevat de coördinaten die gebruikt worden om de positie van de speler in de virtuele omgeving te bepalen.

De ```Scale``` variabele wordt gebruikt om de afstand tussen de werkelijke locatie van de speler en de locatie in de virtuele omgeving te verkleinen of vergroten.

Er zijn ook variabelen zoals ```isFakingLocation```, ```FailedText``` en ```PositionText``` die dienen om het testen van de app te ondersteunen en te rapporteren over de locatiegegevens.

In de ```Start()``` methode wordt de GPS-functionaliteit van het apparaat geactiveerd en wordt het kompas geactiveerd.

De ```UpdatePosition()``` methode bevat failsafes die ervoor zorgen dat de locatiegegevens correct worden weergegeven. Als de app de GPS-locatie van het apparaat gebruikt, controleert de methode of GPS is ingeschakeld en of de locatie wordt geïnitialiseerd. Als er geen locatie is, of als de initialisatie mislukt, wordt de juiste tekst in het ```FailedText``` object weergegeven. Als de GPS-locatie correct is geïnitialiseerd, wordt de huidige locatie van de speler bepaald en bijgehouden. Als ```isFakingLocation``` ```true``` is, worden de locatiegegevens nep gemaakt voor het testen.

De ```SetLocation()``` methode wordt gebruikt om de positie van de speler in de virtuele omgeving te bepalen. De GPS-coördinaten van de speler worden omgezet in Vector2 objecten, en vervolgens wordt de ```FakeCurrentPosition``` bepaald aan de hand van de initiële locatie en de huidige locatie van de speler, met behulp van de ```Scale``` variabele. Tot slot wordt de ```transform.position``` van het ```GameObject``` waarop het script is bevestigd, ingesteld op de virtuele locatie van de speler.

In de ```Update()``` methode wordt de ```UpdatePosition()``` methode opgeroepen om de locatiegegevens te actualiseren.
