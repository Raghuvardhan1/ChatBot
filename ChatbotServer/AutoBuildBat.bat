@echo off
set "BAT_PATH=%~dp0"

@echo off
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat"

echo %BAT_PATH%
echo Executing batch file

<<<<<<< HEAD
MSBuild "%BAT_PATH%\chatbotrepo.sln" 
=======
MSBuild "%BAT_PATH%\chatbotrepo.sln"
>>>>>>> 47852c38b60d489141f1b3a5fd1bb3332593af7e
pause

set testPath="%BAT_PATH%\ChatbotUnitTest\bin\Debug\ChatbotUnitTest.dll"
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

pause

"%BAT_PATH%\Simian\bin\simian-2.5.10.exe" "%BAT_PATH%\**\*.cs"  

pause

start "" http://localhost:52413

pause
