# Ievads
## Problēmas nostādne
Loģistikas uzņēmumiem un preču piegādes pakalpojumu sniedzējiem efektīva maršrutēšana ir būtiska, lai samazinātu izdevumus, optimizētu piegādes laiku un uzlabotu klientu apmierinātību. Pārāk ilgi vai neefektīvi maršruti rada palielinātus degvielas izdevumus, resursu izšķērdēšanu un nepārskatāmību par piegāžu statusu. Optimizēta preču piegādes maršrutēšanas sistēma var palīdzēt uzņēmumam labāk izplānot piegādes maršrutus, pielāgojoties dažādiem klientu pieprasījumiem un piegādes apstākļiem.
### Lietotāju stāsti
| Nr.   | Lietotāju stāsts <lietotājs> vēlas <sasniegt mērķi>, jo <ieguvums>   | Prioritāte |
|--------------|----------------|--------------------|
| 1. | Administrators vēlas nodrošināt efektīvu maršrutu plānošanu, jo tas palīdz samazināt izmaksas un uzlabot piegādes kvalitāti | 2 |
| 2. | Administrators vēlas nodrošināt kurjeru drošību uz ceļa, jo tas samazina negadījumu risku un palielina darbinieku apmierinātību | 5 |
| 3. | Kurjers vēlas piekļūt ērtai navigācijas sistēmai ar maršrutiem, jo tas palīdz viņam vieglāk orientēties un izvairīties no kļūdām | 4 |
| 4. | Kurjers vēlas, lai maršruts tiktu plānots, ņemot vērā laika logus, jo viņš varēs optimizēt savu laiku un piegādāt pasūtījumus ātrāk | 1 |
| 5. | Klients vēlas izvēlēties vēlamo piegādes laiku, jo tas padara pakalpojumu ērtāku un pielāgojamāku viņa grafikam | 3 |

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
### Funkcionālās prasības
- Kurjeru pievienošana: Sistēmai jāļauj administratoram pievienot un pārvaldīt kurjerus, tostarp viņu pieejamību un darba stundas.
- Noliktāvu pārvaldība: Administratoram jābūt iespējai pievienot un pārvaldīt informāciju par noliktavām, tostarp to atrašanās vietas un pieejamo inventāru.
- Pasūtījumu pievienošana: Sistēmai jānodrošina saskarne pasūtījumu pievienošanai, tostarp piegādes detaļas un klientu ģeogrāfiskā atrašanās vieta.
- Maršrutu ģenerēšana: Sistēmai jāspēj automātiski ģenerēt optimālus piegādes maršrutus, pamatojoties uz aktuālo informāciju par kurjeriem, noliktavām un pasūtījumiem.
### Drošības prasības
- Datu šifrēšana: Jutīgu datu, piemēram, kurjeru un klientu personas informācijas, paroles šifrēšana.
- Auditēšana un žurnāli: Lietotāju darbību audita un žurnālu uzturēšana un glabāšana, lai nodrošinātu darbību izsekojamību un problēmu risināšanu.
### Veiktspējas prasības
- Sistēmas atsaucība: Sistēmai jāreaģē uz lietotāju pieprasījumiem ātri un jāģenerē maršruti reāllaikā.
- Mērogojamība: Sistēmai jābūt pielāgojamai, lai spētu apstrādāt lielāku pasūtījumu, kurjeru un noliktavu skaitu bez veiktspējas zuduma.
## Algoritms
### Apraksts
Šis algoritms ir izstrādāts, lai optimizētu piegādes operācijas vairākiem noliktavām, piešķirot piegādes maršrutus kurjeriem, ievērojot konkrētus laika ierobežojumus: Pasutijuma laika logi un kurjeru darba laiks. Algoritms izmanto Openrouteservice API, lai aprēķinātu maršrutus. Šo algoritmu var izmantot loģistikas un piegādes pārvaldības sistēmās.

Algoritms darbojas šādi: tiek inicializētas noliktavu koordinātas un piegādes punktu atrašanās vietas katrai noliktavai. Tiek noteikts kurjeru darba dienas sākuma un beigu laiks. Izstrādātais algoritms piegāžu adrešu sadalei ir veidots tā, lai maksimāli efektīvi izmantotu katra kurjera kapacitāti. Katra noliktava tiek apstrādāta neatkarīgi – sākot ar pirmo noliktavu, piegādes adreses tiek piešķirtas kurjeriem, maksimāli noslogojot katru no tiem. Piegādes adreses tiek piešķirtas secīgi – vispirms vienam kurjeram līdz viņa pieļaujamā noslodze ir sasniegta, pēc tam piešķiršana turpinās nākamajam kurjeram.

