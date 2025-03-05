# 7-Segment-Anzeige in Unity

Dieses Unity-Projekt implementiert eine **7-Segment-Anzeige**, die Zahlen von `0` bis `9` darstellt.

## 🚀 Funktionen
- **Rotationsbasierte Deaktivierung**: Anstatt Segmente zu deaktivieren, drehen sich inaktive Segmente aus der Sicht.
- **Steuerung per Tastatur**:
  - `Pfeil hoch`: Erhöht die Zahl um `+1` (Zyklus von 0-9).
  - `Pfeil runter`: Verringert die Zahl um `-1` (Zyklus von 9-0).
  - `0-9` (Zahlentasten): Direktes Setzen der entsprechenden Zahl.

## 🛠️ Installation & Verwendung
1. **Importiere das Skript** `SevenSegmentDisplay.cs` in dein Unity-Projekt.
2. **Erstelle ein leeres GameObject** und benenne es `SevenSegmentDisplay`.
3. **Füge 7 Child-Objekte** (die Balken des 7-Segment-Displays) als separate GameObjects hinzu.
4. **Benenne die Segmente exakt** wie folgt:
   - `A`
   - `B`
   - `C`
   - `D`
   - `E`
   - `F`
   - `G`
5. **Wende das Skript auf das `SevenSegmentDisplay`-Objekt an**.
6. **Starte die Szene** und steuere die Anzeige mit der Tastatur!

## 🎛️ Technische Details
- Horizontale Segmente drehen sich im inaktiven Zustand nach `(0, -90, 0)`.
- Vertikale Segmente drehen sich nach `(-90, 0, 90)`.
- Die `segmentStates`-Matrix definiert, welche Segmente für jede Zahl aktiviert sind.

## 📌 To-Do / Erweiterungen
- Animierte Übergänge beim Wechseln der Zahlen.
- Unterstützung für mehrere Ziffern.

## 📹Demonstration

https://github.com/user-attachments/assets/7e5126a5-3794-48b0-a69e-7ee7a99f9f20

