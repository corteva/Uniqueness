; note that this uses the NSIS DotNetChecker https://github.com/ReVolly/NsisDotNetChecker
  !include "DotNetChecker.nsh"
  !include "MUI2.nsh"

  Name "Uniqueness"
  OutFile "Uniqueness-Install.exe"

!define MUI_ICON "Uniqueness\Resources\Corteva.ico"
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "Uniqueness\Resources\CortevaLegal_HorColor_RGB_no_tagline.bmp"
!define MUI_HEADERIMAGE_RIGHT

  ;Default installation folder
  InstallDir "$LOCALAPPDATA\Corteva Agriscience\Uniqueness"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Corteva Agriscience\Uniqueness" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel highest

;--------------------------------
;Variables

  Var StartMenuFolder

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_LICENSE "License.rtf"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  
  ;Start Menu Folder Page Configuration
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU" 
  !define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\Corteva Agriscience\Uniqueness" 
  !define MUI_STARTMENUPAGE_Application_DEFAULTFOLDER "Corteva Agriscience\Uniqueness"
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Start Menu Folder"
  
  #!insertmacro MUI_PAGE_STARTMENU Application $StartMenuFolder
  
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES

;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Application" SecDummy
!insertmacro CheckNetFramework 461  
SetOutPath "$INSTDIR"
File /r "Uniqueness\bin\Release\*.exe"
File /r "Uniqueness\bin\Release\*.dll"
File /r "Uniqueness\bin\Release\*.pdf"
File /r "Uniqueness\bin\Release\*.pdb"

  
  ;Store installation folder
  WriteRegStr HKCU "Software\Corteva Agriscience\Uniqueness" "" $INSTDIR
  
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  
  ;!insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    
    ;Create shortcuts
    CreateDirectory "$SMPROGRAMS\Corteva Agriscience\$StartMenuFolder"
    CreateShortcut "$SMPROGRAMS\Corteva Agriscience\Similarity Search.lnk" "$INSTDIR\Similarity Search.exe"
    CreateShortcut "$SMPROGRAMS\Corteva Agriscience\$StartMenuFolder\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
  
  ;!insertmacro MUI_STARTMENU_WRITE_END

SectionEnd
Section "Example Files" SecDummy1
    SetOutPath "$INSTDIR\Example"
    File /r "Uniqueness\bin\Release\Example"
SectionEnd
;Uninstaller Section

Section "Uninstall"

  Delete "$INSTDIR\Uninstall.exe"

  RMDir  /r "$INSTDIR"
  
  !insertmacro MUI_STARTMENU_GETFOLDER Application $StartMenuFolder
    
  Delete "$SMPROGRAMS\$StartMenuFolder\Uninstall.lnk"
  Delete "$SMPROGRAMS\Corteva Agriscience\Similarity Search.lnk"
  Delete "$SMPROGRAMS\Corteva Agriscience\$StartMenuFolder\Uninstall.lnk" 
  RMDir "$SMPROGRAMS\$StartMenuFolder"
  RMDIR "$SMPROGRAMS\Corteva Agriscience\$StartMenuFolder"
  
  DeleteRegKey /ifempty HKCU "Software\Corteva Agriscience\Uniqueness"

SectionEnd