Ja visi pasūtījumi tiek veiksmīgi iekļauti maršrutā, programma izvada maršrutus un tiem atbilstoši piešķirtos kurjerus, nodrošinot, ka katrs pasūtījums tiek piegādāts savlaicīgi. Tomēr, ja neizdodas iekļaut visus pasūtījumus maršrutā, piemēram, laika ierobežojumu dēļ, programma saglabā jau izveidotos maršrutus un norāda pasūtījumus, kuri palikuši neiekļauti. Galvenais mērķis ir piešķirt uzdevumus kurjeriem tādā veidā, lai pēc iespējas vairāk piegāžu tiktu veikti laicīgi, minimizējot attālumu un laiku.

Algoritmi un pieejas, ko izmanto algoritms:
- Ceļojošā pārdevēja problēma (Traveling Salesman Problem): Algoritms identificē tuvāko punktu, lai minimizētu attālumu un ceļošanas laiku.
- Greedy algoritms: Tiek izvēlēts tuvākais pieejamais punkts, kas atbilst laika ierobežojumiem.
- Grafu teorija un maršrutu optimizācija: Izmantojot Openrouteservice API, tiek aprēķināti ceļa garumi un laiki starp piegādes punktiem.
- Laika ierobežojuma pārbaude (Time Constraint Validation): Tiek nodrošināts, ka kurjers var veikt piegādi un atgriezties noliktavā pirms darba dienas beigām.
### Pseidokods
```
BEGIN PROGRAM
  Inicializēt noliktavu atrašanās vietas
  Inicializēt piegādes punktus katrai noliktavai
  Iestatīt darba laiku

  FOR noliktavai DO
    Inicializēt nepiegādāto punkti sarakstu
    Inicializēt kurjera indeksu
    WHILE ir nepiegādātie punkti DO
      IF Piešķirt maršruts kurjeram:
        Atrast tuvāko piegādes punktu, kuru var piegādāt, ievērojot laika ierobežojumu (logus)
        Aprēķināt maršrutu no pašreizējās atrašanās vietas līdz piegādes punktam
          IF kurjers var pabeigt piegādes maršrutu un atgriezties noliktavā darba laika ietvaros THEN
            Piešķirt piegādes punktu kurjeram
            Atjaunot kurjera pašreizējo atrašanās vietu un laiku
          ELSE
            Aprēķināt maršrutu atpakaļ uz noliktavu
      ELSE
        BREAK (ne visas pakas var piegādāt)
    END WHILE
  END FOR
        
END PROGRAM
```

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
Preču piegādes maršrutēšanas procesu automatizācija un optimizācija, samazinot piegādes laiku un izmaksas.
### Sistēmas galvenās funkcijas:
- Kurjeru pārvaldība: sistēma ļauj administratoriem pievienot, rediģēt un dzēst kurjeru informāciju.
- Noliktavas pārvaldība: administratori var pievienot un pārvaldīt noliktavas informāciju, tostarp to atrašanās vietu un pieejamos krājumus.
- Pasūtījumu pievienošana: Sistēma nodrošina iespēju pievienot pasūtījumus, norādot klienta atrašanās vietu un nepieciešamos piegādes laika logus.
- Maršruta izveide: Programmatūra automātiski ģenerē un attēlo optimālus piegādes maršrutus un optimālo kurjeru skaitu, pamatojoties uz noliktavu, piegādes adrešu atrašanās vietām un klienta izvēlētiem laika logiem. Maršruta kartes attēlošanai tiek izmantots OpenRouteService API, kas atspoguļojas pirmajā sistēmas lapā
- Monitorings un analītika: Sistēma nodrošina rīkus pasūtījumu izpildes uzraudzībai un maršrutu un kurjeru darba efektivitātes analīzei, kā arī darbību sistēmā uzraudzība pateicoties pieslegtājām Grafana, kur varam uzraudzīt mūsu mājāslapu un sekot visam procesiem, sistemās noslogojumam, kļūdam un aizdomīgam darbībam reallaikā.
# Novērtējums
## Novērtēšanas plāns
### Eksperimenta mērķis
Novērtēt skaitļošanas laiku atkarībā no pasūtījumu grūtības un kurjeru skaita.

### Ieejas parametri
- Preču daudzums (PD)
- Vidējais pasūtījumu attālums (VPA)
- Vidējais laika loga intervāls (VLLI)

### Novērtēšanas mēri
- Skaitļošanas laiks (W)
- Kurjeru skaits (N)

