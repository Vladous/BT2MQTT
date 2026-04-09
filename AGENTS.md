# AGENTS.md

## Účel

Tento soubor definuje trvalá pravidla vývoje pro celý projekt BT2MQTT.
Všichni AI asistenti, generátory kódu a automatizační nástroje pracující v tomto repozitáři musí tato pravidla dlouhodobě a konzistentně dodržovat.

---

## Jazyk komunikace

- Veškerá komunikace s uživatelem musí probíhat výhradně česky.
- Vysvětlení, komentáře, návrhy a pracovní komunikace musí být psány česky.
- Angličtina se smí používat pouze tam, kde je to technicky nutné, například:
  - názvy tříd
  - názvy metod
  - názvy souborů
  - názvy knihoven
  - názvy API
  - názvy proměnných
  - commit messages
  - README a další veřejná technická dokumentace, pokud to dává smysl
- Nepřepínej komunikaci do angličtiny bez výslovného požadavku uživatele.

---

## Základní pravidla

- Vždy používej pouze nejmodernější, podporovaný a produkčně vhodný kód.
- Vždy preferuj profesionální, čisté, udržovatelné a dobře strukturované řešení.
- Vždy dodržuj aktuální best practices a nejnovější stabilní standardy pro .NET, C#, .NET MAUI, Android, Bluetooth a MQTT.
- Nikdy nepoužívej deprecated, obsolete, legacy nebo jinak zastaralé API, knihovny, návrhové vzory nebo platformní postupy.
- Nikdy nenavrhuj historická kompatibilní řešení, pokud to uživatel výslovně nepožaduje.
- Nikdy nenavrhuj Xamarin, staré Android API ani zastaralé přístupy.
- Vždy preferuj oficiálně podporované řešení před workaroundy.
- Kód musí být jednoduchý, praktický a vhodný pro reálné nasazení.

---

## Rozsah projektu

BT2MQTT je Android-only aplikace v .NET 10 MAUI, která slouží jako most mezi Bluetooth zařízeními a MQTT.

Hlavní cíle projektu:
- spolehlivá Bluetooth komunikace
- MQTT publish a subscribe
- trvalé uložení nastavení
- automatický reconnect
- stabilní běh na popředí i na pozadí
- architektura vhodná pro reálný provoz

---

## Technologické požadavky

- Cílová platforma: pouze Android
- Framework: .NET 10
- UI framework: .NET MAUI
- Jazyk: C#
- MQTT knihovna: MQTTnet
- Bluetooth knihovna: Plugin.BLE nebo novější aktivně udržovaná alternativa, pokud bude jednoznačně lepší a kompatibilní
- Používej pouze aktivně udržované závislosti

---

## Pravidla pro styl kódu

- Piš jasný, čitelný a explicitní C# kód.
- Preferuj menší třídy s jednou odpovědností.
- Preferuj async/await pro asynchronní operace.
- Používej silné typování.
- Vyhýbej se zbytečně chytrým abstrakcím.
- Nevytvářej mrtvý kód, výplňové stuby, falešné implementace ani placeholdery, pokud to uživatel výslovně nechce.
- Udržuj názvy konzistentní a profesionální.
- Preferuj composition před zbytečnou dědičností.
- Identifikátory, názvy souborů, commit messages a technické komentáře piš anglicky.
- Komunikaci s uživatelem piš česky.

---

## Architektonická pravidla

- Udržuj oddělenou UI vrstvu, servisní vrstvu, Bluetooth logiku, MQTT logiku a správu nastavení.
- Nemíchej transportní logiku přímo do UI, pokud nejde o dočasný prototyp.
- Preferuj samostatné služby pro:
  - Bluetooth
  - MQTT
  - ukládání nastavení
  - koordinaci bridge logiky
- Navrhuj řešení od začátku s ohledem na reconnect a obnovu po chybě.
- Ztrátu spojení považuj za běžný runtime stav, ne za výjimku z normálu.

---

## Pravidla pro Bluetooth

- Preferuj stabilní a moderní přístup k Bluetooth komunikaci.
- Vyhýbej se obsolete API a starým platformním předpokladům.
- Vždy zohledni aktuální požadavky Androidu na oprávnění.
- Bluetooth komunikace musí počítat s reconnectem a fragmentací dat.
- Nikdy nepředpokládej, že příchozí data vždy dorazí jako jedna kompletní zpráva.

---

## Pravidla pro MQTT

- Používej MQTTnet čistým a moderním způsobem.
- Odděluj logiku připojení k brokeru od UI.
- Vždy navrhuj řešení s podporou reconnectu.
- Topics musí být explicitní a konfigurovatelné.
- Nehardcoduj broker nastavení, pokud to uživatel výslovně nechce pro rychlý prototyp.

---

## Pravidla pro nastavení aplikace

- Nastavení uživatele ukládej trvale a spolehlivě.
- Nikdy nenavrhuj řešení, které vyžaduje opakované ruční nastavování po každém restartu.
- Nastavení navrhuj pro praktické dlouhodobé používání.
- Citlivé údaje ukládej odpovídajícím způsobem.

---

## Pravidla pro Android

- Respektuj aktuální pravidla Androidu pro oprávnění a běh na pozadí.
- Pokud je potřeba běh na pozadí, preferuj podporovaný foreground service přístup.
- Nespoléhej na staré chování Androidu, které už moderní verze blokují.
- Funkčnost ověřuj na reálném zařízení, ne pouze v emulátoru.

---

## Pravidla kvality

- Kód musí jít čistě sestavit.
- Varování minimalizuj na rozumné minimum.
- Opravuj příčiny problémů, ne jen jejich projevy.
- Preferuj robustní řešení před rychlými hacky.
- Udržuj projekt připravený na další rozšíření.

---

## Očekávání od AI asistentů

Při generování kódu nebo návrhů změn:
- poskytuj produkčně použitelný kód
- používej pouze aktuální API
- vyhýbej se obsolete metodám
- zachovávej konzistenci projektu
- vysvětluj jen to, co je nutné
- preferuj malé, bezpečné a přesné změny
- při úpravě souborů vždy jasně uváděj, který soubor se mění
- nepiš zbytečně dlouhé odpovědi, pokud to není nezbytné
- postupuj po malých krocích

---

## Zakázané směry

- Nepoužívej deprecated frameworky.
- Nepřidávej zbytečné závislosti.
- Nenavrhuj historická řešení jen proto, že kdysi fungovala.
- Negeneruj experimentální kód bez jasného označení.
- Nepřekomplikovávej jednoduché funkce.
- Nenavrhuj řešení, která zhoršují údržbu projektu.

---

## Priorita rozhodování

Pořadí priorit:
1. spolehlivost
2. udržovatelnost
3. srozumitelnost
4. moderní standardy
5. výkon
6. pohodlí

---

## Výchozí rozhodovací pravidlo

Pokud existuje více správných řešení, preferuj to, které je:
- moderní
- podporované
- udržovatelné
- explicitní
- bezpečné pro produkční použití
