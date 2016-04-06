param($websiteName, $packOutput, $hostNameIndex = 1)
Stop-AzureWebsite -Name $websiteName
$website = Get-AzureWebsite -Name $websiteName

# get the scm url to use with MSDeploy.
# By default this will be the second in the array. Changes when you add custom domain names. 
# Here I have the default and 2 custom so scm is in 4th position ie. index: 3
$msdeployurl = $website.EnabledHostNames[$hostNameIndex]

$publishProperties = @{'WebPublishMethod'='MSDeploy';
                    'MSDeployServiceUrl'=$msdeployurl;
                    'DeployIisAppPath'=$website.Name;
                    'Username'=$website.PublishingUsername;
                    'Password'=$website.PublishingPassword}


$publishScript = "${env:ProgramFiles(x86)}\Microsoft Visual Studio 14.0\Common7\IDE\Extensions\Microsoft\Web Tools\Publish\Scripts\default-publish.ps1"


. $publishScript -publishProperties $publishProperties  -packOutput $packOutput
Start-AzureWebsite -Name $websiteName