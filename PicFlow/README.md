# Imageflow (Picflow)
Beispiel für eine Bildverarbeitung mit Microservices.

<img src="https://fpommerening.github.io/Remote/MicroserviceRabbitMQ/images/ImageProcessing.svg"/>

WebApp:
- Anfragen zur Authentifzierung versenden
- Authentifzierungsantworten empfangen und in AuthenticationRepository verarbeiten
- Verarbeitungsjob mit Folgeschritten erstellen und versenden

Authorization
- Anfragen zur Authentifzierung empfangen und Benutzerdaten gegen UserRepository prüfen
- Authentifzierungsantworten mit Prüfergebnis versenden

Uploader
- Versandjobs an externe Anwendung empfangen und per HTTP übertragen

Image Prozessor
- Verarbeitungsjob empfangen und an Grafikverarbeitung übergeben
- Folgejobs an Persitor / Uploader versenden

Image Persitor
- Grafiken für den Benutzer speichern


Build: build.ps

Starten per Compose: /picflow/docker-compose.yml