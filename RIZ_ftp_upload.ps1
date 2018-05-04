#
# Rizvi Hasan <rizvi.hasan@se.abb.com>
# 2018/05/04
# Powershell script
# Upload multiples files through ftp with Powershell
#

#Directory where to find files to upload
$Dir= '.\ToUpload\'

#Directory where to save uploaded files
$saveDir = 'c:\Temp\'

#ftp server params
$ftp = 'ftp://127.0.0.1:21/'

#Connect to ftp webclient
$webclient = New-Object System.Net.WebClient 

# $webclient.Credentials = New-Object System.Net.NetworkCredential($user,$pass)
$cred = Get-Credential
"Proceeding ..."
"User : " + $cred.UserName  

$webclient.Credentials = New-Object System.Net.NetworkCredential($cred.UserName, $cred.Password)  

#Initialize var for infinite loop
$i=0

# Exit(0);

#Infinite loop
while($i -eq 0){ 

    #Pause 1 seconde before continue
    Start-Sleep -sec 1

    #Search for files in directory
    foreach($item in (Get-ChildItem $Dir "*.zip"))
    {
        #Set default network status to 1
        $onNetwork = "1"

        
            #If upload fails, we set network status at 0
            try{

                $uri = New-Object System.Uri($ftp+$item.Name)

                "Uploading $item..."                
                $webclient.UploadFile($uri, $item.FullName)

            } catch [Exception] {
                
                $onNetwork = "0"
                write-host $_.Exception.Message;
            }

            #If upload succeeded, we do further actions
            if($onNetwork -eq "1"){
                "Moving $item..."
                Copy-Item -path $item.fullName -destination $saveDir$item 

                # "Deleting $item..."
                Remove-Item $item.fullName
            }


    }
}	