# InfrastructurePlatform
Aplikacija simulira rad infrastrukturinih platformi. 

Postoje dva osnovna taba Systems i Platforms.

Platforms – U ovom tabu mozemo vrsiti manipulaciju nad podacima sa platformama. Platforma u sistemu predstavlja neki servis koji je moguce iskoristiti, kao npr: Docker, Postrgree, Redis ili slicno pri kreiranju Sistema.

Systems - Predstavlja nase sisteme ili aplikacije koje razvijamo na sonovu platforma (services) koje smo ranije dodali. Ukoliko zelimo da dodamo nove platforme, postoji mogucnost uz pomocu opcije koja sadrzi system.

Soultion se sastoji iz 4 projekta:

Domain: nalaze se entiteti nad kojima se povezujemo sa bazom podataka
Persistence: repozitorijumi koji koriste konekciju sa bazom i manipulaziju nad podacima
Application: biznis logika
WebPlatform: MVC projekat

Instalirati

Redis: [https://neo4j.com/download/](https://github.com/MicrosoftArchive/redis/releases/download/win-3.2.100/Redis-x64-3.2.100.msi)
Visual Studio (2019 ili 2022)
