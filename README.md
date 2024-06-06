# TrackedServices

###### INSTALLATION PROJET .NET #######
#### Clone project
git clone https://github.com/ezekiela0701/TrackedServices.git

#### Creer branche develop
git checkout -b develop

#### aspirer code dans branche develop
git pull origin develop

#### Entrer dans dossier API
cd /Api

#### Restore  package .net
dotnet restore

#### Migration Base de données
dotnet ef migrations add yourMigrationName

#### Mise à jour du base de données
dotnet ef database update

