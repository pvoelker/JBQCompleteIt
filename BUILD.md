# Updating Workloads

Always make sure to update the dotnet workloads:

> dotnet workload update

# Updating Version

- Increment 'ApplicationVersion'
- Update 'AssemblyVersion'
- Update 'FileVersion'
- Update 'ApplicationDisplayVersion'
- In 'Package.appxmanifest' for Windows platform, update 'Version' in 'Identity'
- Document new version in 'CHANGELOG.md'

# Updating Copyright

- Update copyright in JBQCompleteItApp project file
- Update copyright information in 'Info.plist' for MacCatalyst platform

# Building

## Windows

- The signing certificate needs to be added to the Certificate Manager ('certmgr')
- The certificate thumbnail needs to be known
- In the JBQCompleteItApp project file, 'PackageCertificateThumbprint' may need to be updated to the current thumbnail
- Make sure that 'Package.appxmanifest' is updated with the correct version

### 64-bit Windows
> dotnet publish -f net7.0-windows10.0.19041.0 -c Release /p:RuntimeIdentifierOverride=win10-x64

## Android

- The jbqquizme.keystore needs to be copied to the JBQQuizMeApp project directory
- Make sure you know the password to the keystore file and will be referenced as '[kspassword]'

> dotnet publish -f:net7.0-android -c:Release /p:AndroidSigningKeyPass=[kspassword] /p:AndroidSigningStorePass=[kspassword]

## MacOS (Catalyst)

Reference: https://learn.microsoft.com/en-us/dotnet/maui/mac-catalyst/deployment/publish-outside-app-store

> dotnet publish -f net7.0-maccatalyst -c Release

You may need to enter the admin password for the build machine serveral times.

Submit package for notarization. Use an app-specific password generated at appleid.apple.com:

> xcrun notarytool submit {my_package_filename} --wait --apple-id {my_apple_id} --password {my_app_specific_password} --team-id {my_team_id}

'Staple' the return to the package:

> xcrun stapler staple {filename}.pkg

## iOS

### Setup
- An app must be created on 'App Store Connect' with the bundle ID set to ApplicationId
- In XCode go to Settings.  Select Accounts and add your 'Apple ID' account
- Make sure to Download Manual Profiles to make sure the latest profiles are on the local machine

### Steps
- This needs to be run on a MacOS system with Visual Studio for Mac installed
- In the JBQCompleteItApp project file, make sure that '<CodesignKey>' is set to the distribution certificate in Keychain Access on the Mac build host
- In the JBQCompleteItApp project file, make sure that '<CodesignProvision>' is set to the name of the codesign provision in the Apple Developer portal

> dotnet publish -f net7.0-ios -c Release

- In Visual Studio for Mac:
- Right click on 'JBQCompleteItApp' and select 'View Archives'
- The build should be listed
- Right click build and select 'Sign and Distribute'
- Select 'App Store' as distribution channel and proceed