; ZipSolution Inno Setup script file
;
; Review steps for translation adding:
; 1. Create installer with "ShowUndisplayableLanguages" turned on
; 2. Verify custom messages
;
; Release:
; 1. Turn off "ShowUndisplayableLanguages"
; 2. Increment version 5.9 on new via Edit\Replace All...
; 3. Compile
[Setup]
AppName=ZipSolution
AppVerName=ZipSolution 6.0
AppPublisher=HDE
AppPublisherURL=http://www.codeplex.com/ZipSolution
AppSupportURL=http://www.codeplex.com/ZipSolution
AppUpdatesURL=http://www.codeplex.com/ZipSolution
DefaultDirName={pf}\ZipSolution-6.0
DefaultGroupName={cm:Development}\ZipSolution 6.0
AllowNoIcons=yes
OutputDir=Output
OutputBaseFilename=ZipSolution-6.0
Compression=lzma
SolidCompression=yes
PrivilegesRequired=none
UsePreviousAppDir=no
UsePreviousGroup=no
; ShowUndisplayableLanguages=Yes

[Code]
var
	dotnetRedistPath: string;
	downloadNeeded: boolean;
	dotNetNeeded: boolean;
	memoDependenciesNeeded: string;
	Version: TWindowsVersion;
	msiNeeded: boolean;

const
  DOT_NET_4_URL = 'http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe';
  MSI_URL = 'http://support.microsoft.com/kb/942288/en-us';


function InitializeSetup(): Boolean;
var
  msiDll: string;
  hiMsiVersion, lowMsiVersion: cardinal;
  ErrorCode: integer;
begin
	Result := true;
	GetWindowsVersionEx(Version);
	
	//*********************************************************************************
	// Checking MSI
	//*********************************************************************************
	msiDll := ExpandConstant('{win}') + '\System32\msi.dll';
	GetVersionNumbers(msiDll, hiMsiVersion, lowMsiVersion);

  if (hiMsiVersion < 196609) then
  begin
    if (MsgBox(ExpandConstant('{cm:PleaseInstallMsi}'), mbInformation, MB_YESNO) = IDYES) then
    begin
      ShellExec('', MSI_URL, '', '', SW_SHOW, ewNoWait, ErrorCode)
    end;

    if (MsgBox(ExpandConstant('{cm:AlsoPleaseInstallDotNet4}'), mbInformation, MB_YESNO) = IDYES) then
    begin
      ShellExec('', DOT_NET_4_URL, '', '', SW_SHOW, ewNoWait, ErrorCode)
    end;

    Result := false;
    Exit;
  end;

	//*********************************************************************************
	// Checking presence of .NET 4
	//*********************************************************************************
  if	(not RegKeyExists(HKLM, 'Software\Microsoft\.NETFramework\policy\v4.0')) then
  begin
    if (MsgBox(ExpandConstant('{cm:PleaseInstallDotNet4}'), mbInformation, MB_YESNO) = IDYES) then
    begin
      ShellExec('', DOT_NET_4_URL, '', '', SW_SHOW, ewNoWait, ErrorCode)
    end;

    Result := false;
    Exit;
  end;

end;

[Languages]
Name: "en"; MessagesFile: "ZipSolution-Default.isl"
Name: "ru"; MessagesFile: "ZipSolution-Russian.isl"
Name: "de"; MessagesFile: "ZipSolution-German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[Files]
Source: "..\Output\ZipSolution.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Output\Docs\*"; DestDir: "{app}\Docs"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\Output\locals\*"; DestDir: "{app}\locals"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\Output\ZipSolution.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Output\ZipSolution.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Output\HDE.Platform.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Output\ZipSolution.Console.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Output\ZipSolution.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Output\7z.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Output\SevenZipSharp.dll"; DestDir: "{app}"; Flags: ignoreversion

[INI]
Filename: "{app}\ZipSolution.url"; Section: "InternetShortcut"; Key: "URL"; String: "http://www.codeplex.com/ZipSolution"

[Icons]
Name: "{group}\ZipSolution"; Filename: "{app}\ZipSolution.exe"

; Placing this files far far away from user
Name: "{group}\{cm:Other}\{cm:ProgramOnTheWeb,ZipSolution}"; Filename: "{app}\ZipSolution.url"
Name: "{group}\{cm:Other}\{cm:UninstallProgram,ZipSolution}"; Filename: "{uninstallexe}"
Name: "{group}\{cm:Other}\{cm:Documentation}"; Filename: "{app}\Docs\Documentation.doc"
Name: "{group}\{cm:Other}\{cm:Changes}"; Filename: "{app}\Docs\Changes.txt"

Name: "{userdesktop}\ZipSolution 6.0"; Filename: "{app}\ZipSolution.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\ZipSolution.exe"; Description: "{cm:LaunchProgram,ZipSolution}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: files; Name: "{app}\ZipSolution.url"




