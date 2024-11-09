# Ievads
Preču piegādes maršrutēšana 
## Problēmas nostādne
Loģistikas uzņēmumiem un preču piegādes pakalpojumu sniedzējiem efektīva maršrutēšana ir būtiska, lai samazinātu izdevumus, optimizētu piegādes laiku un uzlabotu klientu apmierinātību. Pārāk ilgi vai neefektīvi maršruti rada palielinātus degvielas izdevumus, resursu izšķērdēšanu un nepārskatāmību par piegāžu statusu. Optimizēta preču piegādes maršrutēšanas sistēma var palīdzēt uzņēmumam labāk izplānot piegādes maršrutus, pielāgojoties dažādiem klientu pieprasījumiem un piegādes apstākļiem.
### Lietotāju stāsti
| Nr.   | Lietotāju stāsts <lietotājs> vēlas <sasniegt mērķi>, jo <ieguvums>   | Prioritāte |
|--------------|----------------|--------------------|
| 1. | Administrators vēlas nodrošināt efektīvu maršrutu plānošanu, jo tas palīdz samazināt izmaksas un uzlabot piegādes kvalitāti | |
| 2. | Administrators vēlas nodrošināt kurjeru drošību uz ceļa, jo tas samazina negadījumu risku un palielina darbinieku apmierinātību | |
| 3. | Kurjers vēlas piekļūt ērtai navigācijas sistēmai ar maršrutiem, jo tas palīdz viņam vieglāk orientēties un izvairīties no kļūdām | |
| 4. | Kurjers vēlas, lai maršruts tiktu plānots, ņemot vērā laika logus, jo viņš varēs optimizēt savu laiku un piegādāt pasūtījumus ātrāk | |
| 5. | Klients vēlas izvēlēties vēlamo piegādes laiku, jo tas padara pakalpojumu ērtāku un pielāgojamāku viņa grafikam | |
| 6. | Klients vēlas saņemt pasūtījumu atrāk, jo tas uzlabo viņa apmierinātību un lojalitāti uzņēmumam | |
## Darba un novērtēšanas mērķis
### Mērķis
Izstrādāt algoritmisku risinājumu, kas optimizē preču piegādes maršrutus, ņemot vērā vairākus mainīgos, piemēram, piegādes punktu ģeogrāfisko atrašanās vietu, kurjeru daudzumu, transportlīdzekļu kravnesību un citu nepieciešamo loģistikas informāciju.
### Uzdevumi
* Maršruta plānošana: izstrādāt algoritmu, kas aprēķina optimālu piegādes maršrutu, minimizējot kopējo nobraukto attālumu.
* Preču piegādes optimizācija atkarības no preču un kurjera sakitu: nodrošināt algoritmu, kas piešķir atbilstošem kurjeram atbilstošu preču skaitu, kuras piegādes adreses atrodas tuvāk geografiski. 
* Piegādes grafika ievērošana: sistēmai jāspēj organizēt piegādes laikā un jāievero kurjera darba laiku.
### Izstrādes posmi
* Pētījuma un plānošanas posms: izpētīt piegādes maršrutēšanas algoritmus, lidzīgus risinājumus, izveidot arhitektūras plānu.
* Algoritma izstrāde: programmēt maršrutēšanas algoritmu un testēt uz nelieliem piegādes punktu skaitiem.
* Interfeisa izveide: izveidot lietotāja interfeisu piegādes punktu, preču, kurjera skaita ievādei un maršruta apskatei.
* Optimizācijas un testēšanas posms: veikt maršruta algoritma optimizāciju, veikt izsmeļošu testēšanu.
* Analīze un uzlabošana: analizēt lietošanas datus, veikt korekcijas, lai uzlabotu piegādes plānošanu.
# Līdzīgo risinājumu pārskats
| Risinājums   | Īss apraksts   | Svarīgākās iezīmes | Ierobežojumi |
|--------------|----------------|--------------------|--------------|
| Route4Me     |Maršrutu plānošanas platforma, kas automātiski ģenerē optimālus piegādes maršrutus dažādiem transportlīdzekļiem.|Viegls lietošanā, reāllaika maršrutu plānošana, integrācija ar dažādām ierīcēm (mobilās un tīmekļa lietotnes).|Nevar uztaisīt maršrūtu tikai 2 adresem. Skaitas maršruts tikai 1 kurjeram, nevar uzstadīt laiku katrai adresei.|
| Google OR-Tools  | Atvērtā koda optimizācijas rīks, ko nodrošina Google, piedāvā spēcīgas maršrutu plānošanas un optimizācijas algoritmus, piemēram, VRP un VRPTW.|Elastība un pielāgošana, spēcīgi optimizācijas algoritmi, piemērots plašam problēmu lokam (piegādes, resursu plānošana utt.).|Nepieciešamas programmēšanas zināšanas un integrācija ar citām sistēmām, ierobežota vizualizācija un lietotāju saskarne.|
|SpeedyRoute | Maršruta plānošanas tiešsaistes rīks, kas palīdz noteikt optimālo maršrutu vairākiem pieturas punktiem. Īpaši piemērots loģistikas uzņēmumiem un piegāžu plānošanai.|-Automātiska optimāla maršruta ģenerēšana vairākām pieturām.<br> -Atbalsts dažādiem transporta līdzekļiem.<br> -Iespēja lejupielādēt maršrutus dažādos formātos (CSV, PDF) |-Ierobežots bezmaksas versijā (ierobežots pieturvietu skaits).<br> -Nav pieejamas dažas uzlabotas funkcijas bezmaksas lietotājiem.<br> -Nevar dažiem kurjeram uzstadīt dažadas sākuma punktus.|
|RouteXL|Vietne, kas automātiski ģenerē ātrāko un īsāko maršrutu. Ir jānorāda sākuma un beigu punkts, pēc tam vienkārši jāpievieno pieturas, un algoritms izvēlēsies pašu maršrutu.|Var iestatīt nosacījumus maršrutam (transporta veids, ceļojumā pavadītais laiks, aptuvenais katrā punktā pavadītais laiks). Tas parāda arī aptuveno emitētās gāzes daudzumu| Interfeiss nav ļoti lietotājam draudzīgs, un adreses var atlasīt tikai manuāli (nemeklē meklēšanas joslā)|
|OptimoRoute|Mākoņrisinājums preču piegādes un servisa maršrutu optimizācijai ar reāllaika sekošanu un integrāciju.|Reāllaika sekošana, elastīgi maršrutu plāni, viegli lietojams interfeiss. Klientu paziņojumi|Katrs transportlīdzeklis var pārvadāt tikai noteiktu kravu|
# Tehniskais risinājums
## Prasības
## Algoritms
## Konceptu modelis
Piegādes kompānijai ir noliktavas kurās glābājās preces. Tās preces ir nepieciešams piegādāt klientiem  ko nodrošina kurjeri. Administrātors var saorganizēt kurjeru maršrutus vienai darba dienai. Administrātors var pārvaldīt noliktavas un pievienot sūtījumus. Kā arī saņemt informāciju par kurjeru noslodzi un vai ir nepieciešamība pievienot vel kādu kurjeru maiņai.

![Diagram](diagrams/KonceptuModelis.svg)

- Noliktavas – Savienotas ar administratoriem un sūtījumiem, tās nodrošina informāciju par pieejamiem produktiem.
- Administrators – Centrālais elements, kas pārvalda informāciju no noliktavām, sūtījumiem, kurjeriem un maršrutiem.
- Kurjeri – Saņem un piegādā sūtījumus, sadarbojas ar maršrutu plānošanu un administratoriem.
- Maršruti – Izstrādā optimālus piegādes ceļus, pamatojoties uz kurjeru un sūtījumu datiem.
- Sūtījumi – Savienoti ar noliktavām, adresēm un maršrutiem, tie atspoguļo piegādes pakalpojumus.
- Ceļu posmi – ietver sevī Maršruta Id, iepriekšeja sūtijuma vaikurjera sākuma punktu, gāla punktu posmam - nākama sūtijuma ID (adresi) un JSON formātā Starppunktus, kas ir lauzašanas punkti, lai kartē attēlotos korrekti maršruts.

## Tehnoloģiju steks
![Diagram](diagrams/TehnologijuSteks.svg)

## Programmatūras apraksts
# Novērtējums
## Novērtēšanas plāns
## Novērtēšanas rezultāti
# Secinājumi

