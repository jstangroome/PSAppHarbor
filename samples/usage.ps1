# install PsGet
(new-object Net.WebClient).DownloadString("http://psget.net/GetPsGet.ps1") | iex

# install PSAppHarbor
Install-Module -ModuleUrl https://tc.readifycloud.com/guestAuth/repository/download/bt8/.lastSuccessful/PSAppHarbor.zip

# authenticate to AppHarbor
Connect-AppHarbor

# query list of applications
Get-AHApplication