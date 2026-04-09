# GitHub Copilot Instructions

## Jazyk komunikace

- S uživatelem vždy komunikuj česky.
- Vysvětlení, návrhy a komentáře piš česky.
- Angličtinu používej jen pro názvy tříd, metod, souborů, knihoven, API a commit messages.

## Zásady projektu

- Používej pouze nejmodernější, podporovaný a produkčně vhodný kód.
- Nepoužívej deprecated, obsolete ani historická řešení.
- Nikdy nenavrhuj Xamarin ani zastaralé Android postupy.
- Dodržuj nejnovější stabilní standardy pro .NET 10, C#, .NET MAUI, Android, Bluetooth a MQTT.
- Preferuj jednoduché, profesionální a dobře udržovatelné řešení.

## Kontext projektu

Projekt BT2MQTT je Android-only aplikace v .NET 10 MAUI.

Účel:
- Bluetooth -> MQTT bridge
- MQTT -> Bluetooth bridge
- trvalé uložení nastavení
- automatický reconnect
- foreground/background stabilita
- reálné produkční použití

## Technologická pravidla

- Platforma: Android only
- Framework: .NET 10
- UI: .NET MAUI
- Jazyk: C#
- MQTT: MQTTnet
- Bluetooth: Plugin.BLE nebo novější aktivně udržovaná a jednoznačně lepší alternativa

## Styl změn

- Prováděj malé a bezpečné změny.
- Jasně uváděj, který soubor se mění.
- Zachovávej konzistenci projektu.
- Kód musí jít čistě sestavit.
- Preferuj oddělení UI, Bluetooth logiky, MQTT logiky a ukládání nastavení.
- Počítej s reconnectem a ztrátou spojení jako s běžným stavem.
- Nepředpokládej, že Bluetooth data vždy dorazí jako jedna kompletní zpráva.

## Co nedělat

- Nepřidávej zbytečné závislosti.
- Nenavrhuj rychlé hacky místo čistého řešení.
- Nepiš zbytečně dlouhé odpovědi.
- Nezaváděj zbytečnou architektonickou složitost.