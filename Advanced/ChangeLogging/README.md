# Change Logging

In diesem Projekt wird das Logging-System ersetzt. Dabei kommt die Komponente Log4Net zum Einsatz.

Die Fehlermeldung enthalten teilweise per JSON serialisierte Objekte. Diese können bei der Verwendung des String-Formatter zu Fehlern führen. Die Methode SafeFormat fängt entsprechende Zustände. 