### Eksperimentu plāns
| Nr. | PD    | VPA (km) | VLLI(h)  | W (s) | N  |
|-----|-------|----------|-------|--------|----|
| 1   | 10    | 2        | 0.5   | 6.666  | 3
| 2   | 20    | 2        | 0.5   | 23.687 | 4
| 3   | 10    | 5        | 0.5   | 8.02   | 4
| 4   | 20    | 5        | 0.5   | 23.53  | 6
| 5   | 10    | 7        | 1     | 5.844  | 3
| 6   | 20    | 7        | 1     | 21.921 | 4
| 7   | 10    | 2        | 1     | 6,621  | 2
| 8   | 20    | 2        | 1     | 24.281 | 2
| 9   | 10    | 5        | 1     | 6.21   | 2
| 10  | 20    | 5        | 1     | 21.824 | 4
| 11  | 10    | 7        | 2     | 5.571  | 2
| 12  | 20    | 7        | 2     | 20.621 | 2 
| 13  | 10    | 2        | 2     | 5.977  | 2
| 14  | 20    | 2        | 2     | 22.904 | 2
| 15  | 10    | 5        | 2     | 6.098  | 2
| 16  | 20    | 5        | 2     | 21.403 | 2 

## Novērtēšanas rezultāti
Pēc algoritma darbošanas testiem un rezultātu fiksēšanās, tiek iegūti dati, kuri attēloti tabulā "Eksperimentu plāns". Ar šadiem rezultātiem iziet:
- Pie lielāka preču daudzuma (PD) un vidējā pasūtījumu attāluma (VPA) novērojams ilgāks skaitļošanas laiks (W).
- Mazāks vidējais laika logs (VLLI) arī ievērojami palielina skaitļošanas laiku.
- Lielāks kurjeru skaits samazina skaitļošanas laiku, jo sistēma efektīvāk sadala maršrutus un pasūtījumus.
- Tomēr pie zemāka PD un VPA šī ietekme ir mazāk izteikta.

Korelācija starp parametriem:
- VPA un VLLI būtiski ietekmē gan W, gan nepieciešamo kurjeru skaitu (N).
- Pie lielākiem attālumiem un mazākiem laika logiem kurjeru skaits palielinās.
# Secinājumi
Izstrādātais algoritms ļauj ievērojami uzlabot preču piegādes maršrutēšanu, ņemot vērā svarīgākos loģistikas aspektus, piemēram, piegādes punktu ģeogrāfisko atrašanās vietu, kurjeru skaitu un pasūtījumu piegādes laika logus. Algoritms palīdz samazināt degvielas patēriņu, optimizēt piegādes laiku un nodrošināt augstu klientu apmierinātību, pielāgojoties piegādes apstākļiem.

Algoritms izmanto OpenRouteService API, kas ļauj aprēķināt ceļa garumus un laikus starp piegādes punktiem. Tas ļauj plānot maršrutus ar augstu precizitāti un pielāgot tos atbilstoši uzņēmuma vajadzībām.

Algoritmam piemīt ierobežojumi. Tas darbojas, maksimāli noslogojot kurjerus secīgi – sākot ar pirmo un turpinot ar nākamo, līdz visi pasūtījumi ir sadalīti. Šāda pieeja rada nevienmērīgu darba slodzes sadalījumu. Kā arī, eksistē citi trūkumi, no kuriem mēs izvairījāmies, uzstādot nelielu aizkavēšanos pieprasījumiem uz API, jo bezmaksas versijā tiek atļauts neliels pieprasījumu skaits.

Savukārt, ņemot vērā visus ierobežojumus un sistēmas izveidošanu maksimāli izmantojot pieejamus resursus, sistēma ir visefektīvākā, ja pasūtījumu sarežģītība ir zema (mazāki PD un VPA) un ja ir plašāki laika logi (VLLI). Šādos gadījumos sistēma ģenerē risinājumus ātrāk un prasa mazāk kurjeru. Turklāt, palielinoties pasūtījumu skaitam un attālumiem, sistēma pieprasa vairāk resursu (laika un kurjeru) optimālu maršrutu ģenerēšanai. Tas norāda uz nepieciešamību uzlabot algoritma efektivitāti vai izmantot papildu resursus, ja pieprasījums palielinās, kas jau neiekļaujas mūsu resursos. Testētā parametru diapazona ietvaros sistēma spēj pielāgoties dažādiem scenārijiem, taču efektivitāti būtiski ietekmē pieejamo kurjeru skaits. Sistēma darbojas optimāli, ja kurjeru skaits ir pietiekams attiecīgajam pasūtījumu apjomam.

### Ieteikumi turpmākajam darbam
Turpmākajā izstrādē būtu ieteicams ieviest iespēju dinamiski mainīt maršrutus, reaģējot uz ceļu apstākļiem vai izmaiņām piegādes laika logu prasībās. Tāpat varētu tikt izstrādāta integrācija ar reāllaika datiem par satiksmes apstākļiem, kas vēl vairāk uzlabotu maršruta precizitāti. Piemēram, integrēt uzģenerēto maršrutu (piegādes punktus) atsūtīšanu uz Waze vai Google Maps aplikācijām, kas automātiski vēl optimizēs maršrutus.


