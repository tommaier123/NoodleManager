if "%~1"=="" goto blank
if "%~2"=="" goto blank

timeout /T 1 /nobreak

rmdir /s/q %1

ren "%CD%\NoodleManagerUpdate" %2
echo "%CD%\rename.bat"
pause
del /q "%CD%\rename.bat"
:blank